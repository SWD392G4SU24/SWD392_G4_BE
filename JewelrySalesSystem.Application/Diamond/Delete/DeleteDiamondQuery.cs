using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.Delete
{
    public class DeleteDiamondQuery : IRequest<string>, IQuery
    {
        public required int ID { get; set; }
    
    }
}
