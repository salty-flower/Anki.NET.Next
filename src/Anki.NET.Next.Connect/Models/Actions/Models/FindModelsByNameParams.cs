using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record FindModelsByNameParams : AnkiRequestParamsBase
{
    public required string[] ModelNames { get; init; }
}
