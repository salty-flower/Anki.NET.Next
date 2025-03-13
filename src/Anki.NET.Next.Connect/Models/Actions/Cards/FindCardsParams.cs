using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record FindCardsParams : AnkiRequestParamsBase
{
    public required string Query { get; init; }
}
