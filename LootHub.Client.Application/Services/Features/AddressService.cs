using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Address;
using LootHub.Client.Application.Services.Interfaces;
using System.Net.Http.Json;

namespace LootHub.Client.Application.Services.Features;

public class AddressService(IHttpClientFactory httpClientFactory) : IAddressService
{
    public async Task<ServiceResult<AddressResponse>> CreateAsync(CreateAddressRequest request, CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.PostAsJsonAsync("addresses", request, ct);

        return await response.ToResultAsync<AddressResponse>();
    }

    public async Task<ServiceResult> DeleteAsync(Guid id, CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.DeleteAsync($"addresses/{id}", ct);

        return await response.ToResultAsync();
    }

    public async Task<ServiceResult<IReadOnlyList<AddressResponse>>> GetAllAsync(CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.GetAsync("addresses", ct);

        return await response.ToResultAsync<IReadOnlyList<AddressResponse>>();
    }

    public async Task<ServiceResult<AddressResponse>> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.GetAsync($"addresses/{id}", ct);

        return await response.ToResultAsync<AddressResponse>();
    }

    public async Task<ServiceResult> UpdateAsync(Guid id, UpdateAddressRequest request, CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient(ApiClient.Name);
        var response = await client.PutAsJsonAsync($"addresses/{id}", request ,ct);

        return await response.ToResultAsync();
    }
}
