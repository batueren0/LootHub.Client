using LootHub.Client.Application.Common;
using LootHub.Client.Application.DTOs.Address;

namespace LootHub.Client.Application.Services.Interfaces;

public interface IAddressService
{
    Task<ServiceResult<IReadOnlyList<AddressResponse>>> GetAllAsync(CancellationToken ct);
    Task<ServiceResult<AddressResponse>> GetByIdAsync(Guid id, CancellationToken ct);
    Task<ServiceResult<AddressResponse>> CreateAsync(CreateAddressRequest request, CancellationToken ct);
    Task<ServiceResult> UpdateAsync(Guid id, UpdateAddressRequest request, CancellationToken ct);
    Task<ServiceResult> DeleteAsync(Guid id, CancellationToken ct);
}
