using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelFieldAddParams : AnkiRequestParamsBase
{
    public required string ModelName { get; init; }
    public required string FieldName { get; init; }
    public int? Index { get; init; }
}
