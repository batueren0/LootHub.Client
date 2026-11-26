using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Auth;
using LootHub.Client.Application.Services.Interfaces;
using System.Net.Http.Json;

namespace LootHub.Client.Application.Services.Features;

public class AuthService(IHttpClientFactory httpClientFactory) : IAuthService
{
    public async Task<ServiceResult<AuthResponse>> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.PostAsJsonAsync("auth/login", request, ct);
        return await response.ToResultAsync<AuthResponse>();
    }

    public async Task<ServiceResult<AuthResponse>> RegisterAsync(RegisterRequest request, CancellationToken ct = default)
    {
        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.PostAsJsonAsync("auth/register", request, ct);
        return await response.ToResultAsync<AuthResponse>();
    }
}
