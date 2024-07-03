using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Functions
{
    public static class WageCost
    {
        public static decimal CalculateWageCost(int quantity, float? goldWeight, string diamondType)
        {
            decimal baseWageCost = 8;
            decimal wageCost = quantity * baseWageCost;

            wageCost += (decimal)goldWeight * 10;// mỗi gram vàng tăng thêm 10 đơn vị wage cost

            // Tăng thêm wage cost dựa trên loại kim cương
            if (diamondType.Contains("7ly") || diamondType.Contains("8ly") || diamondType.Contains("9ly"))
            {
                wageCost *= 0.5m; //kim cương loại cao cấp tăng 50% wage cost
            }

            return wageCost;
        }
    }
}
