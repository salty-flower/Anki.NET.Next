using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelTemplateAddParams : AnkiRequestParamsBase
{
    public required string ModelName { get; init; }
    public required CreateModelTemplate Template { get; init; }
}
