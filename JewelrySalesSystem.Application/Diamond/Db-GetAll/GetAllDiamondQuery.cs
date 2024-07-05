using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamond.Db_GetAll
{
    public class GetAllDiamondQuery : IRequest<List<DiamondDto>>, IQuery
    {
        public GetAllDiamondQuery()
        {
            
        }
    }
}
