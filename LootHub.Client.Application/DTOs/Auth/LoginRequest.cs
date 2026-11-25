namespace LootHub.Client.Application.DTOs.Auth;

public sealed record LoginRequest(
    string Email,
    string Password
    );
