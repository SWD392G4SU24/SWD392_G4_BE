﻿using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.DeletePromotion
{
    public class DeletePromotionCommand : IRequest<string>, ICommand
    {
        public DeletePromotionCommand(string iD)
        {
            ID = iD;
        }

        public  string ID { get; set; }
    }
}
