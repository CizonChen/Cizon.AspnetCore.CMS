using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cizon.Domain.Entities
{
    /// <summary>
    /// 角色分配
    /// </summary>
    [DataContract]
    public class RoleAssignmentDto : Entity
    {
        #region Fields
      
        private string userId = null;//User
        private int? userType = null;//
        private string roleId = null;//角色Id
        private string setter = null;//
        private DateTime? setTime = null;//
        private int? state = null;//状态
        private string systemId = null;

        #endregion

        #region Properties
       
        [Required]
        [StringLength(50)]
        [DisplayName("User")]
        [DataMember]
        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                this.OnPropertyChanged("UserId");
            }
        }
        [Required]
        [DisplayName("用户类型")]
        [DataMember]
        public int? UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
                this.OnPropertyChanged("UserType");
            }
        }
        [Required]
        [StringLength(16)]
        [DisplayName("角色Id")]
        [DataMember]
        public string RoleId
        {
            get
            {
                return roleId;
            }
            set
            {
                roleId = value;
                this.OnPropertyChanged("RoleId");
            }
        }
        [Required]
        [StringLength(10)]
        [DisplayName("分配人")]
        [DataMember]
        public string Setter
        {
            get
            {
                return setter;
            }
            set
            {
                setter = value;
                this.OnPropertyChanged("Setter");
            }
        }
        [Required]
        [DisplayName("分配时间")]
        [DataMember]
        public DateTime? SetTime
        {
            get
            {
                return setTime;
            }
            set
            {
                setTime = value;
                this.OnPropertyChanged("SetTime");
            }
        }
        [Required]
        [DisplayName("状态")]
        [DataMember]
        public int? State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                this.OnPropertyChanged("State");
            }
        }
        [Required]
        [DisplayName("系统标识")]
        [DataMember]
        public string SystemId
        {
            get { return systemId; }
            set { systemId = value; this.OnPropertyChanged("SystemId"); }
        }
        #endregion
    }
}
