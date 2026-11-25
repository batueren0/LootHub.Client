using LootHub.Client.Application.DTOs.Auth;
using LootHub.Client.Application.Services.Interfaces;
using LootHub.Client.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LootHub.Client.Mvc.Controllers;

public class AccountController(IAuthService authService) : Controller
{
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "Home");

        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await authService.LoginAsync(new LoginRequest(model.Email, model.Password), ct);

        if (!result.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "Giriş yapılamadı.");
            return View(model);
        }

        await SignInAsync(result.Data!);

        if (Url.IsLocalUrl(model.ReturnUrl))
            return Redirect(model.ReturnUrl);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }

    private async Task SignInAsync(AuthResponse response)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, response.UserId.ToString()),
            new(ClaimTypes.Name, response.FirstName),
            new(ClaimTypes.Email, response.Email),
            new("access_token", response.Token)
        };

        foreach (var role in response.Roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = response.ExpiresAt }
            );
    }
}
