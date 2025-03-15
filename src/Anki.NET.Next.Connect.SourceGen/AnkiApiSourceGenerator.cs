using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Anki.NET.Next.Connect.SourceGen;

[Generator]
public class AnkiApiSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var markedClasses = context
            .SyntaxProvider.CreateSyntaxProvider(
                predicate: (s, _) => IsSyntaxTargetForGeneration(s),
                transform: (ctx, _) => GetSemanticTargetForGeneration(ctx)
            )
            .Where(m => m is not null);

        var compilationAndClasses = context.CompilationProvider.Combine(markedClasses.Collect());

        context.RegisterSourceOutput(
            compilationAndClasses,
            (spc, source) => Execute(source.Left, source.Right, spc)
        );
    }

    private static bool IsSyntaxTargetForGeneration(SyntaxNode node)
    {
        return node is InterfaceDeclarationSyntax interfaceDeclaration
            && interfaceDeclaration.AttributeLists.Count > 0;
    }

    private static InterfaceDeclarationSyntax? GetSemanticTargetForGeneration(
        GeneratorSyntaxContext context
    )
    {
        var interfaceDeclaration = (InterfaceDeclarationSyntax)context.Node;
        foreach (var attributeList in interfaceDeclaration.AttributeLists)
        {
            foreach (var attribute in attributeList.Attributes)
            {
                if (
                    context.SemanticModel.GetSymbolInfo(attribute).Symbol
                    is not IMethodSymbol attributeSymbol
                )
                {
                    continue;
                }

                var attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                var fullName = attributeContainingTypeSymbol.ToDisplayString();

                if (
                    fullName == "Anki.NET.Next.Connect.Attributes.AnkiJsonSourceGenerationAttribute"
                )
                {
                    return interfaceDeclaration;
                }
            }
        }
        return null;
    }

    private static void Execute(
        Compilation compilation,
        ImmutableArray<InterfaceDeclarationSyntax> markedInterfaces,
        SourceProductionContext context
    )
    {
        if (markedInterfaces.IsDefaultOrEmpty)
            return;

        var baseClassType = "Anki.NET.Next.Connect.Models.Common.AnkiRequestParamsBase";
        var modelsNamespace = "Anki.NET.Next.Connect.Models.Actions";

        var derivedTypes = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

        var stack = new Stack<INamespaceSymbol>();
        stack.Push(compilation.GlobalNamespace);

        var baseTypeSymbol = compilation.GetTypeByMetadataName(baseClassType);
        if (baseTypeSymbol == null)
            return;

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            foreach (var nestedNamespace in current.GetNamespaceMembers())
            {
                stack.Push(nestedNamespace);
            }

            foreach (var type in current.GetTypeMembers())
            {
                var typeNamespace = type.ContainingNamespace.ToDisplayString();

                if (!typeNamespace.StartsWith(modelsNamespace))
                    continue;

                if (type.IsAbstract)
                    continue;

                var baseType = type.BaseType;
                while (baseType != null)
                {
                    if (SymbolEqualityComparer.Default.Equals(baseType, baseTypeSymbol))
                    {
                        derivedTypes.Add(type);
                        break;
                    }
                    baseType = baseType.BaseType;
                }
            }
        }

        var sourceBuilder = new StringBuilder();
        sourceBuilder.AppendLine("using System.Text.Json;");
        sourceBuilder.AppendLine("using System.Net.Http;");
        sourceBuilder.AppendLine("using System.Threading;");
        sourceBuilder.AppendLine("using System.Threading.Tasks;");
        sourceBuilder.AppendLine("using Anki.NET.Next.Connect.Models.Common;");
        sourceBuilder.AppendLine("using Refit;");
        sourceBuilder.AppendLine();
        sourceBuilder.AppendLine("namespace Anki.NET.Next.Connect.Api;");
        sourceBuilder.AppendLine();
        sourceBuilder.AppendLine("public partial interface IAnkiConnectApi");
        sourceBuilder.AppendLine("{");

        // Generate generic method with pattern matching
        sourceBuilder.AppendLine(
            "    public async Task<string> GenericAsync<TParams>(TParams parameters, CancellationToken ct = default)"
        );
        sourceBuilder.AppendLine("        where TParams : AnkiRequestParamsBase");
        sourceBuilder.AppendLine("    {");
        sourceBuilder.AppendLine("        var request = parameters switch");
        sourceBuilder.AppendLine("        {");

        // Generate pattern matching cases for request creation
        foreach (var type in derivedTypes)
        {
            var typeName = type.Name;
            var fullName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            var methodName = typeName.Replace("Params", "");
            var actionName = JsonNamingPolicy.CamelCase.ConvertName(methodName);

            sourceBuilder.AppendLine($"            {fullName} p => new AnkiRequest<{fullName}>");
            sourceBuilder.AppendLine("            {");
            sourceBuilder.AppendLine($"                Action = \"{actionName}\",");
            sourceBuilder.AppendLine("                Params = p");
            sourceBuilder.AppendLine("            },");
        }

        sourceBuilder.AppendLine(
            $"            _ => throw new ArgumentException($\"Unknown parameter type: {{typeof(TParams).Name}}\")"
        );
        sourceBuilder.AppendLine("        };");
        sourceBuilder.AppendLine();
        sourceBuilder.AppendLine(
            "        var client = new HttpClient { BaseAddress = new Uri(\"http://localhost:18765\") };"
        );
        sourceBuilder.AppendLine(
            "        var response = await client.PostAsync(\"/\", new StringContent(JsonSerializer.Serialize(request, AnkiJsonContext.Default.Options)));"
        );
        sourceBuilder.AppendLine("        return await response.Content.ReadAsStringAsync();");
        sourceBuilder.AppendLine("    }");

        sourceBuilder.AppendLine("}");

        context.AddSource("IAnkiConnectApi.Generated.cs", sourceBuilder.ToString());
    }

    private static string ToLowerFirst(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        return char.ToLowerInvariant(str[0]) + str.Substring(1);
    }
}
