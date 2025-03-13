using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record UpdateNoteModelParams : AnkiRequestParamsBase
{
    public required UpdateNoteModelData Note { get; init; }
}

public sealed record UpdateNoteModelData
{
    public required long Id { get; init; }
    public required string ModelName { get; init; }
    public required Dictionary<string, string> Fields { get; init; }
    public string[]? Tags { get; init; }
}
