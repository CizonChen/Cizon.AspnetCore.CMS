using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Cizon.Domain.Entities
{
    [DataContract]
    public class MenuDto : Entity
    {
        #region Fields
        private string name = null;//名称
        private int? type = null;//记录类型
        private int? visible = null;//显示
        private int? ciXu = null;//次序
        private string pId = null;//父标识
        private int? navigationVisible = null;//导航显示
        private int? openType = null;//打开方式
        private string zhanKaiTuBiao = null;//展开图标
        private string zheDieTuBiao = null;//折叠图标
        private string chengXuJiMingCheng = null;//程序集名称
        private string leiMingCheng = null;//类名称
        private string modifier = null;//修改人标识
        private DateTime? modifyTime = null;//修改时间
        private string note = null;//备注
        private string bindRight = "";//使用权限
        private string systemId = null;//隶属系统标识
        private string urlAddress = "";
        private string urlIncludeUserSession = "";
        private string urlExtraParam = "";

        #endregion
     

        #region Properties
    
        [Required(ErrorMessage = "名称为必填项")]
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
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Name" });
                name = value;
            }
        }
        [Required]
        [DisplayName("记录类型")]
        [DataMember]
        public int? Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
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
            }
        }
        [Required]
        [DisplayName("次序")]
        [DataMember]
        public int? OrderNum
        {
            get
            {
                return ciXu;
            }
            set
            {
                ciXu = value;
            }
        }
        [Required]
        [DisplayName("父标识")]
        [DataMember]
        public string PId
        {
            get
            {
                return pId;
            }
            set
            {
                pId = value;
            }
        }
        [Required]
        [DisplayName("导航显示")]
        [DataMember]
        public int? NavigationVisible
        {
            get
            {
                return navigationVisible;
            }
            set
            {
                navigationVisible = value;
            }
        }
        [Required]
        [DisplayName("打开方式")]
        [DataMember]
        public int? OpenType
        {
            get
            {
                return openType;
            }
            set
            {
                openType = value;
            }
        }
        [DisplayName("展开图标")]
        [DataMember]
        public string Icon1
        {
            get
            {
                return zhanKaiTuBiao;
            }
            set
            {
                zhanKaiTuBiao = value;
            }
        }
        [DisplayName("折叠图标")]
        [DataMember]
        public string Icon2
        {
            get
            {
                return zheDieTuBiao;
            }
            set
            {
                zheDieTuBiao = value;
            }
        }
        [DisplayName("程序集名称")]
        [DataMember]
        public string AssemblyName
        {
            get
            {
                return chengXuJiMingCheng;
            }
            set
            {
                chengXuJiMingCheng = value;
            }
        }
        [DisplayName("类名称")]
        [DataMember]
        public string ClassName
        {
            get
            {
                return leiMingCheng;
            }
            set
            {
                leiMingCheng = value;
            }
        }
        [Required]
        [DisplayName("修改人标识")]
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
            }
        }
        [Required]
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
            }
        }
        [DisplayName("隶属系统标识")]
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

        /// <summary>
        /// 使用权限
        /// </summary>
        [DataMember]
        public string BindRight
        {
            get { return bindRight; }
            set { bindRight = value; }
        }
        [DataMember]
        public string UrlAddress
        {
            get { return urlAddress; }
            set { urlAddress = value; }
        }

        [DataMember]
        public string UrlIncludeUserSession
        {
            get { return urlIncludeUserSession; }
            set { urlIncludeUserSession = value; }
        }

        [DataMember]
        public string UrlExtraParam
        {
            get { return urlExtraParam; }
            set { urlExtraParam = value; }
        }
        #endregion

      
    }
}
