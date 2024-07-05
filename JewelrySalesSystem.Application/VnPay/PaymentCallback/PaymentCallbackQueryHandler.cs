using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities.VnPayModel;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.VnPay.PaymentCallback
{
    public class PaymentCallbackQueryHandler : IRequestHandler<PaymentCallbackQuery, PaymentResponseModel>
    {
        private readonly IConfiguration _configuration;
        private readonly IVnPayService _vnPayService;

        public PaymentCallbackQueryHandler(IConfiguration configuration, IVnPayService vnPayService)
        {
            _configuration = configuration;
            _vnPayService = vnPayService;
        }

        public Task<PaymentResponseModel> Handle(PaymentCallbackQuery request, CancellationToken cancellationToken)
        {
            var response = _vnPayService.PaymentExecute(request.Collections);
            return Task.FromResult(response);
        }    
    }
}
