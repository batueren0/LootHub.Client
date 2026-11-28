namespace LootHub.Client.Application.DTOs.Address;

public sealed record UpdateAddressRequest(
    string Title,
    string Details,
    string City,
    string Country
    );
