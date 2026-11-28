namespace LootHub.Client.Application.DTOs.Address;

public sealed record AddressResponse(
    Guid Id,
    string Title,
    string Details,
    string City,
    string Country
    );

