namespace LootHub.Client.Application.DTOs.Auth;

public sealed record AuthResponse(
    string Token,
    DateTimeOffset ExpiresAt,
    Guid UserId,
    string Email,
    string FirstName,
    string LastName,
    IReadOnlyList<string> Roles
    );
