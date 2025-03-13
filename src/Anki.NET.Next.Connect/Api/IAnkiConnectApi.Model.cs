using System.Threading;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Models.Actions.Models;
using Anki.NET.Next.Connect.Models.Common;
using HttpClientFillerAttribute;

namespace Anki.NET.Next.Connect.Services;

public partial interface IAnkiConnectApi
{
    [Post(" ")]
    Task<AnkiResponse<string[]>> ModelNamesAsync(
        [Body] AnkiRequest<ModelNamesParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<string[]>> ModelFieldsAsync(
        [Body] AnkiRequest<ModelFieldsParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<object>> ModelTemplatesAsync(
        [Body] AnkiRequest<ModelTemplatesParams> request,
        CancellationToken ct = default
    );

    [Post(" ")]
    Task<AnkiResponse<string>> ModelStylingAsync(
        [Body] AnkiRequest<ModelStylingParams> request,
        CancellationToken ct = default
    );
}
