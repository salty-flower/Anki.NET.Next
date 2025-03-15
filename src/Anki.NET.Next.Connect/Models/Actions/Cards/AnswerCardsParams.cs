using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Models.Actions.Cards;

public sealed record AnswerCardsParams : AnkiRequestParamsBase
{
    public required CardAnswer[] Answers { get; init; }
}

public sealed record CardAnswer
{
    public required long CardId { get; init; }
    public required int Ease { get; init; }
}
