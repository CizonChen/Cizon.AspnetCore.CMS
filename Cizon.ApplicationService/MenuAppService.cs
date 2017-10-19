using Cizon.Domain.Entities;
using Cizon.Domain.IRepositories;
using Cizon.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cizon.ApplicationService
{
    public class MenuAppService : IMenuAppService
    {
        RoleMgrAppService role = new RoleMgrAppService();
        private readonly IMenuRepository _repository;
        public MenuAppService(IMenuRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteBatch(List<string> ids)
        {
            _repository.Delete(x => ids.Contains(x.Id));
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuDto Get(string id)
        {
            return _repository.Get(id);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<MenuDto> GetAllList()
        {
            return _repository.GetAllList();
        }

        /// <summary>
        /// 数据插入或更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MenuDto InsertOrUpdate(MenuDto dto)
        {
            return _repository.InsertOrUpdate(dto);
        }

        /// <summary>
        /// 获取系统一级菜单
        /// </summary>
        /// <param name="systemId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public MenuDto GetTheSystemFirstMenu(string systemId)
        {
            return _repository.GetAllList(x => x.SystemId == systemId && x.Type==-1 &&x.Visible==1).FirstOrDefault();
           
        }

        /// <summary>
        /// 获取子菜单
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MenuDto> GetChildMenus(string pId, string userId)
        {
            List<MenuDto> list = new List<MenuDto>();
           var listTemp= _repository.GetAllList(x => x.PId == pId).OrderByDescending(x => x.OrderNum).ToList();
            for (int i = 0; i < listTemp.Count; i++)
            {
                bool add = true;
                if (!string.IsNullOrEmpty(listTemp[i].BindRight))
                {
                    add = false;
                    string[] rights = listTemp[i].BindRight.Split(',');
                    for (int n = 0; n < rights.Length; n++)
                    {
                        if (role.CheckUserHasTheRight(userId, rights[n]))
                        {
                            add = true;
                            break;
                        }
                    }
                }
                if (add)
                {
                    list.Add(listTemp[i]);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据lambda表达式条件获取实体集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<MenuDto> GetAllList(Expression<Func<MenuDto, bool>> predicate)
        {
            return _repository.GetAllList(predicate);
        }

        /// <summary>
        ///  根据用户获取菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MenuDto> GetMenusByUser(string userId)
        {
          
            List<MenuDto> list = new List<MenuDto>();
            string id = Consts.SYSTEMID;
           var model= GetTheSystemFirstMenu(id);
            if (model != null)
            {
                bool add = true;
                if (!string.IsNullOrEmpty(model.BindRight))
                {
                    string[] rights = model.BindRight.Split(',');
                    add = false;
                    for (int n = 0; n < rights.Length; n++)
                    {
                        if (role.CheckUserHasTheRight(userId, rights[n]))
                        {
                            add = true;
                            break;
                        }
                    }
                }
                if (add)
                {
                    list = this.GetChildMenus(model.Id, userId);
                }
            }
            return list;
        }
    }
}
