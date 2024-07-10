using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Category.GetByID
{
    public class GetCategoryByIDQuery : IRequest<CategoryDto>, IQuery
    {
        public int Id { get; set; }

        public GetCategoryByIDQuery(int id)
        {
            Id = id;
        }
    }
}
