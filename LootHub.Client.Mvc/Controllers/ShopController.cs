using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Catalog;
using LootHub.Client.Application.Services.Interfaces;
using LootHub.Client.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LootHub.Client.Mvc.Controllers;

public class ShopController(
    ICategoryService categoryService,
    IProductService productService,
    IBrandService brandService
    ) : Controller
{
    public async Task<IActionResult> Index([FromQuery] ProductQuery query, CancellationToken ct)
    {
        var categories = await categoryService.GetAllAsync(ct);
        var products = await productService.GetPagedAsync(query, ct);
        var brands = await brandService.GetAllAsync(ct);


        var model = new ShopIndexViewModel
        {
            Categories = categories.Data ?? [],
            Brands = brands.Data ?? [],
            Products = products.Data ?? new PagedResult<ProductSummaryResponse>(),
            Query = query,
        };

        return View(model);
    }
}
