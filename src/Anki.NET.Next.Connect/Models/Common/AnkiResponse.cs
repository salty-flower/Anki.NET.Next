namespace Anki.NET.Next.Connect.Models.Common;

public sealed record AnkiResponse<TResult>
{
    public TResult? Result { get; init; }
    public string? Error { get; init; }
}
