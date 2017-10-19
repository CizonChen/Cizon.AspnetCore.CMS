using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Cizon.CMS.MVC.Models
{
    [DataContract]
    public class MenuModel
    {
        private List<MenuModel> childMenuList = new List<MenuModel>();

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string IconUrl { get; set; }

        [DataMember]
        public int? OPenType { get; set; }

        [DataMember]
        public List<MenuModel> ChildMenuList
        {
            get { return childMenuList; }
            set { childMenuList = value; }
        }

        public MenuModel(string id, string text, string url, string iconUrl, int? oPenType)
        {
            this.Id = id;
            this.Text = text;
            this.Url = url;
            this.IconUrl = iconUrl;
            OPenType = oPenType;
        }
    }
}
