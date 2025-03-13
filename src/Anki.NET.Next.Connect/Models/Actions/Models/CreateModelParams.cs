using System.Collections.Generic;
using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record CreateModelParams : AnkiRequestParamsBase
{
    public required string ModelName { get; init; }
    public required string[] InOrderFields { get; init; }
    public string? Css { get; init; }
    public bool IsCloze { get; init; }
    public required CreateModelTemplate[] CardTemplates { get; init; }
}

public sealed record CreateModelTemplate
{
    public string? Name { get; init; }
    public required string Front { get; init; }
    public required string Back { get; init; }
}
