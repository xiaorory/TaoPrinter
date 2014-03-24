using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace print.Models.BLL
{
    interface IService<T> where T : class
    { 
        /// <summary>
        /// 按照条件查询数据库获取对象列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="results">返回的对象列表</param>
        /// <returns>操作成功则为true,否则为false</returns>
        bool LoadEntities(Expression<Func<T, bool>> query,out List<T> results);
        /// <summary>
        /// 按照条件查询数据库返回结果的第一条数据对应的对象
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="result">返回的对象</param>
        /// <returns>操作成功则为true,否则为false</returns>
        bool LoadEntity(Expression<Func<T, bool>> query, out T result);
        /// <summary>
        /// 数据库增加一条记录
        /// </summary>
        /// <param name="entity">增加的对象信息</param>
        /// <returns>操作成功则为true,否则为false</returns>
        bool AddEntity(T entity);
        /// <summary>
        /// 数据库更新一条记录
        /// </summary>
        /// <param name="entity">修改的对象信息</param>
        /// <returns>操作成功则为true,否则为false</returns>
        bool UpdateEntity(T entity);
        /// <summary>
        /// 操作不成功时，返回错误信息。成功则为空。
        /// </summary>
        string ErrorMsg { get; }
    }
}
