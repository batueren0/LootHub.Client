using LootHub.Client.Application.Common;
using LootHub.Client.Application.Services;
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
        }).AddHttpMessageHandler<JwtAuthorizationHandler>();

        services.AddHttpContextAccessor();

        services.AddTransient<JwtAuthorizationHandler>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
