using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using print.Models.DAL;

namespace print.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 保存发件人信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveSenderSettings(Sender sender)
        {
            return RedirectToAction("Index");
        }

    }
}
