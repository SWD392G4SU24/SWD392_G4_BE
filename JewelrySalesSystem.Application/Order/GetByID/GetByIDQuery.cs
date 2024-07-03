using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.GetByID
{
    public class GetByIDQuery : IRequest<OrderDto>, IQuery
    {
        public GetByIDQuery(string id)
        {
            Id = id;
        }

        public string Id {  get; set; }
  
    }
}
