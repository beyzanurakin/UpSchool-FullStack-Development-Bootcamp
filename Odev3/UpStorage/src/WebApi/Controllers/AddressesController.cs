using Application.Features.Addresses.Command.Add;
using Application.Features.Addresses.Command.Delete;
using Application.Features.Addresses.Command.HardDelete;
using Application.Features.Addresses.Command.Update;
using Application.Features.Addresses.Query.GetAll;
using Application.Features.Addresses.Query.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class AddressesController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(AddressAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(AddressUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(AddressDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("HardDelete")]
        public async Task<IActionResult> HardDeleteAsync(AddressHardDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(AddressGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await Mediator.Send(new AddressGetByIdQuery(id)));
        }
    }
}