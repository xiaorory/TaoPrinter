using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using print.Models.DAL;

namespace print.Models.BLL
{
    public class ServiceUtilizer
    {
        /// <summary>
        /// 私有字段，保存错误信息
        /// </summary>
        private static string errorMsg;

        /// <summary>
        /// 保存出错时的错误信息
        /// </summary>
        public static string ErrorMsg { get { return errorMsg; } }
        /// <summary>
        /// 获取当前对象的service
        /// </summary>
        /// <returns></returns>
        public static IService<T> GetCurrentService<T>() where T : BaseObject
        {
            if (typeof(T) == typeof(Sender))
            {
                return (IService<T>)new SenderService();
            }
            else if (typeof(T) == typeof(SenderInfoPrintSettings))
            {
                return (IService<T>)new SenderInfoPrintSettingsService();
            }
            else if (typeof(T) == typeof(ReceiverInfoPrintSettings))
            {
                return (IService<T>)new ReceiverInfoPrintSettingsService();
            }
            else if (typeof(T) == typeof(ShipmentOrderPrintSettings))
            {
                return (IService<T>)new ShipmentOrderPrintSettingsService();
            }
            else
            {
                errorMsg = "当前对象的数据库操作未实现。";
                return null;
            }
        }

        /// <summary>
        /// 通过user_id获取对象内容
        /// </summary>
        /// <typeparam name="T">Sender,SenderInfoPrintSettings,ReceiverInfoPrintSettings或者ShipmentOrderPrintSettings</typeparam>
        /// <param name="oUserid">Session["User_Id"]</param>
        /// <returns></returns>
        public static T GetCurrentEntity<T>(object oUserid) where T : BaseObject
        {
            T obj = null;
            IService<T> service  =  GetCurrentService<T>();
            if (null != service)
            {
                int user_id;
                if (null != oUserid && int.TryParse(oUserid.ToString(), out user_id))
                {
                    service.LoadEntity(p => p.User_Id == user_id, out obj);
                }
                else
                {
                    errorMsg = "未登录";
                }
            }
            return obj;
        }
    }
}