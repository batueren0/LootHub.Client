namespace LootHub.Client.Application.DTOs.Address;

public sealed record CreateAddressRequest(
    string Title,
    string Details,
    string City,
    string Country
    );
