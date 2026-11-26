using LootHub.Client.Application.DTOs.Catalog;

namespace LootHub.Client.Mvc.Models;

public class HomeViewModel
{
    public IReadOnlyList<CategoryResponse> Categories { get; set; } = [];
    public IReadOnlyList<ProductSummaryResponse> Products { get; set; } = [];
}
