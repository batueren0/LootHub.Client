using System.Globalization;
using LootHub.Client.Application.DTOs.Catalog;

namespace LootHub.Client.Mvc.Helpers;

public static class ProductQueryRoutes
{
    public static Dictionary<string, string> ToRouteValues(this ProductQuery query)
    {
        var values = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(query.Search))
            values["search"] = query.Search;
        if (query.CategoryId.HasValue)
            values["categoryId"] = query.CategoryId.Value.ToString();
        if (query.BrandId.HasValue)
            values["brandId"] = query.BrandId.Value.ToString();
        if (query.MinPrice.HasValue)
            values["minPrice"] = query.MinPrice.Value.ToString(CultureInfo.InvariantCulture);
        if (query.MaxPrice.HasValue)
            values["maxPrice"] = query.MaxPrice.Value.ToString(CultureInfo.InvariantCulture);
        if (query.InStockOnly)
            values["inStockOnly"] = "true";
        if (query.Sort != ProductSort.Newest)
            values["sort"] = query.Sort.ToString();
        if (query.Page > 1)
            values["page"] = query.Page.ToString();

        return values;
    }
}
