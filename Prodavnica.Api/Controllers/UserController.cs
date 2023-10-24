using Microsoft.AspNetCore.Mvc;
using Prodavnica.Application.Administrator.Commands;
using Prodavnica.Application.Customer.Commands;
using Prodavnica.Application.Seller.Commands;
using Prodavnica.Application.User.Commands;

namespace Prodavnica.Controllers;

[Route("user")]
public class UserController : ApiControllerBase
{
    [HttpPost("CreateCustomer")]
    public async Task<ActionResult> CreateCustomer(CreateCustomer command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("CreateAdministrator")]
    public async Task<ActionResult> CreateAdministrator(CreateAdministrator command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("CreateSeller")]
    public async Task<ActionResult> CreateSeller(CreateSeller command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    /*[HttpPut("Update")]
    public async Task<ActionResult> Update(UpdateAdministratorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }*/
    
    [HttpDelete("Delete")]
    public async Task<ActionResult> Delete(DeleteUserCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    /*
    [HttpGet("PagedList")]
    public async Task<ActionResult> PagedList([FromQuery] GetUserPagedListQuery query) => Ok(await Mediator.Send(query));*/
}