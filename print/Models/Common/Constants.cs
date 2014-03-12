using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace print.Models.Common
{
    public class Constants
    {
        public static bool IsSandBox
        {
            get{
                bool result;
                if (bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["isSandBox"], out result))
                    return result;
                else return false;
                }
        }

        public static string ApiUrl
        {
            get
            {
                if (IsSandBox) { return SandBoxConstants.apiUrl; }
                else { return ZhengshiConstants.apiUrl; }
            }
        }

        public static string AuthUrl
        {
            get
            {
                if (IsSandBox){return SandBoxConstants.authUrl;}
                else {return ZhengshiConstants.authUrl; }
            }
        }

        public static string AppKey
        {
            get
            {
                if (IsSandBox) { return SandBoxConstants.appkey; }
                else { return ZhengshiConstants.appkey; }
            }
        }

        public static string AppSecret
        {
            get
            {
                if (IsSandBox) { return SandBoxConstants.appsecret; }
                else { return ZhengshiConstants.appsecret; }
            }
        }
    }

    class SandBoxConstants //沙盒参数
    {
        public static readonly string apiUrl = "http://gw.api.tbsandbox.com/router/rest";
        public static readonly string authUrl = String.Format("http://container.api.tbsandbox.com/container?appkey={0}&encode=utf-8", appkey);
        public static readonly string appkey = "1021749945";
        public static readonly string appsecret = "sandbox800e89714426f18a255afdae4";
    }

    class ZhengshiConstants //正式环境参数
    {
        public static readonly string apiUrl="http://gw.api.taobao.com/router/rest";
        public static readonly string authUrl = String.Format("http://container.api.taobao.com/container?appkey={0}&encode=utf-8", appkey);
        public static readonly string appkey = "21749945";
        public static readonly string appsecret = "5c66960800e89714426f18a255afdae4";
    }
}