using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record DeleteNotesParams : AnkiRequestParamsBase
{
    public required long[] Notes { get; init; }
}
