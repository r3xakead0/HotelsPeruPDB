using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class UserBL
    {
        UsersDA DA = new UsersDA();
        /*Select*/
        public List<BEManagementUser> GetUserBL(string cfullname)
        {
            return DA.GetUsers(cfullname);
        }
        /*Insert*/
        public string Insert(BEManagementUser objBE)
        {
            return DA.InsGestionUsuario(objBE);
        }
        /*Update*/
        public string Update(BEManagementUser objBE)
        {
            return DA.UpdGestionUsuario(objBE);
        }
        /*Delete*/
        public string Delete(BEManagementUser objBE)
        {
            return DA.DelGestionUsuario(objBE);
        }
        /*Update Password*/
        public string UpdPassword(BEUser objBE)
        {
            return DA.UpdPassword(objBE);
        }
        /*Menus*/
        public List<BEMenu> GetMenuTopBL(BEMenu BE)
        {
            return DA.GetMenuTop(BE);
        }
                
    }
}
