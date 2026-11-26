using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Catalog;

namespace LootHub.Client.Application.Services.Interfaces;

public interface IProductService
{
    Task<ServiceResult<PagedResult<ProductSummaryResponse>>> GetPagedAsync(ProductQuery query, CancellationToken ct = default);
}
