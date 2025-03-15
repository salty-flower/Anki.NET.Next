using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record FindNotesParams : AnkiRequestParamsBase
{
    public required string Query { get; init; }
}
