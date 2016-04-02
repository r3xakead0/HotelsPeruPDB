using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class Tipo_CambioBL
    {
        public List<BETipo_Cambio> GetTipo_CambioBL(Int64 CodPeriodo)
        {
            Tipo_CambioDA Tipo_CambioDAO = new Tipo_CambioDA();
            return Tipo_CambioDAO.GET_Tipo_Cambio(CodPeriodo);
        }
    }
}
