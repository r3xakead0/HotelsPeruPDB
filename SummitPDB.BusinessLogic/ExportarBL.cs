using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class ExportarBL
    {
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
        ExportacionDA DA = new ExportacionDA();
        public String GetExportacion_Hotel(BEPeriodoEmpresa_Mant Perido)
        {
            return DA.GetHoteles_Exportacion(Perido);
        }
        public String GetExportacion_Compra(BEPeriodoEmpresa_Mant Perido)
        {
            return DA.GetCompra_Exportacion(Perido);
        }
        public String GetExportacion_venta(BEPeriodoEmpresa_Mant Perido)
        {
            return DA.GetVentas_Exportacion(Perido);
        }
        public String GetExportacion_Tipo_Cambio(Int64 Perido)
        {
            return DA.GetTipo_Cambio_Exportacion(Perido);
        }
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //

    }
}
