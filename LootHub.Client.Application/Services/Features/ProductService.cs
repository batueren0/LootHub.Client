using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Catalog;
using LootHub.Client.Application.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using System.Globalization;

namespace LootHub.Client.Application.Services.Features;

public class ProductService(IHttpClientFactory httpClientFactory) : IProductService
{
    public async Task<ServiceResult<PagedResult<ProductSummaryResponse>>> GetPagedAsync(ProductQuery query, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, string?>
        {
            ["page"] = query.Page.ToString(),
            ["pageSize"] = query.PageSize.ToString(),
            ["sort"] = query.Sort.ToString()
        };

        if (!string.IsNullOrWhiteSpace(query.Search))
            parameters["search"] = query.Search.Trim();
        if (query.CategoryId.HasValue)
            parameters["categoryId"] = query.CategoryId.Value.ToString();
        if (query.BrandId.HasValue)
            parameters["brandId"] = query.BrandId.Value.ToString();
        if (query.MinPrice.HasValue)
            parameters["minPrice"] = query.MinPrice.Value.ToString(CultureInfo.InvariantCulture);
        if (query.MaxPrice.HasValue)
            parameters["maxPrice"] = query.MaxPrice.Value.ToString(CultureInfo.InvariantCulture);
        if (query.InStockOnly)
            parameters["inStockOnly"] = "true";

        var url = QueryHelpers.AddQueryString("products", parameters);

        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.GetAsync(url, ct);
        return await response.ToResultAsync<PagedResult<ProductSummaryResponse>>();
    }
}
