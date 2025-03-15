namespace Anki.NET.Next.Connect.Models.Common;

public sealed record AnkiRequest<TParams>
    where TParams : AnkiRequestParamsBase
{
    public required string Action { get; init; }
    public required TParams Params { get; init; }
    public int Version { get; init; } = 6;
}
