using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelTemplateRenameParams : AnkiRequestParamsBase
{
    public required string ModelName { get; init; }
    public required string OldTemplateName { get; init; }
    public required string NewTemplateName { get; init; }
}
