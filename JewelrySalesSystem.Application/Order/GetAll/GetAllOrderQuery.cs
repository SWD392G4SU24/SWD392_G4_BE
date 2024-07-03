using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.GetAll
{
    public class GetAllOrderQuery : IRequest<List<OrderDto>>, IQuery
    {
        public GetAllOrderQuery()
        {

        }
    }
}
