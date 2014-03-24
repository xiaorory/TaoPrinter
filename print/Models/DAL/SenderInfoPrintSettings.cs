using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace print.Models.DAL
{
    public class SenderInfoPrintSettings
    {
        [Required]
        [Description("淘宝获取的卖家user_id")]
        public long User_Id { get; set; }
        [DefaultValue(true)]
        [Description("是否打印淘宝获取的卖家nick")]
        public bool printSender_Nick { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印发件人姓名")]
        public bool printSender_Name { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印发件人签名")]
        public bool printSender_Signature { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印发件人电话")]
        public bool printSender_Phone { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印发件人手机")]
        public bool printSender_Mobile { get; set; }
        [DefaultValue(false)]
        [DisplayName("是否打印发件人公司名称")]
        public bool printSender_Company { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印发件人店铺名称")]
        public bool printSender_ShopName { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印发件人地址")]
        public bool printSender_Address { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印发件人邮编")]
        public bool printSender_Zipcode { get; set; }
        [DefaultValue(false)]
        [DisplayName("是否打印发件人店铺链接")]
        public bool printSender_ShopUrl { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印发件人备注1")]
        public bool printSender_Comment1 { get; set; }
        [DefaultValue(false)]
        [DisplayName("是否打印发件人备注2")]
        public bool printSender_Comment2 { get; set; }
        public virtual Sender Sender { get; set; }
    }
}