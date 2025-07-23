using UniRoute.Domain.DTO.Request.Address;
using UniRoute.Domain.DTO.Response.Address;

namespace UniRoute.Domain.Interfaces.Services;

public interface IAddressService
{
    Task<AddressDTO> CreateAsync(CreateAddressDTO createAddressDTO);

    Task<AddressDTO> UpdateAsync(UpdateAddressDTO updateAddressDTO);
}
