using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using print.Models.BLL;
using print.Models.DAL;

namespace print.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            string sessionKey = Request.Params["top_session"];
            string error;
            Sender sender;
            if (!string.IsNullOrEmpty(sessionKey) && UserUtilizer.LoadSender(sessionKey, out error, out sender))
            {
                Session["SessionKey"] = sessionKey;
                Session["User_Id"] = sender.User_Id;
                Session["Sender_Nick"] = sender.Sender_Nick;
                return View();
            }
            else
            {
                return Content("获取用户信息失败");
            }
        }

    }
}
