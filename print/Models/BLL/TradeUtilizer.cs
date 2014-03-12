using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using print.Models.Common;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api;
using Top.Api.Domain;

namespace print.Models.BLL
{
    public class TradeUtilizer
    {
        public static Trade GetTrade(int tid,string sessionKey,out string error)
        {
            error = string.Empty;
            try
            {
                ITopClient client = new DefaultTopClient(Constants.ApiUrl, Constants.AppKey, Constants.AppSecret);
                TradeFullinfoGetRequest req = new TradeFullinfoGetRequest();
                req.Fields = "buyer_nick,receiver_state,receiver_city,receiver_address,receiver_mobile";
                req.Tid = tid;
                TradeFullinfoGetResponse rsp = client.Execute(req, sessionKey);
                return rsp.Trade;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return new Trade();
            }
        }

        public static List<Trade> GetUndeliveredTrades(string sessionKey,out string error)
        {
            error = string.Empty;
            try
            {
                ITopClient client = new DefaultTopClient(Constants.ApiUrl, Constants.AppKey, Constants.AppSecret);
                TradesSoldGetRequest req = new TradesSoldGetRequest();
                req.Fields = "tid,buyer_nick,receiver_state,receiver_city,receiver_address,receiver_mobile";
                req.Status = "WAIT_SELLER_SEND_GOODS";
                req.StartCreated = DateTime.Now.AddMonths(-3);
                req.EndCreated = DateTime.Now;
                TradesSoldGetResponse rsp = client.Execute(req, sessionKey);
                return rsp.Trades;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return new List<Trade>();
            }
             
        }
    }
}