﻿using FluentValidation;
using JewelrySalesSystem.Application.Users.GetStaffByPagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.GetCustomerByPagination
{
    public class GetCustomerByPaginationQueryValidator : AbstractValidator<GetCustomerByPaginationQuery>
    {
        public GetCustomerByPaginationQueryValidator()
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