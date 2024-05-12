// ProductsController.cs
using AspNetCoreCA.Application.Features.Products.Commands;
using AspNetCoreCA.Application.Features.Products.Queries;
using AspNetCoreCA.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiVersion("1")]

//[ApiController]
//[Route("api/products")]
public class ProductsController : BaseApiController
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);
        return Ok(productId);
    }

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateProduct(int productId, [FromBody] UpdateProductCommand command)
    {
        command.ProductId = productId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        var command = new DeleteProductCommand{ ProductId = productId };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        var query = new GetProductQuery { ProductId = productId };
        var product = await _mediator.Send(query);

        if (product == null)
            return NotFound();

        return Ok(product);
    }
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var query = new GetAllProductQuery();
        var products = await _mediator.Send(query);
        return Ok(products);
    }
}
