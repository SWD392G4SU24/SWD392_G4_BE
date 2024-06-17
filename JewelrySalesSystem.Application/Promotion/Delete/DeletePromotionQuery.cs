﻿using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.DeletePromotion
{
    public class DeletePromotionQuery : IRequest<string>, IQuery
    {
        public DeletePromotionQuery(string id)
        {
            ID = id;
        }
        public required string ID { get; set; }
    }
}
