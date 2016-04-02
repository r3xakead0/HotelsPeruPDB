using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummitPDB.BusinessEntities
{
    public class BEVentas
    {
        public string tipoVenta { get; set; }
        public string tipo { get; set; }
        public string fechaEmision  { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public string tipoPersona { get; set; }
        public string tipoDocPersona { get; set; }
        public string numDocumento { get; set; }
        public string razonSocialCliente { get; set; }
        public string apePaterno { get; set; }
        public string apeMaterno { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string tipoMoneda { get; set; }
        public string codDestino { get; set; }
        public string numeroDestino { get; set; }
        public string baseImponibleOperGravada { get; set; }
        public string isc { get; set; }
        public string igv { get; set; }
        public string otros { get; set; }
        public string indicePercepcion { get; set; }
        public string tasaPercepcion { get; set; }
        public string seriePercepcion { get; set; }
        public string numDocPercepcion { get; set; }
        public string tipoTabla10 { get; set; }
        public string serieDocOriginal { get; set; }
        public string numDocOriginal { get; set; }
        public string fechaDocOriginal { get; set; }
        public string baseImponibleOperGravadaNC { get; set; }
        public string IGVNC { get; set; }
        public string idVentas { get; set; }
        public string codLocal { get; set; }
        public string codPeriodo { get; set; }
        /*New Search*/
        public int tipoPrmSearch { get; set; }
        public string textPrmSearch { get; set; }
        public int tipoFechaPrm { get; set; }
        public string prmDesde { get; set; }
        public string prmHasta { get; set; }
        public string Num_SAP { get; set; }
        public string Fec_Contabilizacion { get; set; }
        public string Uni_Negocio { get; set; }
    }
}
