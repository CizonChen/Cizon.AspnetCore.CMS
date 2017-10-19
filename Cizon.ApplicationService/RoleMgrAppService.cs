using Cizon.Domain.Entities;
using Cizon.Domain.IRepositories;
using Cizon.EntityFrameworkCore;
using Cizon.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cizon.ApplicationService
{
   public  class RoleMgrAppService
    {
        private IRoleSetingRepository _roleSetingRepository = new RoleSetingRepository();
        private IRightRepository _rightRepository = new RightRepository();
        private IRoleRepository _roleRepository = new RoleRepository();
        private IRoleAssignmentRepository _roleAssignmentRepository = new RoleAssignmentRepository();
        /// <summary>
        /// 验证用户是否拥有指定的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <param name="rightId"></param>
        /// <returns></returns>
        public bool CheckUserHasTheRight(string userId, string rightId)
        {
            bool result = false;
            string[] rightArry = rightId.Trim().Split(',');
            for (int n = 0; n < rightArry.Length; n++)
            {
                if (rightArry[n].Trim() == "")
                {
                    continue;
                }
                //获取拥有该权限的所有角色
                List<RoleSettingDto> jsszDtoList = this.GetRoleSettingForTheRight(rightArry[n]);
                for (int i = 0; i < jsszDtoList.Count; i++)
                {
                    //验证用户是否有指定角色的权限
                    result = this.CheckUserIsTheRole(userId, jsszDtoList[i].RoleId);
                    if (result)
                    {
                        break;
                    }
                }
                if (result)
                {
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// 获取与指定权限有关的角色设置
        /// </summary>
        /// <returns></returns>
        private List<RoleSettingDto> GetRoleSettingForTheRight(string rightId)
        {
            
           return _roleSetingRepository.GetAllList(x => x.LinkId == rightId && x.LinkType == 0);
        
        }
        /// <summary>
        /// 获取权限关联的角色
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="includePRole">是否包含父角色，只包含第一级父角色</param>
        /// <returns></returns>
        public List<RoleDto> GetTheRightLinkRoles(string rightId, bool includePRole = false)
        {
            List<RoleDto> list = new List<RoleDto>();
            var templist = _roleSetingRepository.GetAllList(x => x.LinkId == rightId);
            for (int i = 0; i < templist.Count; i++)
            {
                var model = _roleRepository.GetAllList(x => x.Id == templist[i].RoleId).FirstOrDefault();
                if (model != null)
                {
                    list.Add(model);
                    if (includePRole) list.AddRange(this.GetParentRoles(model.Id));
                }
            }
            return list;
        }
        /// <summary>
        /// 获取角色关联的父角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleDto> GetParentRoles(string roleId)
        {
            List<RoleDto> list = new List<RoleDto>();

           var templist= _roleSetingRepository.GetAllList(x => x.LinkId == roleId);
            for (int i = 0; i < templist.Count; i++)
            {
               var model= _roleRepository.GetAllList(x => x.Id == templist[i].RoleId).FirstOrDefault();
              if(null!=model)list.Add(model);
            }
          
            return list;
        }
        /// <summary>
        /// 验证用户是否是指定的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool CheckUserIsTheRole(string userId, string roleId)
        {
            bool result = false;
            //获取该用户直接拥有的角色
            List<RoleAssignmentDto> jsfpList = this.GetRoleAssignmentForUser(userId);
            //递归获取子角色
            for (int i = 0; i < jsfpList.Count; i++)
            {
                if (jsfpList[i].RoleId == roleId)
                {
                    result = true;
                    break;
                }
                List<string> chilJueSelist = new List<string>();
                this.GetChildRoleId(chilJueSelist, jsfpList[i].RoleId);
                for (int n = 0; n < chilJueSelist.Count; n++)
                {
                    if (chilJueSelist[n] == roleId)
                    {
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// 根据角色编码验证
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        public bool CheckUserIsTheRoleByCode(string userId, string roleCode)
        {
            bool result = false;
            RoleDto dto = this.GetTheRoleByCode(roleCode);
            if (dto != null)
            {
                result = CheckUserIsTheRole(userId, dto.Id);
            }
            return result;
        }
        /// <summary>
        /// 获取该用户角色分配情况
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        private List<RoleAssignmentDto> GetRoleAssignmentForUser(string userId)
        {
           return  _roleAssignmentRepository.GetAllList(x => x.UserId == userId);
        }

        /// <summary>
        /// 获取所有子角色的ID
        /// </summary>
        /// <param name="roleIdList"></param>
        /// <param name="pRoleId"></param>
        private void GetChildRoleId(List<string> roleIdList, string pRoleId)
        {
            var tempList = this.GetTheRoleBindChildRoleSetting(pRoleId);
            for (int i = 0; i < tempList.Count; i++)
            {
                if (!roleIdList.Contains(tempList[i].LinkId))
                {
                    roleIdList.Add(tempList[i].LinkId);
                    this.GetChildRoleId(roleIdList, tempList[i].LinkId);
                }
            }
        }

        /// <summary>
        /// 获取角色的子角色设置情况
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        private List<RoleSettingDto> GetTheRoleBindChildRoleSetting(string roleId)
        {
          return  _roleSetingRepository.GetAllList(x => x.RoleId == roleId && x.LinkType == 1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        private List<RoleDto> GetTheRoleHasChildRoles(string roleId)
        {
            List<RoleDto> list = new List<RoleDto>();
            List<string> roleIdList = new List<string>();
            this.GetChildRoleId(roleIdList, roleId);
            for (int i = 0; i < roleIdList.Count; i++)
            {
                var role = this.GetTheRoleById(roleIdList[i]);
                if (role != null)
                {
                    list.Add(role);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据角色编号获取角色对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private RoleDto GetTheRoleByCode(string code)
        {
            return _roleRepository.GetAllList(x => x.RoleCode == code).FirstOrDefault();
           
        }
        /// <summary>
        /// 根据ID获取角色对象
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        private RoleDto GetTheRoleById(string roleId)
        {
            return _roleRepository.Get(roleId);
        }
        /// <summary>
        /// 获取用户拥有的角色(会递归遍历所有角色)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        public List<RoleDto> GetTheUserHasRoles(string userId, int userType)
        {
            List<RoleDto> jsList = new List<RoleDto>();
            List<RoleAssignmentDto> list = this.GetRoleAssignmentForUser(userId);
            for (int i = 0; i < list.Count; i++)
            {
                var dto = GetTheRoleById(list[i].RoleId);
                jsList.Add(dto);
                var childRoleList = this.GetTheRoleHasChildRoles(dto.Id);
                if (childRoleList != null && childRoleList.Count > 0)
                {
                    jsList.AddRange(childRoleList);
                }
            }
            return jsList;
        }

    }
}
