using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniRoute.API.Model.Address;
using UniRoute.Domain.DTO.Request.Address;
using UniRoute.Domain.DTO.Response.Address;
using UniRoute.Domain.Interfaces.Services;

namespace UniRoute.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController(IAddressService addressService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAddressModel createAddressModel)
        {
            CreateAddressDTO createAddressDTO = mapper.Map<CreateAddressDTO>(createAddressModel);

            AddressDTO addressDTO = await addressService.CreateAsync(createAddressDTO);

            return StatusCode(StatusCodes.Status201Created, addressDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateAddressModel updateAddressModel)
        {
            UpdateAddressDTO createAddressDTO = mapper.Map<UpdateAddressDTO>((id, updateAddressModel));

            AddressDTO addressDTO = await addressService.UpdateAsync(createAddressDTO);

            return StatusCode(StatusCodes.Status200OK, addressDTO);
        }
    }
}
