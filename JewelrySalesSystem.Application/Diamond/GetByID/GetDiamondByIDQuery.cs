﻿using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.GetByID
{
    public class GetDiamondByIDQuery : IRequest<DiamondDto>, IQuery
    {
        public required int ID { get; set; }
    }
}
