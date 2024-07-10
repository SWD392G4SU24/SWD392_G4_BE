using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.GetAll
{
    public class GetAllPaymentMethodQuery : IRequest<List<PaymentMethodDto>>
    {

    }
}
