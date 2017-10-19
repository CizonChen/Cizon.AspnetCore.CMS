using Cizon.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cizon.ApplicationService
{
    /// <summary>
    /// 定义服务接口
    /// </summary>
    public interface IAppServiceBase
    {

    }
    /// <summary>
    /// 定义泛型服务接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAppServiceBase<TEntity> : IAppServiceBase where TEntity : Entity
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAllList();

        /// <summary>
        /// 根据lambda表达式条件获取实体集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 数据插入或更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        TEntity InsertOrUpdate(TEntity dto);

        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        void DeleteBatch(List<string> ids);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">Id</param>
        void Delete(string id);

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        TEntity Get(string id);
    }
}
