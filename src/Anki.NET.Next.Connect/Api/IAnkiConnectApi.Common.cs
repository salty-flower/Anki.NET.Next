using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Json;
using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Api;

public partial interface IAnkiConnectApi
{
    HttpClient Client { get; }

    public async Task<AnkiResponse<JsonElement>?> GenericAsync<TParam>(TParam param)
        where TParam : AnkiRequestParamsBase
    {
        var request = param.ToRequest<TParam>();
        AnkiJsonContext.Default.Options.TryGetTypeInfo(
            typeof(AnkiRequest<TParam>),
            out var jsontypeinfo
        );
        var requestJson = JsonSerializer.Serialize(
            request,
            jsontypeinfo ?? throw new ArgumentNullException(typeof(TParam).FullName)
        );
        var result = await Client.PostAsync("/", new StringContent(requestJson));
        if (!result.IsSuccessStatusCode)
        {
            return new AnkiResponse<JsonElement> { Error = result.ReasonPhrase };
        }
        var content = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<AnkiResponse<JsonElement>>(
            content,
            AnkiJsonContext.Default.AnkiResponseJsonElement
        );
    }
}
