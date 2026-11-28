using LootHub.Client.Application.DTOs.Address;
using LootHub.Client.Application.Services.Interfaces;
using LootHub.Client.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace LootHub.Client.Mvc.Controllers;

[Authorize]
public class AddressesController(IAddressService addressService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await addressService.GetAllAsync(ct);
        if (!result.IsSuccess)
        {
            TempData["Error"] = result.ErrorMessage;
        }
        return View(result.Data ?? []);
    }

    [HttpGet]
    public IActionResult Create() => View(new AddressFormViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddressFormViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await addressService.CreateAsync(new CreateAddressRequest(model.Title, model.Details, model.City, model.Country), ct);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "İşlem başarıyla tamamlanamadı!");
            return View(model);
        }
        TempData["Success"] = "Adres eklendi";
        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id, CancellationToken ct)
    {
        var address = await addressService.GetByIdAsync(id, ct);
        if (!address.IsSuccess)
            return NotFound();

        var addressReponse = new AddressFormViewModel
        {
            Title = address.Data!.Title,
            Details = address.Data!.Details,
            City = address.Data!.City,
            Country = address.Data!.Country,
        };

        return View(addressReponse);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, AddressFormViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await addressService.UpdateAsync(id, new UpdateAddressRequest(model.Title, model.Details, model.City, model.Country), ct);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "İşlem başarıyla tamamlanamadı!");
            return View(model);
        }
        TempData["Success"] = "Adres güncellendi";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await addressService.DeleteAsync(id, ct);
        if (!result.IsSuccess)
        {
            TempData["Error"] = "Adres silinemedi.";
            return RedirectToAction(nameof(Index));
        }
        TempData["Success"] = "Adres silindi.";
        return RedirectToAction(nameof(Index));
    }
}
