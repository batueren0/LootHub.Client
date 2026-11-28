using LootHub.Client.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LootHub.Client.Mvc.ViewComponents;

public class CategoryMenuViewComponent(ICategoryService categoryService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await categoryService.GetAllAsync(HttpContext.RequestAborted);

        return View(categories.Data ?? []);
    }
}
