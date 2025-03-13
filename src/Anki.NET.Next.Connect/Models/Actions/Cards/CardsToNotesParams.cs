using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record CardsToNotesParams : AnkiRequestParamsBase
{
    public required long[] Cards { get; init; }
}
