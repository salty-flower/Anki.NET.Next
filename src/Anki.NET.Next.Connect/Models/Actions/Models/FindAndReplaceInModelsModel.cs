namespace Anki.NET.Next.Connect.Models.Actions.Models;

public sealed record FindAndReplaceInModelsModel
{
    public required string ModelName { get; init; }
    public required string FindText { get; init; }
    public required string ReplaceText { get; init; }
    public bool Front { get; init; }
    public bool Back { get; init; }
    public bool Css { get; init; }
}
