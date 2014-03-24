using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using print.Models.Common;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api;
using Top.Api.Domain;
using print.Models.DAL;

namespace print.Models.BLL
{
    public class TradeUtilizer
    {
        /// <summary>
        /// 获取某个订单的详情
        /// </summary>
        /// <param name="tid">trade id</param>
        /// <param name="sessionKey"></param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetTrade(int tid,string sessionKey,out string error,out Trade trade)
        {
            bool isSuccess = false;
            error = string.Empty;
            trade = null;
            try
            {
                ITopClient client = new DefaultTopClient(Constants.ApiUrl, Constants.AppKey, Constants.AppSecret);
                TradeFullinfoGetRequest req = new TradeFullinfoGetRequest();
                req.Fields = "buyer_nick,receiver_state,receiver_city,receiver_address,receiver_mobile";
                req.Tid = tid;
                TradeFullinfoGetResponse rsp = client.Execute(req, sessionKey);
                trade = rsp.Trade;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return isSuccess;
        }

        /// <summary>
        /// 获取三个月之内未发货的订单
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetUndeliveredTrades(string sessionKey,out string error,out List<Trade> trades)
        {
            return GetUndeliveredTrades(sessionKey, DateTime.Now.AddMonths(-3), DateTime.Now, out error, out trades);
        }

        /// <summary>
        /// 获取三个月之内部分发货的订单
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetConSignedTrades(string sessionKey, out string error, out List<Trade> trades)
        {
            return GetConSignedTrades(sessionKey, DateTime.Now.AddMonths(-3), DateTime.Now, out error, out trades);
        }

        /// <summary>
        /// 获取三个月之内已发货但买家未确认收货的订单
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetWaitConfirmTrades(string sessionKey, out string error, out List<Trade> trades)
        {
            return GetWaitConfirmTrades(sessionKey, DateTime.Now.AddMonths(-3), DateTime.Now, out error, out trades);
        }

       /// <summary>
        /// 获取某个时间段内未发货的订单
       /// </summary>
       /// <param name="sessionKey"></param>
        /// <param name="startDateTime">开始时间</param>
       /// <param name="endDateTime">结束时间</param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetUndeliveredTrades(string sessionKey,DateTime startDateTime,DateTime endDateTime, out string error, out List<Trade> trades)
        {
            bool isSuccess = false;
            error = string.Empty;
            trades = null;
            try
            {
                ITopClient client = new DefaultTopClient(Constants.ApiUrl, Constants.AppKey, Constants.AppSecret);
                TradesSoldGetRequest req = new TradesSoldGetRequest();
                req.Fields = "tid,buyer_nick,receiver_state,receiver_city,receiver_address,receiver_mobile";
                req.Status = TradeStatus.WAIT_SELLER_SEND_GOODS;
                req.StartCreated = startDateTime;
                req.EndCreated = endDateTime;
                req.EndCreated = DateTime.Now;
                TradesSoldGetResponse rsp = client.Execute(req, sessionKey);
                trades = rsp.Trades;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return isSuccess;
        }

        /// <summary>
        /// 获取某个时间段内部分发货的订单
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetConSignedTrades(string sessionKey, DateTime startDateTime, DateTime endDateTime, out string error, out List<Trade> trades)
        {
            bool isSuccess = false;
            error = string.Empty;
            trades = null;
            try
            {
                ITopClient client = new DefaultTopClient(Constants.ApiUrl, Constants.AppKey, Constants.AppSecret);
                TradesSoldGetRequest req = new TradesSoldGetRequest();
                req.Fields = "tid,buyer_nick,receiver_state,receiver_city,receiver_address,receiver_mobile";
                req.Status = TradeStatus.SELLER_CONSIGNED_PART;
                req.StartCreated = startDateTime;
                req.EndCreated = endDateTime;
                req.EndCreated = DateTime.Now;
                TradesSoldGetResponse rsp = client.Execute(req, sessionKey);
                trades = rsp.Trades;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return isSuccess;
        }

        /// <summary>
        /// 获取某个时间段内已发货但买家未确认收货的订单
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetWaitConfirmTrades(string sessionKey, DateTime startDateTime, DateTime endDateTime, out string error, out List<Trade> trades)
        {
            bool isSuccess = false;
            error = string.Empty;
            trades = null;
            try
            {
                ITopClient client = new DefaultTopClient(Constants.ApiUrl, Constants.AppKey, Constants.AppSecret);
                TradesSoldGetRequest req = new TradesSoldGetRequest();
                req.Fields = "tid,buyer_nick,receiver_state,receiver_city,receiver_address,receiver_mobile";
                req.Status = TradeStatus.WAIT_BUYER_CONFIRM_GOODS;
                req.StartCreated = startDateTime;
                req.EndCreated = endDateTime;
                req.EndCreated = DateTime.Now;
                TradesSoldGetResponse rsp = client.Execute(req, sessionKey);
                trades = rsp.Trades;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return isSuccess;
        }

       
    }
}