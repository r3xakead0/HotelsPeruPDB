using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public  class IUsers
    {
        UserBL BL = new UserBL();
        public BEUser IvalidateLoguinUser(BEUser users)
        {
            ValidateUserBL validateUsersBL = new ValidateUserBL();                       

            return validateUsersBL.validateLoguinUserBL(users);
        }
        /*Select*/
        public List<BEManagementUser> IGetUsers(string cfullname)
        {
            return BL.GetUserBL(cfullname);
        }
        /*Insert*/
        public string IInsert(BEManagementUser objBE)
        {
            return BL.Insert(objBE);
        }
        /*Update*/
        public string IUpdate(BEManagementUser objBE)
        {
            return BL.Update(objBE);
        }
        /*Delete*/
        public string IDelete(BEManagementUser objBE)
        {
            return BL.Delete(objBE);
        }
        /*Update Password*/
        public string IUpdPassword(BEUser objBE)
        {
            return BL.UpdPassword(objBE);
        }
        /*Menu*/
        public List<BEMenu> IGetMenuTop(BEMenu BE)
        {
            return BL.GetMenuTopBL(BE);
        }
    }   
}
