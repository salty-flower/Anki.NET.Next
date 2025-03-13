using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Decks;

public sealed record DeckConfigParams : AnkiRequestParamsBase
{
    public required string Deck { get; init; }
}
