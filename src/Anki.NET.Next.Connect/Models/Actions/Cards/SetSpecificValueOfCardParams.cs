using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record SetSpecificValueOfCardParams : AnkiRequestParamsBase
{
    public required long Card { get; init; }
    public required string[] Keys { get; init; }
    public required string[] NewValues { get; init; }
    public bool? WarningCheck { get; init; }
}
