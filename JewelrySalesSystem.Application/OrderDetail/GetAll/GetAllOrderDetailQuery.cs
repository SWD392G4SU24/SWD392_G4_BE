using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.GetAll
{
    public class GetAllOrderDetailQuery : IRequest<List<OrderDetailDto>>, IQuery
    {
        public GetAllOrderDetailQuery() { }
    }
}
