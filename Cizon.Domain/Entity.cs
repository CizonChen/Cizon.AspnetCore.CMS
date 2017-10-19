using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cizon.Domain
{

    /// <summary>
    /// 定义主键为string类型的实体基类
    /// </summary>
    [DataContract]
    public  class Entity : INotifyPropertyChanged
    {
        private string id = "";//ID
      
        [StringLength(36)]
        [DisplayName("ID")]
        [DataMember]
        public virtual string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                this.OnPropertyChanged("Id");
            }
        }
        /// <summary>
        /// 实现属性值更改通知事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
