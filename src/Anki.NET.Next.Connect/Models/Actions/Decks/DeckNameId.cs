using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Decks;

public sealed record DeckNameId : AnkiRequestParamsBase
{
    public required string Name { get; init; }
    public required long Id { get; init; }
}
