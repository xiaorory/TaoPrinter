using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace print.Models.DAL
{
    public class ShipmentOrderPrintSettings : BaseObject
    {
        [DefaultValue(true)]
        [DisplayName("是否打印发货日期")]
        public bool printDeliveryDate { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印买家淘宝昵称")]
        public bool printBuyerNick { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印买家留言")]
        public bool printBuyerComment { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印点单号")]
        public bool printTradeId { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印商品编号")]
        public bool printItemId { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印商品名称")]
        public bool printItemName { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印商品数量")]
        public bool printItemQuantity { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印商品单价")]
        public bool printItemPrice { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印商品优惠")]
        public bool printItemDiscount { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印商品总价")]
        public bool printTotalPrice { get; set; }
        [DisplayName("发货单标题")]
        public string title { get; set; }
        [DisplayName("发货单备注")]
        public string comment { get; set; }
        public virtual Sender Sender { get; set; }
    }
}