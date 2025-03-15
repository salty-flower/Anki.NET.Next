using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record UpdateNoteTagsParams : AnkiRequestParamsBase
{
    public required long Note { get; init; }
    public required string[] Tags { get; init; }
}
