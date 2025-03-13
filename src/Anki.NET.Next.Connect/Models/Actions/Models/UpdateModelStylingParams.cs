using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record UpdateModelStylingParams : AnkiRequestParamsBase
{
    public required UpdateModelStylingModel Model { get; init; }
}
