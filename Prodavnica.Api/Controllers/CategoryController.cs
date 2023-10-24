using Microsoft.AspNetCore.Mvc;
using Prodavnica.Application.Category.Commands;
using Prodavnica.Application.Category.Queries;

namespace Prodavnica.Controllers;
[Route("category")]
public class CategoryController: ApiControllerBase
{
    
    [HttpGet("GetOneCategory")]
    public async Task<ActionResult> GetCategory([FromQuery] GetCategoryQuery query) => Ok(await Mediator.Send(query));
    [HttpPost("CreateCategory")]
    public async Task<ActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    [HttpGet("PagedList")]
    public async Task<ActionResult> PagedList([FromQuery] GetCategoryPagedListQuery query) => Ok(await Mediator.Send(query));
    
    
}