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
        public static readonly string tradeFieldList = "buyer_nick,receiver_state,receiver_city,receiver_address," +
                "receiver_mobile,receiver_zipcode,receiver_phone";//获取某个订单详情时的字段
        public static readonly string tradeListFieldList = "tid,buyer_nick,receiver_state,receiver_city," +
            "receiver_address,receiver_mobile";//获取订单列表时需要返回的字段

        /// <summary>
        /// 私有字段，保存错误信息
        /// </summary>
        private static string errorMsg;

        /// <summary>
        /// 保存出错时的错误信息
        /// </summary>
        public static string ErrorMsg { get { return errorMsg; } }

        /// <summary>
        /// 获取某个订单的详情
        /// </summary>
        /// <param name="tid">trade id</param>
        /// <param name="sessionKey"></param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetTrade(int tid, string sessionKey, out Trade trade)
        {
            bool isSuccess = false;
            trade = null;
            try
            {
                ITopClient client = new DefaultTopClient(Constants.ApiUrl, Constants.AppKey, Constants.AppSecret);
                TradeFullinfoGetRequest req = new TradeFullinfoGetRequest();
                req.Fields = tradeFieldList;
                req.Tid = tid;
                TradeFullinfoGetResponse rsp = client.Execute(req, sessionKey);
                trade = rsp.Trade;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
            return isSuccess;
        }

        /// <summary>
        /// 获取三个月内交易状态的所有订单
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="status">交易状态</param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetTrades(string sessionKey, TradeStatus status, out List<Trade> trades)
        {
            return GetTrades(sessionKey, status, DateTime.Now.AddMonths(-3), DateTime.Now, null, null, out trades);
        }

        /// <summary>
        /// 获取某个时间段内交易状态的所有订单
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="status">交易状态</param>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetTrades(string sessionKey, TradeStatus status, DateTime startDateTime, DateTime endDateTime, out List<Trade> trades)
        {
            return GetTrades(sessionKey, status, startDateTime, endDateTime, null, null, out trades);
        }

        /// <summary>
        /// 获取三个月内交易状态的部分订单（按页显示）
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="status">交易状态</param>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetTrades(string sessionKey, TradeStatus status, long? pageSize, long? pageNum, out List<Trade> trades)
        {
            return GetTrades(sessionKey, status, DateTime.Now.AddMonths(-3), DateTime.Now,pageSize,pageNum, out trades);
        }

        /// <summary>
        /// 根据条件获取交易列表
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="status">交易状态</param>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="pageNum">页数（第几页）</param>
        /// <param name="error">如果出错，则储存错误信息，否则为空。</param>
        /// <param name="trades">如果成功，返回未发货订单的list。否则为null</param>
        /// <returns>如果操作成功，则返回true。否则为false。</returns>
        public static bool GetTrades(string sessionKey, TradeStatus status, DateTime startDateTime, DateTime endDateTime, long? pageSize, long? pageNum, out List<Trade> trades)
        {
            bool isSuccess = false;
            trades = null;
            try
            {
                ITopClient client = new DefaultTopClient(Constants.ApiUrl, Constants.AppKey, Constants.AppSecret);
                TradesSoldGetRequest req = new TradesSoldGetRequest();
                req.Fields = "tid,buyer_nick,receiver_state,receiver_city,receiver_address,receiver_mobile";
                req.Status = Enum.GetName(typeof(TradeStatus), status);
                req.StartCreated = startDateTime;
                req.EndCreated = endDateTime;
                req.EndCreated = DateTime.Now;
                req.PageNo = pageNum;
                req.PageSize = pageSize;
                TradesSoldGetResponse rsp = client.Execute(req, sessionKey);
                trades = rsp.Trades;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
            return isSuccess;
        }

    }
}