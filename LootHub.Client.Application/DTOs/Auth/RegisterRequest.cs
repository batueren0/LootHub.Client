namespace LootHub.Client.Application.DTOs.Auth;

public sealed record RegisterRequest(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Email,
    string Password
    );
