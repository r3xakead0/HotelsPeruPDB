using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class ComprasBL
    {
        ComprasDA DA = new ComprasDA();
        /*Select*/
        public List<BECompras> GetComprasBL(BECompras BE)
        {
            return DA.GetCompras(BE);
        }
        /*Update*/
        public string UpdComprasBL(BECompras BE)
        {
            return DA.UpdCompras(BE);
        }
        /*Insert*/
        public string InsComprasBL(BECompras BE)
        {
            return DA.InsCompras(BE);
        }
        /*Delete*/
        public string DelComprasBL(BECompras BE)
        {
            return DA.DelCompras(BE);
        }
    }
}
