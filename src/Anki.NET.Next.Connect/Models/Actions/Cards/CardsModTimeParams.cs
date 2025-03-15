using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record CardsModTimeParams : AnkiRequestParamsBase
{
    public required long[] Cards { get; init; }
}

public sealed record CardModTime
{
    public required long CardId { get; init; }
    public required long Mod { get; init; }
}
