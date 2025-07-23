using AutoMapper;
using UniRoute.Domain.DTO.Request.Address;
using UniRoute.Domain.DTO.Response.Address;
using UniRoute.Domain.Entities;
using UniRoute.Domain.Exceptions;
using UniRoute.Domain.Extensions;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Domain.Interfaces.Services;
using UniRoute.Domain.Messages;

namespace UniRoute.Application.Services;

public class AddressService(IUnitOfWork unitOfWork, IMapper mapper) : IAddressService
{
    public async Task<AddressDTO> CreateAsync(CreateAddressDTO createAddressDTO)
    {
        await unitOfWork.BeginTransactionAsync();

        try
        {
            Student? student = await unitOfWork.StudentRepository.GetByIdAsync(createAddressDTO.StudentId)
                ?? throw new NotFoundException(BusinessMessages.Student_Not_Found);

            Address? address = await unitOfWork.AddressRepository.GetByStudentIdAsync(student.Id);

            if (address is not null)
                throw new BadRequestException(BusinessMessages.Address_Already_Exists);

            address = mapper.Map<Address>(createAddressDTO);

            await unitOfWork.AddressRepository.CreateAsync(address);

            await unitOfWork.CommitAsync();

            AddressDTO addressDTO = mapper.Map<AddressDTO>(address);

            return addressDTO;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<AddressDTO> UpdateAsync(UpdateAddressDTO updateAddressDTO)
    {
        await unitOfWork.BeginTransactionAsync();

        try
        {
            Address? address = await unitOfWork.AddressRepository.GetByIdAsync(updateAddressDTO.Id, isTracking: false)
                ?? throw new NotFoundException(BusinessMessages.Address_Not_Found);

            if (address.ApplyChanges(updateAddressDTO))
            {
                unitOfWork.AddressRepository.Update(address);
            }

            await unitOfWork.CommitAsync();

            AddressDTO addressDTO = mapper.Map<AddressDTO>(address);

            return addressDTO;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}
