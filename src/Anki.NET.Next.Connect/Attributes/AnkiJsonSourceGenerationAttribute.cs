namespace Anki.NET.Next.Connect.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public sealed class AnkiJsonSourceGenerationAttribute : Attribute
{
    public required Type BaseClassType { get; init; }
    public required string ModelsNamespace { get; init; }
}
