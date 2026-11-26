using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Catalog;

namespace LootHub.Client.Application.Services.Interfaces;

public interface ICategoryService
{
    Task<ServiceResult<IReadOnlyList<CategoryResponse>>> GetAllAsync(CancellationToken ct);
}
