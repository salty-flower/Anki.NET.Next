using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Decks;

public sealed record DeckStatsParams : AnkiRequestParamsBase
{
    public required string[] Decks { get; init; }
}
