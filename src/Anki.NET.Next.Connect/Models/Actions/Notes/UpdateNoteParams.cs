using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record UpdateNoteParams : AnkiRequestParamsBase
{
    public required UpdateNoteWithTagsData Note { get; init; }
}

public sealed record UpdateNoteWithTagsData : UpdateNoteData
{
    public string[]? Tags { get; init; }
}
