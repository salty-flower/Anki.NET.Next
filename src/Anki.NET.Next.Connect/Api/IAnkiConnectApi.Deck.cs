using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Models.Actions.Decks;
using Anki.NET.Next.Connect.Models.Common;
using HttpClientFillerAttribute;

namespace Anki.NET.Next.Connect.Services;

public partial interface IAnkiConnectApi
{
    [Post(" ")]
    Task<AnkiResponse<string[]>> DeckNamesAsync(
        [Body] AnkiRequest<DeckNamesParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<DeckNameId[]>> DeckNamesAndIdsAsync(
        [Body] AnkiRequest<DeckNamesAndIdsParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<Dictionary<string, DeckStats>>> DeckStatsAsync(
        [Body] AnkiRequest<DeckStatsParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<object>> DeckConfigAsync(
        [Body] AnkiRequest<DeckConfigParams> request,
        CancellationToken ct = default
    );
}
