using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using print.Models.DAL;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using print.Models.Common;

namespace print.Models.BLL
{
    public class UserUtilizer
    {
        public static bool LoadSender(string sessionKey,out string error,out Sender sender)
        {
            error = string.Empty;
            sender = new Sender();
            bool isSuccess = false;
            try
            {
                ITopClient client = new DefaultTopClient(Constants.ApiUrl, Constants.AppKey, Constants.AppSecret);
                UserSellerGetRequest req = new UserSellerGetRequest();
                req.Fields = "user_id,sex";
                UserSellerGetResponse response = client.Execute(req, sessionKey);
                sender.User_Id = response.User.UserId;
                sender.Sender_Nick = response.User.Nick;
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