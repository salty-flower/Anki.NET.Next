using System.Threading;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Models.Actions.Cards;
using Anki.NET.Next.Connect.Models.Common;
using HttpClientFillerAttribute;

namespace Anki.NET.Next.Connect.Services;

public partial interface IAnkiConnectApi
{
    [Post(" ")]
    Task<AnkiResponse<CardInfo[]>> CardsInfoAsync(
        [Body] AnkiRequest<CardsInfoParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<object?>> SuspendCardsAsync(
        [Body] AnkiRequest<SuspendCardsParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<object?>> UnsuspendCardsAsync(
        [Body] AnkiRequest<UnsuspendCardsParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<long[]>> FindCardsAsync(
        [Body] AnkiRequest<FindCardsParams> request,
        CancellationToken ct = default
    );
}
