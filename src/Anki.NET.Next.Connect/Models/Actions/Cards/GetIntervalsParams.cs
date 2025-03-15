using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record GetIntervalsParams : AnkiRequestParamsBase
{
    public required long[] Cards { get; init; }
    public bool? Complete { get; init; }
}
