using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.GoldBtmc.SaveToDb
{
    public class SaveGoldCommand :IRequest<string>, ICommand
    {
    }
}
