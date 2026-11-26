using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Brand;

namespace LootHub.Client.Application.Services.Interfaces;

public interface IBrandService
{
    Task<ServiceResult<IReadOnlyList<BrandResponse>>> GetAllAsync(CancellationToken ct);
}
