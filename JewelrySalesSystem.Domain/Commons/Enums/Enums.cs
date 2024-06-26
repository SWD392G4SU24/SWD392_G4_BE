using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Commons.Enums
{
    public class Enums
    {
        //---STATUS---//
        public enum UserStatus
        {
            BANNED,
            UNVERIFIED,
            VERIFIED
        }
        public enum OrderStatus
        {
            PENDING,
            CANCELLED,
            PAID,
            COMPLETED,
            REFUNDED
        }
        public enum PromotionStatus
        {
            AVAILABLE,
            UNAVAILABLE,
            USED
        }
        public enum FormStatus
        {
            PENDING,
            APPROVED,
            REJECTED
        }
        //---TYPE---//
        public enum FormType
        {
            MAINTENANCE,
            REFUND,
            EXCHANGE
        }
        public enum OrderType
        {
            RE_ORDER,
            ONLINE_ORDER,
            AT_SHOP_ORDER
        }
    }
}
