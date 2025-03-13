using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record AreDueParams : AnkiRequestParamsBase
{
    public required long[] Cards { get; init; }
}
