using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record GetNoteTagsParams : AnkiRequestParamsBase
{
    public required long Note { get; init; }
}
