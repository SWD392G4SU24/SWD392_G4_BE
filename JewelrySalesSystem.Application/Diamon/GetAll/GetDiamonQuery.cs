using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.GetAll
{
    public class GetDiamonQuery : IRequest<IEnumerable<DiamonDto>>, IQuery
    {
        public GetDiamonQuery() { }
    }
}
