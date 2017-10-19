using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cizon.Domain.Entities
{
    [DataContract]
    public class RoleSettingDto : Entity
    {
        #region Fields
        private string roleId = null;//角色Id
        private string linkId = null;//关联Id
        private string modifier = null;//修改人
        private DateTime? modifyTime = null;//修改时间
        private int? linkType = null;//关联类型
        #endregion
       
        #region Properties
        
        [Required]
        [StringLength(50)]
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
        [StringLength(50)]
        [DisplayName("关联Id")]
        [DataMember]
        public string LinkId
        {
            get
            {
                return linkId;
            }
            set
            {
                linkId = value;
                this.OnPropertyChanged("LinkId");
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
        [DisplayName("关联类型")]
        [DataMember]
        public int? LinkType
        {
            get
            {
                return linkType;
            }
            set
            {
                linkType = value;
                this.OnPropertyChanged("LinkType");
            }
        }
        #endregion
    }
}
