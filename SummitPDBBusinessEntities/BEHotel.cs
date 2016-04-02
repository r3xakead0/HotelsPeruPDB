using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummitPDB.BusinessEntities
{
    public class BEHotel
    {
        public string codLocal { get; set; }
        public string codPeriodo { get; set; }
        public string agencia { get; set; }
        public string ruta { get; set; }
        /*Mante*/
        public string fechaDocumento { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public string ruc { get; set; }
        public string pasaporte { get; set; }
        public string paisPasaporte { get; set; }
        public string apellidoPaterno { get; set; }
        public string nombre { get; set; }
        public string fechaIngresoHotel { get; set; }
        public string fechaSalidaHotel { get; set; }
        public string nroFicha { get; set; }
        public string unidad { get; set; }
        public string ingresoPais { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string fechaProceso { get; set; }
        public string idHospedaje { get; set; }
        public string paisProcedencia { get; set; }
        /*New Search*/
        public int tipoPrmSearch { get; set; }
        public string textPrmSearch { get; set; }
        public int tipoFechaPrm { get; set; }
        public string prmDesde { get; set; }
        public string prmHasta { get; set; }

        public string flagValidacion { get; set; }
        public string segundoNombre { get; set; }
        public string apellidoMaterno { get; set; }
        public string respuesta { get; set; }

        public int nDiasResidencia { get; set; }
        public string descPais_Proc { get; set; }
        public string descPais_Pasap { get; set; }
    }
}
