// SupplierController.cs
using AspNetCoreCA.Application.Features.Supplier.Commands;
using AspNetCoreCA.Application.Features.Supplier.Queries;
using AspNetCoreCA.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[ApiVersion("1")]
//[ApiController]
//[Route("api/supplier")]
public class SupplierController : BaseApiController
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand command)
    {
        var supplierId = await _mediator.Send(command);
        return Ok(supplierId);
    }

    [HttpPut("{supplierId}")]
    public async Task<IActionResult> UpdateSupplier(int supplierId, [FromBody] UpdateSupplierCommand command)
    {
        command.SupplierId = supplierId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{supplierId}")]
    public async Task<IActionResult> DeleteSupplier(int supplierId)
    {
        var command = new DeleteSupplierCommand { SupplierId = supplierId };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{supplierId}")]
    public async Task<IActionResult> GetSupplier(int supplierId)
    {
        var query = new GetSupplierQuery { SupplierId = supplierId };
        var supplier = await _mediator.Send(query);

        if (supplier == null)
            return NotFound();

        return Ok(supplier);
    }
    [HttpGet]
    public async Task<IActionResult> GetSupplier()
    {
        var query = new GetAllSupplierQuery();
        var suppliers = await _mediator.Send(query);
        return Ok(suppliers);
    }
}
