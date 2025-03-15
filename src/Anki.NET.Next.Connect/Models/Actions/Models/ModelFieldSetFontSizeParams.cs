using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelFieldSetFontSizeParams : AnkiRequestParamsBase
{
    public required string ModelName { get; init; }
    public required string FieldName { get; init; }
    public required int FontSize { get; init; }
}
