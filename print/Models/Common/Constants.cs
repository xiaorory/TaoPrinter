using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace print.Models.Common
{
    public class Constants
    {
        /// <summary>
        /// 是否是在沙盒中测试
        /// </summary>
        public static bool IsSandBox
        {
            get{
                bool result;
                if (bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["isSandBox"], out result))
                    return result;
                else return false;
                }
        }

        /// <summary>
        /// 淘宝调用api的url链接地址
        /// </summary>
        public static string ApiUrl
        {
            get
            {
                if (IsSandBox) { return SandBoxConstants.apiUrl; }
                else { return ZhengshiConstants.apiUrl; }
            }
        }

        /// <summary>
        /// 淘宝获取授权的链接地址
        /// </summary>
        public static string AuthUrl
        {
            get
            {
                if (IsSandBox){return SandBoxConstants.authUrl;}
                else {return ZhengshiConstants.authUrl; }
            }
        }

        /// <summary>
        /// 淘宝应用的app key
        /// </summary>
        public static string AppKey
        {
            get
            {
                if (IsSandBox) { return SandBoxConstants.appkey; }
                else { return ZhengshiConstants.appkey; }
            }
        }

        /// <summary>
        /// 淘宝应用的加密密钥
        /// </summary>
        public static string AppSecret
        {
            get
            {
                if (IsSandBox) { return SandBoxConstants.appsecret; }
                else { return ZhengshiConstants.appsecret; }
            }
        }

        /// <summary>
        /// 存储的Session中SessionKey的变量名
        /// </summary>
        public static string SessionKey
        {
            get
            {
                return "SessionKey";
            }
        }

        /// <summary>
        ///  存储的Session中User_Id的变量名
        /// </summary>
        public static string User_Id
        {
            get
            {
                return "User_Id";
            }
        }

        /// <summary>
        /// 存储的Session中Sender_Nick的变量名
        /// </summary>
        public static string Sender_Nick
        {
            get
            {
                return "Sender_Nick";
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