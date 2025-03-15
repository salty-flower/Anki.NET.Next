using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record FindModelsByIdParams : AnkiRequestParamsBase
{
    public required long[] ModelIds { get; init; }
}
