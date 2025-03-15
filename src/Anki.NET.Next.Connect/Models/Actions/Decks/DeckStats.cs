using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Decks;

public sealed record DeckStats : AnkiRequestParamsBase
{
    public required int LearnCount { get; init; }
    public required int ReviewCount { get; init; }
    public required int RelearningCount { get; init; }
    public required int TotalCards { get; init; }
    public required int NewCount { get; init; }
}
