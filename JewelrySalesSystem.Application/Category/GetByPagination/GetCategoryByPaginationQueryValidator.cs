using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Category.GetByPagination
{
    public class GetCategoryByPaginationQueryValidator : AbstractValidator<GetCategoryByPaginationQuery>
    {
        public GetCategoryByPaginationQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.PageSize).NotEmpty()
                .NotNull()
                .WithMessage("PageSize can't be null or empty");

            RuleFor(x => x.PageNumber).NotEmpty()
                .NotNull()
                .WithMessage("PageNumber can't be null or empty");
        }
    }
}
