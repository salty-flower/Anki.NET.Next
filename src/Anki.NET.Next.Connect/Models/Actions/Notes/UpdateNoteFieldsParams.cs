using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record UpdateNoteFieldsParams : AnkiRequestParamsBase
{
    public required UpdateNoteData Note { get; init; }
}
