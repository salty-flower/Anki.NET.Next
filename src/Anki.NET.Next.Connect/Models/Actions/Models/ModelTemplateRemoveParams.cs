using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelTemplateRemoveParams : AnkiRequestParamsBase
{
    public required string ModelName { get; init; }
    public required string TemplateName { get; init; }
}
