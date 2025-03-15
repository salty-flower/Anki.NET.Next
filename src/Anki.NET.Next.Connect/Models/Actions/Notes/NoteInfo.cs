using System.Collections.Generic;
using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record NoteInfo : AnkiRequestParamsBase
{
    public required long NoteId { get; init; }
    public required string ModelName { get; init; }
    public required Dictionary<string, string> Fields { get; init; }
    public required string[] Tags { get; init; }
    public required long[] Cards { get; init; }
}
