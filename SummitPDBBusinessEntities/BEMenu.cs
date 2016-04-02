using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummitPDB.BusinessEntities
{
    public class BEMenu
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public int ParentID { get; set; }
        public string codUser { get; set; }
        public List<BEMenu> items { get; set; }
        public int hasSubOpt { get; set; }
        /*
        public int id { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public string spriteCssClass { get; set; }
        public List<MenuTop> items { get; set; }
         */
    }
}
