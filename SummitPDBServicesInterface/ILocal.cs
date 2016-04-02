using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public class ILocal
    {
        public List<BELocal> IGetLocal(BELocal local)
        {
            LocalBL getLocalBL = new LocalBL();
            return getLocalBL.GetLocalBL(local);
        }
    }
}