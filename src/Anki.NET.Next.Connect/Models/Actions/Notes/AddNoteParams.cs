using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record AddNoteParams : AnkiRequestParamsBase
{
    public required NoteData Note { get; init; }
}
