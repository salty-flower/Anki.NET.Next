namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record UpdateModelStylingModel
{
    public required string Name { get; init; }
    public required string Css { get; init; }
}
