using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using print.Models.Repository;
using print.Models.DAL;

namespace print.Models.BLL
{
    public class BaseService<T> : IService<T> where T : BaseObject
    {
        /// <summary>
        /// 私有字段，保存错误信息
        /// </summary>
        private string errorMsg;

        /// <summary>
        /// 保存出错时的错误信息
        /// </summary>
        public string ErrorMsg { get { return errorMsg; } }

        /// <summary>
        /// 获取当前操作对象对应的操作池
        /// </summary>
        /// <returns></returns>
        private IRepository<T> GetCurrentRepository()
        {
            if (typeof(T) == typeof(Sender))
            {
                return (IRepository<T>)new SenderRepository();
            }
            else if (typeof(T) == typeof(SenderInfoPrintSettings))
            {
                return (IRepository<T>)new SenderInfoPrintSettingsRepository();
            }
            else if (typeof(T) == typeof(ReceiverInfoPrintSettings))
            {
                return (IRepository<T>)new ReceiverInfoPrintSettingsRepository();
            }
            else if (typeof(T) == typeof(ShipmentOrderPrintSettings))
            {
                return (IRepository<T>)new ShipmentOrderPrintSettingsRepository();
            }
            else
            {
                errorMsg = "当前对象的数据库操作未实现。";
                return null;
            }
        }
        /// <summary>
        /// 按照条件查询数据库获取对象列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="results">返回的对象列表</param>
        /// <returns>操作成功则为true,否则为false</returns>
        public bool LoadEntities(Expression<Func<T, bool>> query, out List<T> results)
        {
            results = null;
            bool isSuccess = false;
            IRepository<T> ir = GetCurrentRepository();
            if (ir != null)
            {
                try
                {
                    results = ir.LoadEntities(query);
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }
            }
            return isSuccess;
        }
        /// <summary>
        /// 按照条件查询数据库返回结果的第一条数据对应的对象
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="result">返回的对象</param>
        /// <returns>操作成功则为true,否则为false</returns>
        public bool LoadEntity(Expression<Func<T, bool>> query, out T result)
        {
            result = null;
            bool isSuccess = false;
            IRepository<T> ir = GetCurrentRepository();
            if (ir != null)
            {
                try
                {
                    result = ir.LoadEntity(query);
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }
            }
            return isSuccess;
        }
        /// <summary>
        /// 数据库增加一条记录
        /// </summary>
        /// <param name="entity">增加的对象信息</param>
        /// <returns>操作成功则为true,否则为false</returns>
        public bool AddEntity(T entity)
        {
            bool isSuccess = false;
            IRepository<T> ir = GetCurrentRepository();
            if (ir != null)
            {
                try
                {
                    ir.AddEntity(entity);
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }
            }
            return isSuccess;
        }
        /// <summary>
        /// 数据库更新一条记录
        /// </summary>
        /// <param name="entity">修改的对象信息</param>
        /// <returns>操作成功则为true,否则为false</returns>
        public bool UpdateEntity(T entity)
        {
            bool isSuccess = false;
            IRepository<T> ir = GetCurrentRepository();
            if (ir != null)
            {
                try
                {
                    ir.UpdateEntity(entity);
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }
            }
            return isSuccess;
        }
    }
}