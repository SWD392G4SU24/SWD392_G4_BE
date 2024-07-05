using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Form.GetByID
{
    public class GetFormByIDQuery : IRequest<FormDto>, IQuery
    {
        public GetFormByIDQuery(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
    }
}
