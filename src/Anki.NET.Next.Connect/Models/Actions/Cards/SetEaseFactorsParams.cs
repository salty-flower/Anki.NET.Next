using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record SetEaseFactorsParams : AnkiRequestParamsBase
{
    public required long[] Cards { get; init; }
    public required int[] EaseFactors { get; init; }
}
