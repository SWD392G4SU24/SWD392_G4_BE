using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.VnPay.CreatePaymentUrl
{
    public class CreatePaymentUrlCommandHandler : IRequestHandler<CreatePaymentUrlCommand, string>
    {
        private readonly IConfiguration _configuration;
        private readonly IVnPayService _vnPayService;

        public CreatePaymentUrlCommandHandler(IConfiguration configuration, IVnPayService vnPayService)
        {
            _configuration = configuration;
            _vnPayService = vnPayService;
        }

        public Task<string> Handle(CreatePaymentUrlCommand request, CancellationToken cancellationToken)
        {
            var paymentUrl = _vnPayService.CreatePaymentUrl(request.Model, request.Context);
            return Task.FromResult(paymentUrl);
        }
    }
}
