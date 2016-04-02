using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public class ICompras
    {
        ComprasBL BL = new ComprasBL();
        /*Select*/
        public List<BECompras> IGetCompras(BECompras BECompra)
        {
            return BL.GetComprasBL(BECompra);
        }
        /*Update*/
        public string IUpdCompras(BECompras BECompra)
        {
            return BL.UpdComprasBL(BECompra);
        }
        /*Insert*/
        public string IInsCompras(BECompras BECompra)
        {
            return BL.InsComprasBL(BECompra);
        }
        /*Delete*/
        public string IDelCompras(BECompras BEVenta)
        {
            return BL.DelComprasBL(BEVenta);
        }
    }
}
