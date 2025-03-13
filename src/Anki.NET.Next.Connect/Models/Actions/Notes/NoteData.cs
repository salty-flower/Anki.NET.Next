using System.Collections.Generic;
using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record NoteData : AnkiRequestParamsBase
{
    public required string DeckName { get; init; }
    public required string ModelName { get; init; }
    public required Dictionary<string, string> Fields { get; init; }
    public string[]? Tags { get; init; }
    public Dictionary<string, string[]>? Audio { get; init; }
    public Dictionary<string, string[]>? Video { get; init; }
    public Dictionary<string, string[]>? Picture { get; init; }
    public bool? AllowDuplicate { get; init; }
}
