using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using print.Models.DAL;
using print.Models.BLL;

namespace print.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult Index()
        {
            return View("ViewSenderSettings");
        }

        /// <summary>
        /// 查看发件人信息设置
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewSenderSettings()
        {
            string error;
            int user_id;
            Sender sender;
            IService<Sender> senderService = ServiceUtilizer.GetCurrentService<Sender>();
            if (int.TryParse(Session["User_Id"].ToString(), out user_id))
            {
                if (senderService.LoadEntity(p => p.User_Id == user_id, out sender))
                {
                    if (null != sender)
                    {
                        return View(sender);
                    }
                    else
                    {
                        error = "用户不存在";
                    }
                }
                else
                {
                    error = senderService.ErrorMsg;
                }
            }
            else
            {
                error = "未登录";
            }
            return Content(error);
        }

        /// <summary>
        /// 打开发件人信息设置页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeSenderSettings()
        {
            string error;
            int user_id;
            Sender sender;
            IService<Sender> senderService = ServiceUtilizer.GetCurrentService<Sender>();
            if (int.TryParse(Session["User_Id"].ToString(), out user_id))
            {
                if (senderService.LoadEntity(p => p.User_Id == user_id, out sender))
                {
                    if (null != sender)
                    {
                        return View(sender);
                    }
                    else
                    {
                        error = "用户不存在";
                    }
                }
                else
                {
                    error = senderService.ErrorMsg;
                }
            }
            else
            {
                error = "未登录";
            }
            return Content(error);
        }

        /// <summary>
        /// 保存更改的发件人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeSenderSettings(Sender sender)
        {
            IService<Sender> senderService = ServiceUtilizer.GetCurrentService<Sender>();
            if (senderService.UpdateEntity(sender))
            {
                return RedirectToAction("ViewSenderSettings");
            }
            else
            {
                return Content(senderService.ErrorMsg);
            }
        }

        /// <summary>
        /// 查看发件人信息的打印设置
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewSenderInfoPrintSettings()
        {
            string error;
            int user_id;
            SenderInfoPrintSettings senderInfoPrintSettings;
            IService<SenderInfoPrintSettings> senderService = ServiceUtilizer.GetCurrentService<SenderInfoPrintSettings>();
            if (int.TryParse(Session["User_Id"].ToString(), out user_id))
            {
                if (senderService.LoadEntity(p => p.User_Id == user_id, out senderInfoPrintSettings))
                {
                    if (null != senderInfoPrintSettings)
                    {
                        return View(senderInfoPrintSettings);
                    }
                    else
                    {
                        error = "用户不存在";
                    }
                }
                else
                {
                    error = senderService.ErrorMsg;
                }
            }
            else
            {
                error = "未登录";
            }
            return Content(error);
        }

        /// <summary>
        /// 打开发件人信息打印设置页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeSenderInfoPrintSettings()
        {
            string error;
            int user_id;
            SenderInfoPrintSettings senderInfoPrintSettings;
            IService<SenderInfoPrintSettings> senderService = ServiceUtilizer.GetCurrentService<SenderInfoPrintSettings>();
            if (int.TryParse(Session["User_Id"].ToString(), out user_id))
            {
                if (senderService.LoadEntity(p => p.User_Id == user_id, out senderInfoPrintSettings))
                {
                    if (null != senderInfoPrintSettings)
                    {
                        return View(senderInfoPrintSettings);
                    }
                    else
                    {
                        error = "用户不存在";
                    }
                }
                else
                {
                    error = senderService.ErrorMsg;
                }
            }
            else
            {
                error = "未登录";
            }
            return Content(error);
        }

        /// <summary>
        /// 保存更改的发件人信息打印设置
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeSenderInfoPrintSettings(SenderInfoPrintSettings sender)
        {
            IService<SenderInfoPrintSettings> senderService = ServiceUtilizer.GetCurrentService<SenderInfoPrintSettings>();
            if (senderService.UpdateEntity(sender))
            {
                return RedirectToAction("ViewSenderInfoPrintSettings");
            }
            else
            {
                return Content(senderService.ErrorMsg);
            }
        }

        /// <summary>
        /// 查看收件人信息的打印设置
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewReceiverInfoPrintSettings()
        {
            string error;
            int user_id;
            ReceiverInfoPrintSettings receiverInfoPrintSettings;
            IService<ReceiverInfoPrintSettings> senderService = ServiceUtilizer.GetCurrentService<ReceiverInfoPrintSettings>();
            if (int.TryParse(Session["User_Id"].ToString(), out user_id))
            {
                if (senderService.LoadEntity(p => p.User_Id == user_id, out receiverInfoPrintSettings))
                {
                    if (null != receiverInfoPrintSettings)
                    {
                        return View(receiverInfoPrintSettings);
                    }
                    else
                    {
                        error = "用户不存在";
                    }
                }
                else
                {
                    error = senderService.ErrorMsg;
                }
            }
            else
            {
                error = "未登录";
            }
            return Content(error);
        }

        /// <summary>
        /// 打开收件人信息的打印设置页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeReceiverInfoPrintSettings()
        {
            string error;
            int user_id;
            ReceiverInfoPrintSettings receiverInfoPrintSettings;
            IService<ReceiverInfoPrintSettings> senderService = ServiceUtilizer.GetCurrentService<ReceiverInfoPrintSettings>();
            if (int.TryParse(Session["User_Id"].ToString(), out user_id))
            {
                if (senderService.LoadEntity(p => p.User_Id == user_id, out receiverInfoPrintSettings))
                {
                    if (null != receiverInfoPrintSettings)
                    {
                        return View(receiverInfoPrintSettings);
                    }
                    else
                    {
                        error = "用户不存在";
                    }
                }
                else
                {
                    error = senderService.ErrorMsg;
                }
            }
            else
            {
                error = "未登录";
            }
            return Content(error);
        }

        /// <summary>
        /// 保存收件人信息的打印设置
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeReceiverInfoPrintSettings(ReceiverInfoPrintSettings receiverInfoPrintSettings)
        {
            IService<ReceiverInfoPrintSettings> ReceiverInfoPrintSettingsService = ServiceUtilizer.GetCurrentService<ReceiverInfoPrintSettings>();
            if (ReceiverInfoPrintSettingsService.UpdateEntity(receiverInfoPrintSettings))
            {
                return RedirectToAction("ViewReceiverInfoPrintSettings");
            }
            else
            {
                return Content(ReceiverInfoPrintSettingsService.ErrorMsg);
            }
        }

        /// <summary>
        /// 查看收件人信息的打印设置
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewShipmentOrderPrintSettings()
        {
            string error;
            int user_id;
            ShipmentOrderPrintSettings shipmentOrderPrintSettings;
            IService<ShipmentOrderPrintSettings> senderService = ServiceUtilizer.GetCurrentService<ShipmentOrderPrintSettings>();
            if (int.TryParse(Session["User_Id"].ToString(), out user_id))
            {
                if (senderService.LoadEntity(p => p.User_Id == user_id, out shipmentOrderPrintSettings))
                {
                    if (null != shipmentOrderPrintSettings)
                    {
                        return View(shipmentOrderPrintSettings);
                    }
                    else
                    {
                        error = "用户不存在";
                    }
                }
                else
                {
                    error = senderService.ErrorMsg;
                }
            }
            else
            {
                error = "未登录";
            }
            return Content(error);
        }

        /// <summary>
        /// 打开收件人信息的打印设置页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeShipmentOrderPrintSettings()
        {
            string error;
            int user_id;
            ShipmentOrderPrintSettings shipmentOrderPrintSettings;
            IService<ShipmentOrderPrintSettings> senderService = ServiceUtilizer.GetCurrentService<ShipmentOrderPrintSettings>();
            if (int.TryParse(Session["User_Id"].ToString(), out user_id))
            {
                if (senderService.LoadEntity(p => p.User_Id == user_id, out shipmentOrderPrintSettings))
                {
                    if (null != shipmentOrderPrintSettings)
                    {
                        return View(shipmentOrderPrintSettings);
                    }
                    else
                    {
                        error = "用户不存在";
                    }
                }
                else
                {
                    error = senderService.ErrorMsg;
                }
            }
            else
            {
                error = "未登录";
            }
            return Content(error);
        }

        /// <summary>
        /// 保存收件人信息的打印设置
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeShipmentOrderPrintSettings(ShipmentOrderPrintSettings shipmentOrderPrintSettings)
        {
            IService<ShipmentOrderPrintSettings> ReceiverInfoPrintSettingsService = ServiceUtilizer.GetCurrentService<ShipmentOrderPrintSettings>();
            if (ReceiverInfoPrintSettingsService.UpdateEntity(shipmentOrderPrintSettings))
            {
                return RedirectToAction("ViewShipmentOrderPrintSettings");
            }
            else
            {
                return Content(ReceiverInfoPrintSettingsService.ErrorMsg);
            }
        }
    }
}
