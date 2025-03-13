using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record ModelFieldFontsParams : AnkiRequestParamsBase
{
    public required string ModelName { get; init; }
}
