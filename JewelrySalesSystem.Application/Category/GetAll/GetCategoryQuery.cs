using MediatR;
using System.Collections.Generic;

namespace JewelrySalesSystem.Application.Category.GetCategory
{
    public class GetCategoryQuery : IRequest<List<CategoryDto>>
    {
    }
}
