using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Anki.NET.Next.Connect.SourceGen;

[Generator]
public class AnkiJsonSourceGenerator : IIncrementalGenerator
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
        return node is ClassDeclarationSyntax classDeclaration
            && classDeclaration.AttributeLists.Count > 0;
    }

    private static ClassDeclarationSyntax? GetSemanticTargetForGeneration(
        GeneratorSyntaxContext context
    )
    {
        var classDeclaration = (ClassDeclarationSyntax)context.Node;
        foreach (var attributeList in classDeclaration.AttributeLists)
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
                    return classDeclaration;
                }
            }
        }
        return null;
    }

    private static void Execute(
        Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax> markedClasses,
        SourceProductionContext context
    )
    {
        if (markedClasses.IsDefaultOrEmpty)
            return;

        // Get the first marked class's attribute to read configuration
        var classDeclaration = markedClasses[0];
        var semanticModel = compilation.GetSemanticModel(classDeclaration.SyntaxTree);
        var attribute = classDeclaration
            .AttributeLists.SelectMany(al => al.Attributes)
            .FirstOrDefault(attr =>
                semanticModel.GetSymbolInfo(attr).Symbol is IMethodSymbol method
                && method.ContainingType.ToDisplayString()
                    == "Anki.NET.Next.Connect.Attributes.AnkiJsonSourceGenerationAttribute"
            );

        if (attribute == null)
            return;

        // Get attribute constructor arguments
        var attributeData = semanticModel.GetSymbolInfo(attribute).Symbol as IMethodSymbol;
        if (attributeData == null)
            return;

        var baseClassType = "Anki.NET.Next.Connect.Models.Common.AnkiRequestParamsBase";
        var modelsNamespace = "Anki.NET.Next.Connect.Models.Actions";

        var derivedTypes = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);
        var additionalTypes = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

        // Find all types in the compilation
        var stack = new Stack<INamespaceSymbol>();
        stack.Push(compilation.GlobalNamespace);

        var baseTypeSymbol = compilation.GetTypeByMetadataName(baseClassType);
        if (baseTypeSymbol == null)
        {
            context.ReportDiagnostic(
                Diagnostic.Create(
                    new DiagnosticDescriptor(
                        "AJS001",
                        "Base type not found",
                        "Base type {0} not found in compilation",
                        "AnkiJsonSourceGen",
                        DiagnosticSeverity.Warning,
                        isEnabledByDefault: true
                    ),
                    Location.None,
                    baseClassType
                )
            );
            return;
        }

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

                // Only process types from our models namespace
                if (!typeNamespace.StartsWith(modelsNamespace))
                    continue;

                if (type.IsAbstract)
                    continue;

                // Check if it derives from the base class
                var baseType = type.BaseType;
                var isDerived = false;
                while (baseType != null)
                {
                    if (SymbolEqualityComparer.Default.Equals(baseType, baseTypeSymbol))
                    {
                        derivedTypes.Add(type);
                        isDerived = true;
                        context.ReportDiagnostic(
                            Diagnostic.Create(
                                new DiagnosticDescriptor(
                                    "AJS002",
                                    "Found derived type",
                                    "Found type {0} derived from base class",
                                    "AnkiJsonSourceGen",
                                    DiagnosticSeverity.Info,
                                    isEnabledByDefault: true
                                ),
                                Location.None,
                                type.ToDisplayString()
                            )
                        );
                        break;
                    }
                    baseType = baseType.BaseType;
                }

                // If not derived but still in models namespace, add to additional types
                if (!isDerived)
                {
                    additionalTypes.Add(type);
                    context.ReportDiagnostic(
                        Diagnostic.Create(
                            new DiagnosticDescriptor(
                                "AJS003",
                                "Found additional type",
                                "Found additional type {0} in models namespace",
                                "AnkiJsonSourceGen",
                                DiagnosticSeverity.Info,
                                isEnabledByDefault: true
                            ),
                            Location.None,
                            type.ToDisplayString()
                        )
                    );
                }
            }
        }

        var sourceBuilder = new StringBuilder();
        sourceBuilder.AppendLine("using System.Text.Json.Serialization;");
        sourceBuilder.AppendLine();
        sourceBuilder.AppendLine("namespace Anki.NET.Next.Connect.Json;");
        sourceBuilder.AppendLine();

        // Generate attributes for derived types (both the type itself and AnkiRequest<T>)
        foreach (var type in derivedTypes)
        {
            var fullName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            sourceBuilder.AppendLine(
                $"[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiRequest<{fullName}>))]"
            );
            sourceBuilder.AppendLine($"[JsonSerializable(typeof({fullName}))]");
        }

        // Generate attributes for additional types (just the type itself)
        foreach (var type in additionalTypes)
        {
            var fullName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            sourceBuilder.AppendLine($"[JsonSerializable(typeof({fullName}))]");
        }

        // Generate attributes for common response types
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<long>))]"
        );
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<long[]>))]"
        );
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<string>))]"
        );
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<string[]>))]"
        );
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<bool>))]"
        );
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<bool[]>))]"
        );
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<bool?[]>))]"
        );
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<int[]>))]"
        );
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<object>))]"
        );
        sourceBuilder.AppendLine(
            "[JsonSerializable(typeof(global::Anki.NET.Next.Connect.Models.Common.AnkiResponse<object[]>))]"
        );

        sourceBuilder.AppendLine("public partial class AnkiJsonContext { }");

        context.AddSource("AnkiJsonContext.g.cs", sourceBuilder.ToString());
    }
}
