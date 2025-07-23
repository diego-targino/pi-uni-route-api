using AutoMapper;
using UniRoute.API.Model.Address;
using UniRoute.Domain.DTO.Request.Address;
using UniRoute.Domain.DTO.Response.Address;
using UniRoute.Domain.Entities;

namespace UniRoute.API.MappingProfiles;

public class AddressMappingProfile : Profile
{
    public AddressMappingProfile()
    {
        CreateMap<CreateAddressModel, CreateAddressDTO>();

        CreateMap<(long id, UpdateAddressModel UpdateAddressModel), UpdateAddressDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.UpdateAddressModel.Street))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.UpdateAddressModel.PostalCode))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.UpdateAddressModel.Latitude))
            .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.UpdateAddressModel.Longitude));

        CreateMap<Address, AddressDTO>();
        CreateMap<CreateAddressDTO, Address>();
    }
}
