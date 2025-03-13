namespace Anki.NET.Next.Connect.Models.Common;

public sealed record AnkiRequest<TParams>
{
    public required string Action { get; init; }
    public required TParams Params { get; init; }
    public required int Version { get; init; } = 6;
}
