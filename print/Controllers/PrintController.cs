using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using print.Models.BLL;
using Top.Api.Domain;
using print.Models.DAL;
using print.Models.Common;

namespace print.Controllers
{
    public class PrintController : Controller
    {
        //
        // GET: /Print/

        public ActionResult Index(int tradeId)
        {
            return RedirectToAction("Preview", new { tradeId = tradeId });
        }

        /// <summary>
        /// 预览订单打印
        /// </summary>
        /// <returns></returns>
        public ActionResult Preview(int tradeId)
        {
            string error = "";
            TradePrintInfo tradePrintInfo = new TradePrintInfo();
            Trade trade;
            if (TradeUtilizer.GetTrade(tradeId, Session["SessionKey"].ToString(), out trade))
            {
                tradePrintInfo.tradeInfo = trade;
                Sender sender = ServiceUtilizer.GetCurrentEntity<Sender>(Session[Constants.User_Id]);
                if (null != sender)
                {
                    SenderInfoPrintSettings senderInfoPrintSettings = ServiceUtilizer.GetCurrentEntity<SenderInfoPrintSettings>(Session[Constants.User_Id]);
                    if (null == senderInfoPrintSettings)//如果没有，则按照默认值使用
                    {
                        senderInfoPrintSettings = new SenderInfoPrintSettings();
                    }
                    tradePrintInfo.senderInfoPrintSettings = senderInfoPrintSettings;

                    ReceiverInfoPrintSettings receiverInfoPrintSettings = ServiceUtilizer.GetCurrentEntity<ReceiverInfoPrintSettings>(Session[Constants.User_Id]);
                    if (null == receiverInfoPrintSettings)//如果没有，则按照默认值使用
                    {
                        receiverInfoPrintSettings = new ReceiverInfoPrintSettings();
                    }
                    tradePrintInfo.receiverInfoPrintSettings = receiverInfoPrintSettings;

                    return View(tradePrintInfo);
                }
                else
                {
                    error = ServiceUtilizer.ErrorMsg;
                }
            }
            return Content(error);
        }

        /// <summary>
        /// 直接订单打印
        /// </summary>
        /// <returns></returns>
        public ActionResult Print(int tradeId)
        {
            string error = "";
            TradePrintInfo tradePrintInfo = new TradePrintInfo();
            Trade trade;
            if (TradeUtilizer.GetTrade(tradeId, Session["SessionKey"].ToString(), out trade))
            {
                tradePrintInfo.tradeInfo = trade;
                Sender sender = ServiceUtilizer.GetCurrentEntity<Sender>(Session[Constants.User_Id]);
                if (null != sender)
                {
                    SenderInfoPrintSettings senderInfoPrintSettings = ServiceUtilizer.GetCurrentEntity<SenderInfoPrintSettings>(Session[Constants.User_Id]);
                    if (null == senderInfoPrintSettings)//如果没有，则按照默认值使用
                    {
                        senderInfoPrintSettings = new SenderInfoPrintSettings();
                    }
                    tradePrintInfo.senderInfoPrintSettings = senderInfoPrintSettings;

                    ReceiverInfoPrintSettings receiverInfoPrintSettings = ServiceUtilizer.GetCurrentEntity<ReceiverInfoPrintSettings>(Session[Constants.User_Id]);
                    if (null == receiverInfoPrintSettings)//如果没有，则按照默认值使用
                    {
                        receiverInfoPrintSettings = new ReceiverInfoPrintSettings();
                    }
                    tradePrintInfo.receiverInfoPrintSettings = receiverInfoPrintSettings;

                    return View(tradePrintInfo);
                }
                else
                {
                    error = ServiceUtilizer.ErrorMsg;
                }
            }
            return Content(error);
        }

        /// <summary>
        /// 订货单打印预览
        /// </summary>
        /// <returns></returns>
        public ActionResult ShipmentOrderPreview(int tradeId)
        {
            string error = "";
            ShipmentOrderPrintInfo shipmentOrderPrintInfo = new ShipmentOrderPrintInfo();
            Trade trade;
            if (TradeUtilizer.GetTrade(tradeId, Session["SessionKey"].ToString(), out trade))
            {
                shipmentOrderPrintInfo.tradeInfo = trade;

                ShipmentOrderPrintSettings shipmentOrderPrintSettings = ServiceUtilizer.GetCurrentEntity<ShipmentOrderPrintSettings>(Session[Constants.User_Id]);
                if (null == shipmentOrderPrintSettings)//如果没有，则按照默认值使用
                {
                    shipmentOrderPrintSettings = new ShipmentOrderPrintSettings();
                }
                shipmentOrderPrintInfo.shipmentOrderPrintSettings = shipmentOrderPrintSettings;

                return View(shipmentOrderPrintInfo);

            }
            return Content(error);
        }

        /// <summary>
        /// 订货单直接打印
        /// </summary>
        /// <returns></returns>
        public ActionResult ShipmentOrderPrint(int tradeId)
        {
            string error = "";
            ShipmentOrderPrintInfo shipmentOrderPrintInfo = new ShipmentOrderPrintInfo();
            Trade trade;
            if (TradeUtilizer.GetTrade(tradeId, Session["SessionKey"].ToString(), out trade))
            {
                shipmentOrderPrintInfo.tradeInfo = trade;

                ShipmentOrderPrintSettings shipmentOrderPrintSettings = ServiceUtilizer.GetCurrentEntity<ShipmentOrderPrintSettings>(Session[Constants.User_Id]);
                if (null == shipmentOrderPrintSettings)//如果没有，则按照默认值使用
                {
                    shipmentOrderPrintSettings = new ShipmentOrderPrintSettings();
                }
                shipmentOrderPrintInfo.shipmentOrderPrintSettings = shipmentOrderPrintSettings;

                return View(shipmentOrderPrintInfo);

            }
            return Content(error);
        }

    }
}
