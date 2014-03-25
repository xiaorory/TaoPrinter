using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace print.Models.DAL
{
    public class Sender : BaseObject
    {
        [Required]
        [Description("淘宝获取的卖家nick")]
        public string Sender_Nick { get; set; }
        [DisplayName("发件人姓名")]
        public string Sender_Name { get; set; }
        [DisplayName("发件人签名")]
        public string Sender_Signature { get; set; }
        [DisplayName("发件人电话")]
        public string Sender_Phone { get; set; }
        [DisplayName("发件人手机")]
        public string Sender_Mobile { get; set; }
        [DisplayName("发件人公司名称")]
        public string Sender_Company { get; set; }
        [DisplayName("发件人店铺名称")]
        public string Sender_ShopName { get; set; }
        [DisplayName("发件人地址")]
        public string Sender_Address { get; set; }
        [DisplayName("发件人邮编")]
        public string Sender_Zipcode { get; set; }
        [DisplayName("发件人店铺链接")]
        public string Sender_ShopUrl { get; set; }
        [DisplayName("发件人备注1")]
        public string Sender_Comment1 { get; set; }
        [DisplayName("发件人备注2")]
        public string Sender_Comment2 { get; set; }
        [Required]
        [DisplayName("会员有效期限")]
        public DateTime MembershipExpireDate { get; set; }

        public virtual SenderInfoPrintSettings SenderInfoPrintSettings { get; set; }
        public virtual ReceiverInfoPrintSettings ReceiverInfoPrintSettings { get; set; }
        public virtual ShipmentOrderPrintSettings ShipmentOrderPrintSettings { get; set; }
    }
}