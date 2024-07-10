using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Diamond;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.GetByID
{
    public class GetDiamondByIdQuery : IRequest<DiamondDto>, IQuery
    {
        public GetDiamondByIdQuery()
        {
            
        }
        public int ID { get; set; }
    }
}
