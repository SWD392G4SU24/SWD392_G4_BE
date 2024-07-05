using FluentValidation;
using JewelrySalesSystem.Application.Users.GetCustomerByPagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.GetManagerByPagination
{
    public class GetManagerByPaginationQueryValidator : AbstractValidator<GetManagerByPaginationQuery>
    {
        public GetManagerByPaginationQueryValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
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
