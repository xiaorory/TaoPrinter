using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace print.Models.Repository
{
    interface IRepository<T> where T : class
    {
        /// <summary>
        /// 按照条件查询数据库获取对象列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<T> LoadEntities(Expression<Func<T, bool>> query);
        /// <summary>
        /// 按照条件查询数据库返回结果的第一条数据对应的对象
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        T LoadEntity(Expression<Func<T, bool>> query);
        /// <summary>
        /// 数据库增加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool AddEntity(T entity);
        /// <summary>
        /// 数据库更新一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(T entity);
    }
}
