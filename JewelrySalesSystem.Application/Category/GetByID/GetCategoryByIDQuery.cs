using MediatR;

namespace JewelrySalesSystem.Application.Category.GetByID
{
    public class GetCategoryByIDQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }

        public GetCategoryByIDQuery(int id)
        {
            Id = id;
        }
    }
}
