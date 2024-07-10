using JewelrySalesSystem.Domain.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Functions
{
    public class WageCost
    {
        public WageCost() 
        {
        }

        public decimal CalculateWageCost(float? goldWeight, string? diamondType)
        {
            decimal wageCost = 300000;
            if(goldWeight != null)
            {
                wageCost *=  ((decimal)goldWeight / 100 * 40); // tiền gia công tăng 40% của cân vàng ( kh biết nựa )
            }

            // Tăng thêm wage cost dựa trên loại kim cương
            if (diamondType.Contains("7ly") || diamondType.Contains("8ly") || diamondType.Contains("9ly"))
            {
                wageCost *= 0.5m; //kim cương loại cao cấp tăng 50% wage cost
            }

            return wageCost;
        }
    }
}
