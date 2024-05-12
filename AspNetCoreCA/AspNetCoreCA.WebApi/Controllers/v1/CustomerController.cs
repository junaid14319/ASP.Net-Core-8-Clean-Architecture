// ProductsController.cs
using AspNetCoreCA.Application.Features.Customer.Commands;
using AspNetCoreCA.Application.Features.Customer.Queries;
using AspNetCoreCA.Application.Features.Customer.Query;
using AspNetCoreCA.Application.Features.Products.Commands;
using AspNetCoreCA.Application.Features.Products.Queries;
using AspNetCoreCA.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[ApiVersion("1")]
//[ApiController]
//[Route("api/customer")]
public class CustomerController : BaseApiController
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        var productId = await _mediator.Send(command);
        return Ok(productId);
    }

    [HttpPut("{customerId}")]
    public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] UpdateCustomerCommand command)
    {
        command.CustomerId = customerId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{customerId}")]
    public async Task<IActionResult> DeleteCustomer(int customerId)
    {
        var command = new DeleteCustomerCommand { CustomerId = customerId };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCustomer(int customerId)
    {
        var query = new GetCustomerQuery { CustomerId = customerId };
        var customer = await _mediator.Send(query);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
    [HttpGet]
    public async Task<IActionResult> GetCustomer()
    {
        var query = new GetAllCustomerQuery();
        var customer = await _mediator.Send(query);
        return Ok(customer);
    }
}
