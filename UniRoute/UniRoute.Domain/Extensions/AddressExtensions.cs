using UniRoute.Domain.DTO.Request.Address;
using UniRoute.Domain.Entities;

namespace UniRoute.Domain.Extensions;

public static class AddressExtensions
{

    public static bool ApplyChanges(this Address address, UpdateAddressDTO updateAddressDTO)
    {
        bool isChanged = false;

        if (!string.IsNullOrWhiteSpace(updateAddressDTO.Street) &&
            !string.Equals(address.Street, updateAddressDTO.Street, StringComparison.Ordinal))
        {
            address.Street = updateAddressDTO.Street;
            isChanged = true;
        }

        if (!string.IsNullOrWhiteSpace(updateAddressDTO.PostalCode) &&
            !string.Equals(address.PostalCode, updateAddressDTO.PostalCode, StringComparison.Ordinal))
        {
            address.PostalCode = updateAddressDTO.PostalCode;
            isChanged = true;
        }

        if (updateAddressDTO.Latitude is not null && address.Latitude != updateAddressDTO.Latitude)
        {
            address.Latitude = updateAddressDTO.Latitude.Value;
            isChanged = true;
        }

        if (updateAddressDTO.Longitude is not null && address.Longitude != updateAddressDTO.Longitude)
        {
            address.Longitude = updateAddressDTO.Longitude.Value;
            isChanged = true;
        }

        return isChanged;
    }
}
