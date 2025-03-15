namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelFieldFont
{
    public required string Font { get; init; }
    public required int Size { get; init; }
}
