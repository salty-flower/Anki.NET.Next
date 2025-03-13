using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record CanAddNotesParams : AnkiRequestParamsBase
{
    public required NoteData[] Notes { get; init; }
}
