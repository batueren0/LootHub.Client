using LootHub.Client.Application.Common;
using LootHub.Client.Application.Services.Features;
using LootHub.Client.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LootHub.Client.Application;

public static class DependencyInjection 
{
    public static IServiceCollection AddClientApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var baseAddress = new Uri(configuration["Api:BaseUrl"] ?? throw new InvalidOperationException("Api:BaseUrl is missing in appsettings."));
        services.AddHttpClient(ApiClient.Name, client =>
        {
            client.BaseAddress = baseAddress;
        }).AddHttpMessageHandler<ApiUnavailableHandler>().AddHttpMessageHandler<JwtAuthorizationHandler>();

        services.AddHttpContextAccessor();

        services.AddTransient<ApiUnavailableHandler>();
        services.AddTransient<JwtAuthorizationHandler>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
