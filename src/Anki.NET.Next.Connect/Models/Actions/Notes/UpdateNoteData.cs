namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public record UpdateNoteData
{
    public required long Id { get; init; }
    public required Dictionary<string, string> Fields { get; init; }
    public Dictionary<string, string[]>? Audio { get; init; }
    public Dictionary<string, string[]>? Video { get; init; }
    public Dictionary<string, string[]>? Picture { get; init; }
}
