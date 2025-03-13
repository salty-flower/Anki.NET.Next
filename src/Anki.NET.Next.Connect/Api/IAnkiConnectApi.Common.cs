using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anki.NET.Next.Connect.Json;
using Anki.NET.Next.Connect.Models.Common;

namespace Anki.NET.Next.Connect.Api;

public partial interface IAnkiConnectApi
{
    HttpClient Client { get; }

    public async Task<AnkiResponse<object>?> GenericAsync<TParam>(TParam param)
        where TParam : AnkiRequestParamsBase
    {
        var request = param.ToRequest<TParam>();
        var requestJson = JsonSerializer.Serialize(request, AnkiJsonContext.Default.Options);
        var result = await Client.PostAsync("/", new StringContent(requestJson));
        if (!result.IsSuccessStatusCode)
        {
            return new AnkiResponse<object> { Error = result.ReasonPhrase };
        }
        var content = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<AnkiResponse<object>>(
            content,
            AnkiJsonContext.Default.Options
        );
    }
}
