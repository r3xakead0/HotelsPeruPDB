using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public  class ValidateUserBL
    {
        public BEUser validateLoguinUserBL(BEUser user)
        {       
            
            validateUsersDA DAValidateUser = new validateUsersDA();

            return DAValidateUser.validateLoginUser(user);
        }
    }
}
