using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace LootHub.Client.Application.Common;

public class JwtAuthorizationHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var accessToken = httpContextAccessor.HttpContext?.User.FindFirst(ClaimNames.AccessToken)?.Value;

        if (!string.IsNullOrEmpty(accessToken))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        return await base.SendAsync(request, ct);
    }
}
