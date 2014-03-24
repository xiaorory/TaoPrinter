using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace print.Models.DAL
{
    public class ReceiverInfoPrintSettings
    {
        [Required]
        [Description("淘宝获取的卖家user_id")]
        public int User_Id { get; set; }
        [DefaultValue(true)]
        [Description("是否打印淘宝获取的买家nick")]
        public bool printSender_Nick { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印收件人姓名")]
        public bool printSender_Name { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印收件人电话")]
        public bool printSender_Phone { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印收件人手机")]
        public bool printSender_Mobile { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印收件人地址")]
        public bool printSender_Address { get; set; }
        [DefaultValue(true)]
        [DisplayName("是否打印收件人邮编")]
        public bool printSender_Zipcode { get; set; }
        public virtual Sender Sender { get; set; }
    }
}