﻿using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetById
{
    public class GetByIDQuery : IRequest<PromotionDto>, IQuery
    {
        public required string Id { get; set; }
    }
}