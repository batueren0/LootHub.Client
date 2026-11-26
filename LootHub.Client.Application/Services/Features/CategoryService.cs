using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Catalog;
using LootHub.Client.Application.Services.Interfaces;
namespace LootHub.Client.Application.Services.Features;

public class CategoryService(IHttpClientFactory httpClientFactory) : ICategoryService
{
    public async Task<ServiceResult<IReadOnlyList<CategoryResponse>>> GetAllAsync(CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.GetAsync("categories", ct);

        return await response.ToResultAsync<IReadOnlyList<CategoryResponse>>();
    }
}
