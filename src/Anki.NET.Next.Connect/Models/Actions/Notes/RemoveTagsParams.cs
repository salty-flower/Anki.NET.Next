using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Notes;

public sealed record RemoveTagsParams : AnkiRequestParamsBase
{
    public required long[] Notes { get; init; }
    public required string Tags { get; init; }
}
