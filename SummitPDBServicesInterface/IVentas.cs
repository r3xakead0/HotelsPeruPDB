using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public class IVentas
    {
        VentasBL BL = new VentasBL();
        /*Select*/
        public List<BEVentas> IGetVentas(BEVentas BEVenta)
        {
            return BL.GetVentasBL(BEVenta);
        }
        /*Insert*/
        public string IInsVentas(BEVentas BEVenta)
        {
            return BL.InsVentasBL(BEVenta);
        }
        /*Update*/
        public string IUpdVentas(BEVentas BEVenta)
        {
            return BL.UpdVentasBL(BEVenta);
        }
        /*Delete*/
        public string IDelVentas(BEVentas BEVenta)
        {
            return BL.DelVentasBL(BEVenta);
        }

        public List<string> IvalidarCaracteres(List<BEVentas> lstRegistros)
        {
            return BL.validarCaracteres(lstRegistros);
        }

        public List<BEVentas> IaplicarReglas(List<BEVentas> lstLista)
        {
            return BL.aplicarReglas(lstLista);
        }

        public string IUpdListHotels(List<BEVentas> lstBEVentas)
        {
            return BL.UpdListVentas(lstBEVentas);
        }

    }
}