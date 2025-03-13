using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record FindAndReplaceInModelsParams : AnkiRequestParamsBase
{
    public required FindAndReplaceInModelsModel Model { get; init; }
}
