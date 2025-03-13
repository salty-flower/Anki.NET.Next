using static System.Text.Json.JsonNamingPolicy;

namespace Anki.NET.Next.Connect.Models.Common;

public abstract record AnkiRequestParamsBase
{
    public static string GetTypeName<T>()
        where T : AnkiRequestParamsBase =>
        CamelCase.ConvertName(typeof(T).Name.Replace("Params", ""));

    public AnkiRequest<TParams> ToRequest<TParams>()
        where TParams : AnkiRequestParamsBase =>
        new() { Action = GetTypeName<TParams>(), Params = (TParams)(object)this };
}
