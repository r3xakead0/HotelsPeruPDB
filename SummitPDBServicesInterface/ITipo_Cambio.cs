using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.BusinessLogic;

namespace SummitPDB.ServicesInterface
{
    public class ITipo_Cambio
    {
        public List<BETipo_Cambio> IGetTipo_Cambio(Int64 codPeriodo)
        {
            Tipo_CambioBL BL = new Tipo_CambioBL();
            return BL.GetTipo_CambioBL(codPeriodo);
        }
    }
}
