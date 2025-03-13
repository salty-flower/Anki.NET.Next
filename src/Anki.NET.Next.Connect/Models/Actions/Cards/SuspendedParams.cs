using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record SuspendedParams : AnkiRequestParamsBase
{
    public required long Card { get; init; }
}
