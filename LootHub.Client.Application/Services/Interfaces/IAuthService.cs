using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Auth;

namespace LootHub.Client.Application.Services.Interfaces;

public interface IAuthService
{
    Task<ServiceResult<AuthResponse>> LoginAsync(LoginRequest request, CancellationToken ct = default);
    Task<ServiceResult<AuthResponse>> RegisterAsync(RegisterRequest request, CancellationToken ct = default);
}
