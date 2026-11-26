using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Brand;
using LootHub.Client.Application.Services.Interfaces;

namespace LootHub.Client.Application.Services.Features;

public class BrandService(IHttpClientFactory httpClientFactory) : IBrandService
{
    public async Task<ServiceResult<IReadOnlyList<BrandResponse>>> GetAllAsync(CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.GetAsync("brands", ct);

        return await response.ToResultAsync<IReadOnlyList<BrandResponse>>();
    }
}
