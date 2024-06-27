using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Application.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelrySalesSystem.Application.Product.GetProduct
{
    public class GetProductQuery : IRequest<List<ProductDto>>, IQuery
    {
    
    }
}
