using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessLogic;
using SummitPDB.BusinessEntities;

namespace SummitPDB.ServicesInterface
{
    public class IExportar
    {
        ExportarBL BL = new ExportarBL();
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
        public string IExporHotel(BEPeriodoEmpresa_Mant Perido)
        {
            return BL.GetExportacion_Hotel(Perido);
        }
        public string IExporCompra(BEPeriodoEmpresa_Mant Perido)
        {
            return BL.GetExportacion_Compra(Perido);
        }
        public string IExporVenta(BEPeriodoEmpresa_Mant Perido)
        {
            return BL.GetExportacion_venta(Perido);
        }
        public string ITipo_Cambio(Int64 Perido)
        {
            return BL.GetExportacion_Tipo_Cambio(Perido);
        }
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
    }
}
