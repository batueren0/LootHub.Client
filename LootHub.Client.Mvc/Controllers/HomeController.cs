using LootHub.Client.Application.DTOs.Catalog;
using LootHub.Client.Application.Services.Interfaces;
using LootHub.Client.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LootHub.Client.Mvc.Controllers;

public class HomeController(
    ICategoryService categoryService,
    IProductService productService
    ) : Controller
{
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var categories = await categoryService.GetAllAsync(ct);
        var products = await productService.GetPagedAsync(new ProductQuery { PageSize = 8}  ,ct);

        var model = new HomeViewModel
        {
            Categories = categories.Data ?? [],
            Products = products.Data?.Items ?? []
        };

        return View(model);
    }
}
