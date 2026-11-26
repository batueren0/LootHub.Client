namespace LootHub.Client.Application.DTOs.Catalog;

public sealed record ProductQuery
{
    public string? Search { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? BrandId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public bool InStockOnly { get; set; } = false;
    public ProductSort Sort { get; set; } = ProductSort.Newest;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 12;
}
