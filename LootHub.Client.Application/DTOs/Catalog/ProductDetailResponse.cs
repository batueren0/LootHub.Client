namespace LootHub.Client.Application.DTOs.Catalog;

public sealed record ProductDetailResponse(
    Guid Id,
    Guid BrandId,
    Guid CategoryId,
    string Name,
    string Description,
    string Slug,
    decimal Price,
    string Currency,
    string? ImageUrl,
    string BrandName,
    string CategoryName,
    int Stock,
    IReadOnlyList<ProductPropertyResponse> Properties
    );
