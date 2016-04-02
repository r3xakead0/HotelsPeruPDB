using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public class IConceptos
    {
        EstadoBL BL = new EstadoBL();

        public List<BEEstado> IgetEstados()
        {
            return BL.GetEstadosBL();
        }
    }
}
