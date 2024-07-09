using JewelrySalesSystem.Application.VnPay.CreatePaymentUrl;
using JewelrySalesSystem.Application.VnPay.PaymentCallback;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities.VnPayModel;
using JewelrySalesSystem.Infrastructure.ExternalService.VnPay;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jewelry_Sales_System.API.Controllers
{
    [ApiController]
    //[Authorize]
    public class VnPayController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IVnPayService _vnPayService;

        public VnPayController(IMediator mediator, IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
            _mediator = mediator;
        }

        [HttpPost("create-payment-url")]
        public async Task<IActionResult> CreatePaymentUrl([FromBody] PaymentInformationModel model)
        {
            var command = new CreatePaymentUrlCommand(model, HttpContext);
            var paymentUrl = await _mediator.Send(command);
            return Ok(paymentUrl);
        }

        [HttpGet("payment-callback")]
        public async Task<IActionResult> PaymentCallback()
        {
            var response = await _mediator.Send(new PaymentCallbackQuery(Request.Query));
            return Ok(new JsonResponse<PaymentResponseModel>(response));
        }
    }
}
