namespace LootHub.Client.Application.DTOs.Catalog;

public sealed record ProductSummaryResponse(
    Guid Id,
    string Name,
    string Slug,
    decimal Price,
    string Currency,
    string? ImageUrl,
    string BrandName,
    string CategoryName,
    int Stock
    );
