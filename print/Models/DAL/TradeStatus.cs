using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace print.Models.DAL
{
    public class TradeStatus
    {
        /// <summary>
        /// 等待卖家发货,即:买家已付款
        /// </summary>
        public static string WAIT_SELLER_SEND_GOODS { get { return "WAIT_SELLER_SEND_GOODS"; } }
        /// <summary>
        /// 卖家部分发货
        /// </summary>
        public static string SELLER_CONSIGNED_PART { get { return "SELLER_CONSIGNED_PART"; } }
        /// <summary>
        /// 等待买家确认收货,即:卖家已发货
        /// </summary>
        public static string WAIT_BUYER_CONFIRM_GOODS { get { return "WAIT_BUYER_CONFIRM_GOODS"; } }
    }
}