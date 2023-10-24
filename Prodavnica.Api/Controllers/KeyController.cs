using Microsoft.AspNetCore.Mvc;
using Prodavnica.Application.Key.Commands;
using Prodavnica.Application.Key.Queries;

namespace Prodavnica.Controllers;

[Route("key")]
public class KeyController : ApiControllerBase
{
    [HttpGet("GetOneKey")]
    public async Task<ActionResult> GetKey([FromQuery] GetOneKeyQuery query) => Ok(await Mediator.Send(query));
    
    [HttpGet("List")]
    public async Task<ActionResult> List() => Ok(await Mediator.Send(new GetKeyListQuery()));
    
    [HttpPost("CreateKey")]
    public async Task<ActionResult> CreateKey(CreateKeyCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    [HttpGet("PagedList")]
    public async Task<ActionResult> PagedList([FromQuery] GetKeyPagedListQuery query) => Ok(await Mediator.Send(query));
}