using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cizon.Domain.Entities
{
    [DataContract]
    public class RoleDto : Entity
    {
        #region Fields
        private string roleCode = null;//角色编码
        private string name = null;//名称
        private string modifier = null;//修改人
        private DateTime? modifyTime = null;//修改时间
        private string note = null;//备注
        private int? state = null;//状态
        private string systemId = null;//系统Id
        #endregion
       

        #region Properties
       
        [StringLength(50)]
        [DisplayName("角色编码")]
        [DataMember]
        public string RoleCode
        {
            get
            {
                return roleCode;
            }
            set
            {
                roleCode = value;
                this.OnPropertyChanged("RoleCode");
            }
        }
        [Required]
        [StringLength(50)]
        [DisplayName("名称")]
        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                this.OnPropertyChanged("Name");
            }
        }
        [StringLength(20)]
        [DisplayName("修改人")]
        [DataMember]
        public string Modifier
        {
            get
            {
                return modifier;
            }
            set
            {
                modifier = value;
                this.OnPropertyChanged("Modifier");
            }
        }
        [DisplayName("修改时间")]
        [DataMember]
        public DateTime? ModifyTime
        {
            get
            {
                return modifyTime;
            }
            set
            {
                modifyTime = value;
                this.OnPropertyChanged("ModifyTime");
            }
        }
        [StringLength(255)]
        [DisplayName("备注")]
        [DataMember]
        public string Note
        {
            get
            {
                return note;
            }
            set
            {
                note = value;
                this.OnPropertyChanged("Note");
            }
        }
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
        [StringLength(50)]
        [DisplayName("系统Id")]
        [DataMember]
        public string SystemId
        {
            get
            {
                return systemId;
            }
            set
            {
                systemId = value;
                this.OnPropertyChanged("SystemId");
            }
        }
        #endregion
    }
}
