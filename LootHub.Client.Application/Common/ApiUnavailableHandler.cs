using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Json;

namespace LootHub.Client.Application.Common;

public class ApiUnavailableHandler(ILogger<ApiUnavailableHandler> logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request , CancellationToken ct)
    {
        try
        {
            return await base.SendAsync(request, ct);
        }
        catch(HttpRequestException ex)
        {
            logger.LogWarning(ex, "API unreachable: {Url}", request.RequestUri);

            return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
            {
                Content = JsonContent.Create(new ProblemDetails { Detail = "Sunucuya şu an ulaşılamıyor, lütfen biraz sonra tekrar dene." })
            };
        }
    }
}
