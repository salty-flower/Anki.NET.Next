using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelTemplateRepositionParams : AnkiRequestParamsBase
{
    public required string ModelName { get; init; }
    public required string TemplateName { get; init; }
    public required int Index { get; init; }
}
