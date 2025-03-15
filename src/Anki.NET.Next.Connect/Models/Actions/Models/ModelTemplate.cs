namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelTemplate
{
    public required string Front { get; init; }
    public required string Back { get; init; }
}
