using JewelrySalesSystem.Domain.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Functions
{
    public interface ICalculator
    {
        decimal CalculateWageCost(float? goldWeight, string? diamondType);
        decimal CalculateSellCost(float? goldWeight, decimal? gsCost, decimal? dsCost, decimal wageCost);
        int CalculatePoint(decimal totalCost);
    }
}
