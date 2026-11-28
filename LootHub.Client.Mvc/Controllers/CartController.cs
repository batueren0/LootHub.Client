using LootHub.Client.Application.Services.Interfaces;
using LootHub.Client.Mvc.Models;
using LootHub.Client.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace LootHub.Client.Mvc.Controllers;

public class CartController(ICartService cartService, IProductService productService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var items = cartService.GetItems();
        return View(items);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(string slug, int quantity, string? returnUrl, CancellationToken ct)
    {
        if (quantity < 1) quantity = 1;
        var result = await productService.GetBySlugAsync(slug, ct);
        if (!result.IsSuccess)
        {
            TempData["Error"] = "Ürün bulunamadı.";
            return RedirectBack(returnUrl);
        }
        if(result.Data!.Stock <= 0)
        {
            TempData["Error"] = "Bu ürün tükendi";
            return RedirectBack(returnUrl);
        }

        var cartItem = new CartItem
        {
            ProductId = result.Data!.Id,
            Slug = result.Data.Slug,
            Name = result.Data.Name,
            BrandName = result.Data.BrandName,
            CategoryName = result.Data.CategoryName,
            ImageUrl = result.Data.ImageUrl,
            UnitPrice = result.Data.Price,
            Stock = result.Data.Stock,
            Quantity = quantity,
        };

        cartService.Add(cartItem);
        TempData["Success"] = "Ürün sepete eklendi.";
        return RedirectBack(returnUrl);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Guid productId, int quantity)
    {
        cartService.UpdateQuantity(productId, quantity);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(Guid productId)
    {
        cartService.Remove(productId);
        return RedirectToAction(nameof(Index));
    }

    private IActionResult RedirectBack(string? returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction(nameof(Index));
    }
}
