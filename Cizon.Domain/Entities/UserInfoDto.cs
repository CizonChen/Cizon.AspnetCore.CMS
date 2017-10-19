using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cizon.Domain.Entities
{
    [DataContract]
    public class UserInfoDto : Entity
    {
       
        #region Fields
        private int? userCode = null;//用户编码
        private string deptId = null;
        private string name = null;//名称
        private Int32? sex = null;//性别
        private DateTime? birthdate = null;//出生日
        private string email = null;//邮箱
        private string postcode = null;//邮编
        private string address = null;//地址
        private string tel = null;//电话
        private string mobileNumber = null;//电话号码
        private Int32? state = null;//状态
        private string note = null;//备注
        private string creator = null;//创建者
        private DateTime? createTime = null;//创建时间
        private string modifier = null;//修改人
        private DateTime? modifyTime = null;//修改时间
        private string password = null;
        private int? errorTimes = null;
        private string logonCode = null;


        #endregion

        #region Properties
       
        [DisplayName("用户编码")]
        [DataMember]
        public int? UserCode
        {
            get
            {
                return userCode;
            }
            set
            {
                userCode = value;
                this.OnPropertyChanged("UserCode");
            }
        }
        [Required]
        [StringLength(20)]
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
        [Required]
        [DisplayName("性别")]
        [DataMember]
        public Int32? Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
                this.OnPropertyChanged("Sex");
            }
        }
        [DisplayName("出生日")]
        [DataMember]
        public DateTime? Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                birthdate = value;
                this.OnPropertyChanged("Birthdate");
            }
        }
        [StringLength(50)]
        [DisplayName("邮箱")]
        [DataMember]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                this.OnPropertyChanged("Email");
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
        [StringLength(20)]
        [DisplayName("工作电话")]
        [DataMember]
        public string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                tel = value;
                this.OnPropertyChanged("Tel");
            }
        }
        [StringLength(20)]
        [DisplayName("移动电话")]
        [DataMember]
        public string MobileNumber
        {
            get
            {
                return mobileNumber;
            }
            set
            {
                mobileNumber = value;
                this.OnPropertyChanged("MobileNumber");
            }
        }
        [Required]
        [DisplayName("状态")]
        [DataMember]
        public Int32? State
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
        [DisplayName("创建者")]
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
        [DisplayName("工作单位")]
        [DataMember]
        public string DeptId
        {
            get { return deptId; }
            set { deptId = value; }
        }
        [DisplayName("密码")]
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DisplayName("错误次数")]
        [DataMember]
        public int? ErrorTimes
        {
            get { return errorTimes; }
            set { errorTimes = value; }
        }
        [Required]
        [DisplayName("登录名")]
        [StringLength(20)]
        [DataMember]
        public string LogonCode
        {
            get { return logonCode; }
            set { logonCode = value; }
        }
        #endregion
    }
    public class ChangePasswordModel
    {
        //[Required]
        [DataType(DataType.Text)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        //[Required]
        [DataType(DataType.Text)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [Display(Name = "确认新密码")]
        [DataType(DataType.Text)]
        public string ConfirmPassword { get; set; }
    }
}

