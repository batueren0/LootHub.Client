namespace LootHub.Client.Application.DTOs.Brand;

public sealed record BrandResponse(
    Guid Id,
    string Name,
    string Slug
    );
