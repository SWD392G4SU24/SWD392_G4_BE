﻿using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.DeleteOrder
{
    public class DeleteOrdercommand : IRequest<string>, ICommand
    {
        public DeleteOrdercommand(string id)
        {
            Id = id;
        }

        public  string Id {  get; set; }
    
    }
}
