// ProductsController.cs
using AspNetCoreCA.Application.Features.Category.Commands;
using AspNetCoreCA.Application.Features.Category.Queries;
using AspNetCoreCA.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[ApiVersion("1")]
//[ApiController]
//[Route("api/category")]
public class CategoryController : BaseApiController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var categoryid = await _mediator.Send(command);
        return Ok(categoryid);
    }

    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategroyCommand command)
    {
        command.CategoryId = categoryId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        var command = new DeleteCategoryCommand { CategoryId = categoryId };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategory(int categoryId)
    {
        var query = new AspNetCoreCA.Application.Features.Category.Queries.GetCategoryQuery { Id = categoryId };
        var category = await _mediator.Send(query);

        if (category == null)
            return NotFound();

        return Ok(category);
    }
    [HttpGet]
    public async Task<IActionResult> GetCategoryAll()
    {
        var query = new AspNetCoreCA.Application.Features.Category.Queries.GetAllCategoryQuery();
        var categoryDto = await _mediator.Send(query);
        return Ok(categoryDto);
    }
}
