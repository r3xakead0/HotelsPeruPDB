using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class EstadoBL
    {
        //renzo luareano miura 30/01/2012
        public List<BEEstado> GetEstadosBL()
        {
            EstadoDA getEstados = new EstadoDA();
            return getEstados.GetEstado();
        }
        //renzo luareano miura 30/01/2012
    }
}
