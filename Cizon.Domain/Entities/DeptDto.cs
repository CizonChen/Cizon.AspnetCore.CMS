using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Cizon.Domain.Entities
{
    [DataContract]
    public class DeptDto : Entity
    {
        #region Fields
        private int? code = null;//编码
        private string name = null;//名称
        private string shortName = null;//简称
        private int? level = null;//级别
        private string cityCode = null;//城市
        private string postcode = null;//邮编
        private string address = null;//地址
        private string note = null;//备注
        private string creator = null;//创建人
        private DateTime? createTime = null;//创建时间
        private string modifier = null;//修改人
        private DateTime? modifyTime = null;//修改时间
        private int? state = null;//状态
        private string contact = null;//联系人
        private string contactNumber = null;//联系电话
        private string leader = null;//负责人
        private string tag1 = null;//Tag1
        private string tag2 = null;//Tag2
        private string webSite = null;

       
        [Required]
        [DisplayName("编码")]
        [DataMember]
        public int? Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
                this.OnPropertyChanged("Code");
            }
        }
        [Required]
        [StringLength(100)]
        [DisplayName("单位名称")]
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
        [StringLength(50)]
        [DisplayName("单位简称")]
        [DataMember]
        public string ShortName
        {
            get
            {
                return shortName;
            }
            set
            {
                shortName = value;
                this.OnPropertyChanged("ShortName");
            }
        }
        [Required]
        [DisplayName("级别")]
        [DataMember]
        public int? Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                this.OnPropertyChanged("Level");
            }
        }
        [StringLength(20)]
        [DisplayName("城市")]
        [DataMember]
        public string CityCode
        {
            get
            {
                return cityCode;
            }
            set
            {
                cityCode = value;
                this.OnPropertyChanged("CityCode");
            }
        }
        [StringLength(10)]
        [DisplayName("邮编")]
        [DataMember]
        public string Postcode
        {
            get
            {
                return postcode;
            }
            set
            {
                postcode = value;
                this.OnPropertyChanged("Postcode");
            }
        }
        [StringLength(100)]
        [DisplayName("地址")]
        [DataMember]
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                this.OnPropertyChanged("Address");
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
        [Required]
        [StringLength(10)]
        [DisplayName("创建人")]
        [DataMember]
        public string Creator
        {
            get
            {
                return creator;
            }
            set
            {
                creator = value;
                this.OnPropertyChanged("Creator");
            }
        }
        [Required]
        [DisplayName("创建时间")]
        [DataMember]
        public DateTime? CreateTime
        {
            get
            {
                return createTime;
            }
            set
            {
                createTime = value;
                this.OnPropertyChanged("CreateTime");
            }
        }
        [StringLength(10)]
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
        [StringLength(10)]
        [DisplayName("联系人")]
        [DataMember]
        public string Contact
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;
                this.OnPropertyChanged("Contact");
            }
        }
        [StringLength(20)]
        [DisplayName("联系电话")]
        [DataMember]
        public string ContactNumber
        {
            get
            {
                return contactNumber;
            }
            set
            {
                contactNumber = value;
                this.OnPropertyChanged("ContactNumber");
            }
        }
        [StringLength(10)]
        [DisplayName("负责人")]
        [DataMember]
        public string Leader
        {
            get
            {
                return leader;
            }
            set
            {
                leader = value;
                this.OnPropertyChanged("Leader");
            }
        }
        [StringLength(50)]
        [DisplayName("Tag1")]
        [DataMember]
        public string Tag1
        {
            get
            {
                return tag1;
            }
            set
            {
                tag1 = value;
                this.OnPropertyChanged("Tag1");
            }
        }
        [StringLength(50)]
        [DisplayName("Tag2")]
        [DataMember]
        public string Tag2
        {
            get
            {
                return tag2;
            }
            set
            {
                tag2 = value;
                this.OnPropertyChanged("Tag2");
            }
        }
        [StringLength(50)]
        [DisplayName("网址")]
        [DataMember]
        public string WebSite
        {
            get { return webSite; }
            set { webSite = value; }
        }
        #endregion
    }
}
