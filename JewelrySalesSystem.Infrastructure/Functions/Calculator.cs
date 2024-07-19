using JewelrySalesSystem.Domain.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Functions
{
    public class Calculator : ICalculator
    {
        private decimal TyLeApGia { get; set; } = 1.2m;
        public decimal CalculateWageCost(float? goldWeight, string? diamondType)
        {
            decimal wageCost = 300000;
            if (goldWeight != null)
            {
                wageCost *= ((decimal)goldWeight / 100 * 40); // tiền gia công tăng 40% của cân vàng ( kh biết nựa )
            }

            // Tăng thêm wage cost dựa trên loại kim cương
            if ( !string.IsNullOrEmpty(diamondType) && (diamondType.Contains("7ly") || diamondType.Contains("8ly") || diamondType.Contains("9ly")) )
            {
                wageCost *= 1.5m; //kim cương loại cao cấp tăng 50% wage cost
            }

            return wageCost;
        }

        public decimal CalculateSellCost(float? goldWeight, decimal? gsCost, decimal? dsCost, decimal wageCost)
        {
            decimal result = 0;

            #region Giá vốn sản phẩm
            if (goldWeight.HasValue && gsCost.HasValue)
            {
                result += (decimal)goldWeight.Value * gsCost.Value;
            }

            result += wageCost;

            if (dsCost.HasValue)
            {
                result += dsCost.Value;
            }
            #endregion

            result *= TyLeApGia;

            return result;
        }

        public int CalculatePoint(decimal totalCost)
        {
            int point = (int)(totalCost * 0.002m) / 100;
            return point;
        }

        public decimal CalculateReorderCost(decimal diamondSellCost, decimal goldBuyCost, float goldWeight)
        {
            decimal result = 0;
            result += goldBuyCost * (decimal)goldWeight;
            result += diamondSellCost * 0.7m; //70%
            return result;
        }
    }
}
