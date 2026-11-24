using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LootHub.Client.Application.Common;

public static class HttpResponseMessageExtensions
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() }
    };
    private const string DefaultError = "Beklenmeyen bir hata oluştu.";

    public static async Task<ServiceResult<T>> ToResultAsync<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<T>(JsonOptions);
            return ServiceResult<T>.Success(data!);
        }

        var error = await ReadErrorAsync(response);
        return ServiceResult<T>.Failure(error, (int)response.StatusCode);
    }

    public static async Task<ServiceResult> ToResultAsync(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            return ServiceResult.Success();
        }

        var error = await ReadErrorAsync(response);
        return ServiceResult.Failure(error, (int)response.StatusCode);
    }

    private static async Task<string> ReadErrorAsync(HttpResponseMessage response)
    {
        var body = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(body))
            return DefaultError;


        try
        {
            var problem = JsonSerializer.Deserialize<ProblemDetails>(body, JsonOptions);
            return problem?.Detail ?? problem?.Title ?? DefaultError;
        }
        catch (JsonException)
        {
            return DefaultError;
        }
    }
}
