using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record CardInfo : AnkiRequestParamsBase
{
    public required long CardId { get; init; }
    public required string Answer { get; init; }
    public required string Question { get; init; }
    public required long DeckId { get; init; }
    public required string ModelName { get; init; }
    public required int Interval { get; init; }
    public required string Note { get; init; }
    public required int OrderId { get; init; }
    public required string Type { get; init; }
    public required string Queue { get; init; }
    public required int Due { get; init; }
    public required int Reps { get; init; }
    public required int Lapses { get; init; }
    public required int Left { get; init; }
}
