using Microsoft.AspNetCore.Mvc;
using Prodavnica.Application.Vendor.Commands;
using Prodavnica.Application.Vendor.Queries;

namespace Prodavnica.Controllers;

[Route("vendor")]
public class VendorController : ApiControllerBase
{
    
    [HttpGet("GetVendor")]
    public async Task<ActionResult> GetVendor([FromQuery] GetVendorQuery query) => Ok(await Mediator.Send(query));
    [HttpPost("CreateVendor")]
    public async Task<ActionResult> CreateVendor(CreateVendorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpPut("UpdateVendor")]
    public async Task<ActionResult> UpdateVendor(UpdateVendorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpDelete("DeleteVendor")]
    public async Task<ActionResult> DeleteVendor(DeleteVendorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}