using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.Delete
{
    public class DeleteOrderDetailCommand : IRequest<string>, ICommand
    {
        public required string Id { get; set; }

    }
}
