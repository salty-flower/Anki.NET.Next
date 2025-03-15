using System.Threading;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Models.Actions.Cards;
using Anki.NET.Next.Connect.Models.Common;
using Refit;

namespace Anki.NET.Next.Connect.Api;

public partial interface IAnkiConnectApi
{
    // Card information
    [Post("/")]
    Task<AnkiResponse<CardInfo[]>> CardsInfoAsync(
        [Body] AnkiRequest<CardsInfoParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<CardModTime[]>> CardsModTimeAsync(
        [Body] AnkiRequest<CardsModTimeParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<long[]>> CardsToNotesAsync(
        [Body] AnkiRequest<CardsToNotesParams> request,
        CancellationToken ct = default
    );

    // Card search
    [Post("/")]
    Task<AnkiResponse<long[]>> FindCardsAsync(
        [Body] AnkiRequest<FindCardsParams> request,
        CancellationToken ct = default
    );

    // Card suspension
    [Post("/")]
    Task<AnkiResponse<object?>> SuspendCardsAsync(
        [Body] AnkiRequest<SuspendCardsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object?>> UnsuspendCardsAsync(
        [Body] AnkiRequest<UnsuspendCardsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<bool>> SuspendedAsync(
        [Body] AnkiRequest<SuspendedParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<bool?[]>> AreSuspendedAsync(
        [Body] AnkiRequest<AreSuspendedParams> request,
        CancellationToken ct = default
    );

    // Card scheduling
    [Post("/")]
    Task<AnkiResponse<bool[]>> AreDueAsync(
        [Body] AnkiRequest<AreDueParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<int[]>> GetEaseFactorsAsync(
        [Body] AnkiRequest<GetEaseFactorsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<bool[]>> SetEaseFactorsAsync(
        [Body] AnkiRequest<SetEaseFactorsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<bool[]>> SetSpecificValueOfCardAsync(
        [Body] AnkiRequest<SetSpecificValueOfCardParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<int[]>> GetIntervalsAsync(
        [Body] AnkiRequest<GetIntervalsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object?>> ForgetCardsAsync(
        [Body] AnkiRequest<ForgetCardsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<object?>> RelearnCardsAsync(
        [Body] AnkiRequest<RelearnCardsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<bool[]>> AnswerCardsAsync(
        [Body] AnkiRequest<AnswerCardsParams> request,
        CancellationToken ct = default
    );

    [Post("/")]
    Task<AnkiResponse<bool>> SetDueDateAsync(
        [Body] AnkiRequest<SetDueDateParams> request,
        CancellationToken ct = default
    );
}
