using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record NotesModTimeParams : AnkiRequestParamsBase
{
    public required long[] Notes { get; init; }
}

public sealed record NoteModTime
{
    public required long NoteId { get; init; }
    public required long Mod { get; init; }
}
