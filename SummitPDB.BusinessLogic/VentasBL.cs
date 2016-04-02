using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class VentasBL
    {
        VentasDA DA = new VentasDA();
        /*Select*/
        public List<BEVentas> GetVentasBL(BEVentas BE)
        {
            return DA.GetVentas(BE);
        }
        /*Insert*/
        public string InsVentasBL(BEVentas BE)
        {
            return DA.InsVentas(BE);
        }
        /*Update*/
        public string UpdVentasBL(BEVentas BE)
        {
            return DA.UpdVentas(BE);
        }
        /*Delete*/
        public string DelVentasBL(BEVentas BE)
        {
            return DA.DelVentas(BE);
        }
        public List<string> validarCaracteres(List<BEVentas> lstRegistros)
        {
            List<string> lstErrores = new List<string>();
            List<BEReglas> lstReglas = new List<BEReglas>();
            ReglasDA DARegla = new ReglasDA();

            string mensaje = string.Empty;
            lstReglas = DARegla.GetCaracteresEspeciales();
            foreach (BEVentas beVentas in lstRegistros)
            {
                if (beVentas.tipoVenta == null || beVentas.tipoVenta == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el tipo de venta";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.tipoVenta.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El tipo de venta no tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.tipo == null || beVentas.tipo == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el tipo";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.tipo.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo tipo tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.fechaEmision == null || beVentas.fechaEmision == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra la fecha de emision";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.fechaEmision.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo fecha de emision tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.serie == null || beVentas.serie == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra la serie";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.serie.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo serie tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.numero == null || beVentas.numero == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el numero";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.numero.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo numero  tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.tipoPersona == null || beVentas.tipoPersona == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el tipo de persona";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.tipoPersona.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo tipo de persona tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.tipoDocPersona == null || beVentas.tipoDocPersona == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el tipo de persona";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.tipoDocPersona.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo tipo de persona tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.numDocumento == null || beVentas.numDocumento == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el pais numero de documento";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.numDocumento.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo numero de pasaporte tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.razonSocialCliente == null || beVentas.razonSocialCliente == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra la razon social del cliente";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.razonSocialCliente.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo razon social tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.apePaterno == null || beVentas.apePaterno == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el apellido paterno";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.apePaterno.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo apellido paterno tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.apeMaterno == null || beVentas.apeMaterno == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el apellido materno";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.apeMaterno.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo apellido materno tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.nombre1 == null || beVentas.nombre1 == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el nombre1 la persona";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.nombre1.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo nombre1 de la persona tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.nombre2 == null || beVentas.nombre2 == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra nombre 2";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.nombre2.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo nombre2 tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.tipoMoneda == null || beVentas.tipoMoneda == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el tipo de moneda";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.tipoMoneda.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo tipo de moneda tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.codDestino == null || beVentas.codDestino == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra codigo de destino";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.codDestino.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo codigo de destino tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }


                if (beVentas.numeroDestino == null || beVentas.numeroDestino == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el numero de destino";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.numeroDestino.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo fecha numero de destino tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }

                if (beVentas.baseImponibleOperGravada == null || beVentas.baseImponibleOperGravada == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra la base imponible";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.baseImponibleOperGravada.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo base imponible tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.isc == null || beVentas.isc == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el isc";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.isc.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo  isc tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.igv == null || beVentas.igv == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el igv";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.igv.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo igv tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.otros == null || beVentas.otros == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra otros";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.otros.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo otros tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.indicePercepcion == null || beVentas.indicePercepcion == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el indice de percepcion";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.indicePercepcion.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo indice de percepcion tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.tasaPercepcion == null || beVentas.tasaPercepcion == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra la tasa de percepcion";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.tasaPercepcion.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo tasa de percepcion tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.seriePercepcion == null || beVentas.seriePercepcion == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra la serie de percepcion";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.seriePercepcion.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo serie de percepcion tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.numDocPercepcion == null || beVentas.numDocPercepcion == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el numero de documento de percepcion";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.numDocPercepcion.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo numero de documento de percepcion tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.tipoTabla10 == null || beVentas.tipoTabla10 == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el tipo tabla10";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.tipoTabla10.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo tipo tabla tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.serieDocOriginal == null || beVentas.serieDocOriginal == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra la serioe del docmento original";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.serieDocOriginal.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo serie del documento original tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.numDocOriginal == null || beVentas.numDocOriginal == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el campo de numero original";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.numDocOriginal.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo numero del documento original tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.fechaDocOriginal == null || beVentas.fechaDocOriginal == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra la fecha del documento original";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.fechaDocOriginal.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo fecha del documento original tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.baseImponibleOperGravadaNC == null || beVentas.baseImponibleOperGravadaNC == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra la baseImponibleOperGravadaNC";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.baseImponibleOperGravadaNC.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo baseImponibleOperGravadaNC tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.IGVNC == null || beVentas.IGVNC == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra IGVNC";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.IGVNC.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo IGVNC tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
                if (beVentas.idVentas == null || beVentas.idVentas == string.Empty)
                {
                    mensaje = "Linea " + beVentas.idVentas + " - No encuentra el idVentas";
                    lstErrores.Add(mensaje);
                }
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.idVentas.Contains(especiales.caracter))
                    {
                        mensaje = "Linea " + beVentas.idVentas + " - El campo idVentas tiene el caracter especial " + especiales.equivalence;
                        lstErrores.Add(mensaje);
                    }
                }
            }

            return lstErrores;
        }
        /**/

        public List<BEVentas> aplicarReglas(List<BEVentas> lstRegistros)
        {
            List<BEVentas> lstListaActualizada = new List<BEVentas>();
            List<BEReglas> lstReglas = new List<BEReglas>();
            ReglasDA DARegla = new ReglasDA();

            lstReglas = DARegla.GetCaracteresEspeciales();

            foreach (BEVentas beVentas in lstRegistros)
            {
                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.apePaterno.Contains(especiales.caracter))
                    {
                        beVentas.apePaterno = beVentas.apePaterno.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.apeMaterno.Contains(especiales.caracter))
                    {
                        beVentas.apeMaterno = beVentas.apeMaterno.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.nombre1.Contains(especiales.caracter))
                    {
                        beVentas.nombre1 = beVentas.nombre1.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.nombre2.Contains(especiales.caracter))
                    {
                        beVentas.nombre2 = beVentas.nombre2.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.numDocumento.Contains(especiales.caracter))
                    {
                        beVentas.numDocumento = beVentas.numDocumento.Replace(especiales.caracter, especiales.equivalence);
                    }
                }

                foreach (BEReglas especiales in lstReglas)
                {
                    if (beVentas.razonSocialCliente.Contains(especiales.caracter))
                    {
                        beVentas.razonSocialCliente = beVentas.razonSocialCliente.Replace(especiales.caracter, especiales.equivalence);
                    }
                }


                lstListaActualizada.Add(beVentas);
            }

            return lstListaActualizada;
        }


        public string UpdListVentas(List<BEVentas> lstVentas)
        {
            return DA.UpdListVentas(lstVentas);
        }
    }
}