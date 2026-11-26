using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Brand;
using LootHub.Client.Application.DTOs.Catalog;

namespace LootHub.Client.Mvc.Models;

public class ShopIndexViewModel
{
    public ProductQuery Query { get; set; } = new();
    public PagedResult<ProductSummaryResponse> Products { get; set; } = new();
    public IReadOnlyList<CategoryResponse> Categories { get; set; } = [];
    public IReadOnlyList<BrandResponse> Brands { get; set; } = [];
}
