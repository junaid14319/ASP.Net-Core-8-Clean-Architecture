// SupplierController.cs
using AspNetCoreCA.Application.Features.PaymentDetail.Commands;
using AspNetCoreCA.Application.Features.PaymentDetail.Queries;
using AspNetCoreCA.Application.Features.PaymentDetail.Query;
using AspNetCoreCA.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



[ApiVersion("1")]
//[ApiController]
//[Route("api/paymentDetail")]
public class PaymentDetailController : BaseApiController
{
    private readonly IMediator _mediator;

    public PaymentDetailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaymentDetail([FromBody] CreatePaymentDetailCommand command)
    {
        var paymentDetailId = await _mediator.Send(command);
        return Ok(paymentDetailId);
    }

    [HttpPut("{paymentDetailId}")]
    public async Task<IActionResult> UpdateSupplier(int paymentDetailId, [FromBody] UpdatePaymentDetailCommand command)
    {
        command.paymentId = paymentDetailId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{paymentDetailId}")]
    public async Task<IActionResult> DeletePaymentDetail(int paymentDetailId)
    {
        var command = new DeletePaymentDetailCommand { PaymentId = paymentDetailId };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{paymentDetailId}")]
    public async Task<IActionResult> GetPaymentDetail(int paymentDetailId)
    {
        var query = new GetPaymentDetailQuery { PaymentDetailId = paymentDetailId };
        var paymentDetail = await _mediator.Send(query);

        if (paymentDetail == null)
            return NotFound();

        return Ok(paymentDetail);
    }
    [HttpGet]
    public async Task<IActionResult> GetPaymentDetail()
    {
        var query = new GetAllPaymentDetailQuery();
        var suppliers = await _mediator.Send(query);
        return Ok(suppliers);
    }
}
