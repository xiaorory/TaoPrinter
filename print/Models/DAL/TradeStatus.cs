using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace print.Models.DAL
{
    public enum TradeStatus
    {
        /// <summary>
        /// 等待卖家发货,即:买家已付款
        /// </summary>
        WAIT_SELLER_SEND_GOODS,
        /// <summary>
        /// 卖家部分发货
        /// </summary>
        SELLER_CONSIGNED_PART,
        /// <summary>
        /// 等待买家确认收货,即:卖家已发货
        /// </summary>
        WAIT_BUYER_CONFIRM_GOODS,
    }
}