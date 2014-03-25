using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace print.Models.DAL
{
    public abstract class BaseObject
    {
        [Required]
        [Description("淘宝获取的卖家user_id")]
        public long User_Id { get; set; }
    }
}