using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public class IEstado
    {
        EstadoBL BL = new EstadoBL();
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
        public List<BEEstado> IgetEstados()
        {
            return BL.GetEstadosBL();
        }
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
    }
}
