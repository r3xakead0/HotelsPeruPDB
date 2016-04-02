using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public class IHotels
    {
        HotelBL BL = new HotelBL();
        /*Select*/
        public List<BEHotel> IGetHotels(BEHotel BEHotel)
        {
            return BL.GetHotelsBL(BEHotel);
        }
        public string ISetNotaCredito(string xSerieNC, string xCorrNC, string xSerieF, string xCorrF, string xfechaF)
        {
            return BL.SetNotaCredito( xSerieNC, xCorrNC, xSerieF, xCorrF, xfechaF);
        }
        public List<BEHotel> IGetHotelsValidados(BEHotel BEHotel)
        {
            return BL.GetHotelsValidadosBL(BEHotel);
        }
        /*Insert*/
        public string IInsHotels(BEHotel BEHotel)
        {
            return BL.InsHotels(BEHotel);
        }
        /*Update*/
        public string IUpdHotels(BEHotel BEHotel)
        {
            return BL.UpdHotels(BEHotel);
        }
        /*Delete*/
        public string IDelHotels(BEHotel BEHotel)
        {
            return BL.DelHotels(BEHotel);
        }
        public string IValUsuarioVentas(BEHotel BEHotel)
        {
            return BL.ValUsuarioVentas(BEHotel);
        }
        public string IGetImponible(BEHotel BEHotel, string tipo)
        {
            return BL.getImponible(BEHotel, tipo);
        }
        public string IGeNumeroDocumentos(BEHotel BEHotel,string tipo)
        {
            return BL.getNumeroDocumento(BEHotel,tipo);
        }
        public string IGeIGVVentas(BEHotel BEHotel)
        {
            return BL.GetIGVVentas(BEHotel);
        }
        public string IGeIGVCompras(BEHotel BEHotel)
        {
            return BL.GetIGVCompras(BEHotel);
        }
        /*Delete group*/
        public string IDelHotelsGroup(BEHotel BEHotel)
        {
            return BL.DelHotelsGroup(BEHotel);
        }

        public List<string> IvalidarCaracteres(List<BEHotel> lstRegistros)
        {
            return BL.validarCaracteres(lstRegistros);
        }

        public List<BEHotel> IaplicarReglas(List<BEHotel> lstLista)
        {
            return BL.aplicarReglas(lstLista);
        }

        public string IUpdListHotels(List<BEHotel> lstBEHotel)
        {
            return BL.UpdListHotels(lstBEHotel);
        }
        public List<BEHotel> IGetporCorrelativo(BEHotel correlativo)
        {
            return BL.GetporCorrelativo(correlativo);
        }
        public List<BEHotel> IGetHotelsAnteriores(BEHotel correlativo)
        {
            return BL.GetHotelsAnteriores(correlativo);
        }
        public string IHotelsDuplicateINS(List<BEHotel> beHotel)
        {
            return BL.HotelsDuplicateINS(beHotel);
        }
        public string IGetUnidad(BEHotel BEHotel)
        {
            return BL.getUnidad(BEHotel);
        }
        public List<BEPais> GetPaises()
        {
            return BL.GetPaises();
        }

        public List<BEHotel> IGetDocDistintos(BEHotel objBE)
        {
            return BL.GetDocDistintos(objBE);
        }

        public List<BEHotel> IGetDocDistintosVentas(BEHotel objBE)
        {
            return BL.GetDocDistintosVentas(objBE);
        }
    }
}