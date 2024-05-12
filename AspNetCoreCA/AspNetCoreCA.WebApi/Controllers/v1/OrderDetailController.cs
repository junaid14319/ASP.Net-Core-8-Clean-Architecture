// SupplierController.cs
using AspNetCoreCA.Application.Features.OrderDetail.Commands;
using AspNetCoreCA.Application.Features.OrderDetail.Queries;
using AspNetCoreCA.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[ApiVersion("1")]
//[ApiController]
//[Route("api/orderDetail")]
public class OrderDetailController : BaseApiController
{
    private readonly IMediator _mediator;

    public OrderDetailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailCommand command)
    {
        var supplierId = await _mediator.Send(command);
        return Ok(supplierId);
    }

    [HttpPut("{orderDetailId}")]
    public async Task<IActionResult> UpdateOrderDetail(int orderDetailId, [FromBody] UpdateOrderDetailCommand command)
    {
        command.OrderDetailId = orderDetailId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{orderDetailId}")]
    public async Task<IActionResult> DeleteOrderDetail(int orderDetailId)
    {
        var command = new DeleteOrderDetailCommand { OrderDetailId = orderDetailId };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{orderDetailId}")]
    public async Task<IActionResult> GetOrderDetail(int orderDetailId)
    {
        var query = new GetOrderDetailQuery {OrderDetailId  = orderDetailId };
        var supplier = await _mediator.Send(query);

        if (supplier == null)
            return NotFound();

        return Ok(orderDetailId);
    }
    [HttpGet]
    public async Task<IActionResult> GetOrderDetail()
    {
        var query = new GetAllOrderDetailQuery();
        var orderDetails = await _mediator.Send(query);
        return Ok(orderDetails);
    }
}
