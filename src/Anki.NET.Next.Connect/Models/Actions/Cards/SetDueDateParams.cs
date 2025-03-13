using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record SetDueDateParams : AnkiRequestParamsBase
{
    public required long[] Cards { get; init; }
    public required string Days { get; init; }
}
