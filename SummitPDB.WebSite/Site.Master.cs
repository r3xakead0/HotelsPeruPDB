using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitPDB.BusinessEntities;
using SummitPDB.ServicesInterface;
using System.Web.Services;

namespace SummitPDB.WebSite
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BEMenu BE = new BEMenu();
            IUsers Interface = new IUsers();
            BEUser BEUser = new BEUser();
            BEUser = (BEUser)Session["LoginUser"];
            BE.codUser = BEUser.UserCod;

            lblLoginFullName.Text = BEUser.UserName;

            AddTopMenuItems(Interface.IGetMenuTop(BE));
        }

        private void AddTopMenuItems(List<BEMenu> menuData)
        {
            var view = from menuParent in menuData where menuParent.ParentID == 0
                       select menuParent;
            foreach (BEMenu row in view)
            {
                MenuItem newMenuItem = new MenuItem(row.Text, row.ID.ToString(),"",Page.ResolveUrl(row.Url));
                NavigationMenu.Items.Add(newMenuItem);
                AddChildMenuItems(menuData, newMenuItem);
            }

        }

        //This code is used to recursively add child menu items by filtering by ParentID
        private void AddChildMenuItems(List<BEMenu> menuData, MenuItem parentMenuItem)
        {
            var view = from menuParent in menuData where menuParent.ParentID ==  Convert.ToInt32(parentMenuItem.Value)
                       select menuParent;
            foreach (BEMenu row in view)
            {
                MenuItem newMenuItem = new MenuItem(row.Text, row.ID.ToString(), "", Page.ResolveUrl(row.Url));
                parentMenuItem.ChildItems.Add(newMenuItem);
                AddChildMenuItems(menuData, newMenuItem);
            }
        }
    }
}
