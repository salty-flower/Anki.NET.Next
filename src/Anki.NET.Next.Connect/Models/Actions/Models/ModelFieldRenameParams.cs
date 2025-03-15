using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelFieldRenameParams : AnkiRequestParamsBase
{
    public required string ModelName { get; init; }
    public required string OldFieldName { get; init; }
    public required string NewFieldName { get; init; }
}
