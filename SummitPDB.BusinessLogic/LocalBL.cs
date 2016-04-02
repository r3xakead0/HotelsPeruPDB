using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class LocalBL
    {
        public List<BELocal> GetLocalBL(BELocal local)
        {
            LocalDA DA = new LocalDA();
            return DA.GetLocal(local);
        }
    }
}
