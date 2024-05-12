// ProductsController.cs
using AspNetCoreCA.Application.Features.Order.Commands;
using AspNetCoreCA.Application.Features.Order.Queries;
using AspNetCoreCA.Application.Features.Products.Commands;
using AspNetCoreCA.Application.Features.Products.Queries;
using AspNetCoreCA.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiVersion("1")]


//[ApiController]
//[Route("api/order")]
public class OrderController : BaseApiController
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var orderId = await _mediator.Send(command);
        return Ok(orderId);
    }

    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] UpdateOrderCommand command)
    {
        command.OrderId = orderId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder(int orderId)
    {
        var command = new DeleteOrderCommand { OrderId = orderId };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetorderId(int orderId)
    {
        var query = new GetOrderQuery { OrderId = orderId };
        var order = await _mediator.Send(query);

        if (order == null)
            return NotFound();

        return Ok(order);
    }
    [HttpGet]
    public async Task<IActionResult> GetOrder()
    {
        var query = new GetAllOrderQuery();
        var orderes = await _mediator.Send(query);
        return Ok(orderes);
    }
}
