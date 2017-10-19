using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cizon.Domain.Entities
{

    [DataContract]
    public class RightDto : Entity
    {
        #region Fields
        private string mingCheng = null;//名称
        private int? visible = null;//显示
        private int? orderNum = null;//次序
        private string systemId = null;//
        private string mdifier = null;//修改人
        private DateTime? modifyTime = null;//修改时间
        private string note = null;//备注
        #endregion
   
        #region Properties
       
        [Required]
        [DisplayName("名称")]
        [DataMember]
        public string Name
        {
            get
            {
                return mingCheng;
            }
            set
            {
                mingCheng = value;
                this.OnPropertyChanged("Name");
            }
        }
        [Required]
        [DisplayName("显示")]
        [DataMember]
        public int? Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
                this.OnPropertyChanged("Visible");
            }
        }
        [Required]
        [DisplayName("次序")]
        [DataMember]
        public int? OrderNum
        {
            get
            {
                return orderNum;
            }
            set
            {
                orderNum = value;
                this.OnPropertyChanged("OrderNum");
            }
        }
        [DisplayName("SystemId")]
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
            }
        }
        [DisplayName("修改人")]
        [DataMember]
        public string Modifier
        {
            get
            {
                return mdifier;
            }
            set
            {
                mdifier = value;
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
            }
        }
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
        #endregion
    }
}
