using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using SummitPDB.BusinessEntities;
using SummitPDB.DataAccess;

namespace SummitPDB.BusinessLogic
{
    public class ImportarArchivosBL
    {

        public string HospedajeImportBL(string filename, string delimiter, BEUser users)
        {
            //  Create the new table  
            HotelsDA DA = new HotelsDA();
            string[] nombreArchivo = filename.Split('\\');
            int index = nombreArchivo.Length - 1;
            string resp;
            string idarchivo="";
            try
            {
                if (DA.ValidarArchivosCargados(nombreArchivo[index]) == "0")
                {
                    //if (DA.InsArchivoCaragado(filename) == "1")
                    resp = DA.InsArchivoCaragado(nombreArchivo[index], ref idarchivo);
                    if (resp == "1")
                    {
                        List<BELocal> lstLocales = new List<BELocal>();

                        lstLocales = DA.GetLocales();
                        bool ExisteLocal = false;
                        string codLocal = string.Empty;
                        filename = filename.ToUpper();

                        resp = "No se encuentra ningun local";

                        foreach (BELocal local in lstLocales)
                        {
                            if (filename.Contains(local.nomLocal))
                            {
                                if (DA.ValidarUsuarioLocal(local.codLocal, users) == "1")
                                {
                                    resp = "";
                                    ExisteLocal = true;
                                    codLocal = local.codLocal;
                                }
                                else
                                    resp = "Usuario " + users.UserName + " no pertenece al local " + local.nomLocal;
                            }
                            else
                                resp = "No se reconoce el local en el nombre del archivo";
                        }

                        if (ExisteLocal == true)
                        {
                            List<BEHotel> lstHotel = new List<BEHotel>();
                            BEHotel beHotel = new BEHotel();

                            List<string> lista = new List<string>();

                            //obtengo los datos del fichero. 

                            using (StreamReader fic = new StreamReader(filename))
                            {
                                string linea = null;
                                linea = fic.ReadLine();
                                while ((linea != null))
                                {
                                    lista.Add(linea);
                                    linea = fic.ReadLine();
                                }
                                fic.Close();
                            }
                            foreach (string registro in lista)
                            {
                                string[] columnNames = null;
                                beHotel = new BEHotel();
                                columnNames = registro.Split('|');

                                if (columnNames.Length <= 1) throw new Exception("Existe una linea no valida");

                                beHotel.fechaDocumento = columnNames[0].Trim().ToUpper();
                                beHotel.serie = columnNames[1].Trim().ToUpper();
                                beHotel.correlativo = columnNames[2].Trim().ToUpper();
                                beHotel.ruc = columnNames[3].Trim().ToUpper();
                                beHotel.agencia = columnNames[4].Trim().ToUpper();
                                beHotel.pasaporte = columnNames[5].Trim().ToUpper();
                                beHotel.apellidoMaterno = string.Empty;
                                beHotel.apellidoPaterno = columnNames[6].Trim().ToUpper();
                                string NommbreCompleto = columnNames[7].Trim().ToUpper();
                                if (NommbreCompleto.IndexOf(" ") > 0)
                                {
                                    beHotel.nombre = NommbreCompleto.Substring(0, NommbreCompleto.IndexOf(" ")).ToUpper();
                                    beHotel.segundoNombre = NommbreCompleto.Substring(NommbreCompleto.IndexOf(" ") + 1, NommbreCompleto.Length - (NommbreCompleto.IndexOf(" ") + 1)).ToUpper();
                                }
                                else
                                {
                                    beHotel.nombre = NommbreCompleto.ToUpper();
                                    beHotel.segundoNombre = string.Empty;
                                }
                                beHotel.paisPasaporte = columnNames[8].Trim().ToUpper();
                                beHotel.paisProcedencia = columnNames[9].Trim().ToUpper();
                                beHotel.fechaIngresoHotel = columnNames[10].Trim().ToUpper();
                                beHotel.fechaSalidaHotel = columnNames[11].Trim().ToUpper();
                                beHotel.nroFicha = columnNames[12].Trim().ToUpper();
                                beHotel.x = columnNames[13].Trim().ToUpper();
                                beHotel.unidad = columnNames[14].Trim().ToUpper();
                                beHotel.y = columnNames[15].Trim().ToUpper();
                                beHotel.ingresoPais = columnNames[16].Trim().ToUpper();
                                beHotel.flagValidacion = "0";
                                beHotel.codLocal = codLocal;
                                lstHotel.Add(beHotel);
                            }

                            //Log_ImportarDA LOGIDA = new Log_ImportarDA();
                            //LOGIDA.Limpiar_Log();


                            HotelsDA DAH = new HotelsDA();
                            HotelBL hotel = new HotelBL();
                            resp = DAH.INSListHotels(lstHotel, users, idarchivo);
                            //respuesta.Substring(0, 1).Equals("0");
                            if (resp.Substring(0, 1).Equals("1"))
                            {
                                List<BEHotel> lstBE = new List<BEHotel>();
                                List<BEHotel> lstBE2 = new List<BEHotel>();
                                lstBE = hotel.GetHotelsAll(codLocal);
                                lstBE2 = hotel.aplicarReglas(lstBE);
                                return DAH.UpdListHotels(lstBE2);
                            }
                            else
                            {
                                throw new Exception(resp);
                            }

                        }
                        else
                        {
                            throw new Exception(resp);
                        }
                    }

                    {
                        throw new Exception(resp);
                    }
                }
                else
                {
                    throw new Exception("El archivo ya se cargo anteriormente");
                }
            }
            catch (Exception ex)
            {
                return "0|  " + ex.Message;
            }
        }
        public string VentasImportBL(string filename, string delimiter, BEUser userLocal)
        {
            //  Create the new table  

            HotelsDA DA = new HotelsDA();
            string[] nombreArchivo = filename.Split('\\');
            int index = nombreArchivo.Length - 1;
            string resp;
            string idarchivo = "";
            try
            {
                if (DA.ValidarArchivosCargados(nombreArchivo[index]) == "0")
                {
                    //if (DA.InsArchivoCaragado(filename) == "1")
                    resp = DA.InsArchivoCaragado(nombreArchivo[index],ref idarchivo);
                    if (resp == "1")
                    {
                        List<BELocal> lstLocales = new List<BELocal>();

                        lstLocales = DA.GetLocales();

                        List<BEVentas> lstVentas = new List<BEVentas>();
                        BEVentas beVenta = new BEVentas();

                        List<string> lista = new List<string>();

                        //obtengo los datos del fichero. 

                        using (StreamReader fic = new StreamReader(filename))
                        {
                            string linea = null;
                            linea = fic.ReadLine();
                            while ((linea != null))
                            {
                                lista.Add(linea);
                                linea = fic.ReadLine();
                            }
                            fic.Close();
                        }
                        foreach (string registro in lista)
                        {
                            string[] columnNames = null;
                            beVenta = new BEVentas();
                            columnNames = registro.Split('|');

                            if (columnNames.Length <= 1) throw new Exception("Existe una linea no valida");

                            beVenta.Num_SAP = columnNames[0].Trim().ToUpper();
                            beVenta.Fec_Contabilizacion = columnNames[1].Trim().ToUpper();
                            beVenta.Uni_Negocio = columnNames[2].Trim().ToUpper();
                            beVenta.tipoVenta = columnNames[3].Trim().ToUpper();
                            beVenta.fechaEmision = columnNames[5].Trim().ToUpper();
                            beVenta.tipo = columnNames[4].Trim().ToUpper();
                            beVenta.serie = columnNames[6].Trim().ToUpper();
                            beVenta.numero = columnNames[7].Trim().ToUpper();
                            beVenta.tipoPersona = columnNames[8].Trim().ToUpper();
                            beVenta.tipoDocPersona = columnNames[9].Trim().ToUpper();
                            beVenta.numDocumento = columnNames[10].Trim().ToUpper();
                            beVenta.razonSocialCliente = columnNames[11].Trim().ToUpper();
                            beVenta.apePaterno = columnNames[12].Trim().ToUpper();
                            beVenta.apeMaterno = columnNames[13].Trim().ToUpper();
                            beVenta.nombre1 = columnNames[14].Trim().ToUpper();
                            beVenta.nombre2 = columnNames[15].Trim().ToUpper();
                            beVenta.tipoMoneda = columnNames[16].Trim().ToUpper();
                            beVenta.codDestino = columnNames[17].Trim().ToUpper();
                            beVenta.numeroDestino = columnNames[18].Trim().ToUpper();
                            beVenta.baseImponibleOperGravada = columnNames[19].Trim().ToUpper();
                            beVenta.isc = columnNames[20].Trim().ToUpper();
                            beVenta.igv = columnNames[21].Trim().ToUpper();
                            beVenta.otros = columnNames[22].Trim().ToUpper();
                            beVenta.indicePercepcion = columnNames[23].Trim().ToUpper();
                            beVenta.tasaPercepcion = columnNames[24].Trim().ToUpper();
                            beVenta.seriePercepcion = columnNames[25].Trim().ToUpper();
                            beVenta.numDocPercepcion = columnNames[26].Trim().ToUpper();
                            beVenta.tipoTabla10 = columnNames[27].Trim().ToUpper();
                            beVenta.serieDocOriginal = columnNames[28].Trim().ToUpper();
                            beVenta.numDocOriginal = columnNames[29].Trim().ToUpper();
                            beVenta.fechaDocOriginal = columnNames[30].Trim().ToUpper();
                            beVenta.baseImponibleOperGravadaNC = columnNames[31].Trim().ToUpper();
                            beVenta.IGVNC = columnNames[32].Trim().ToUpper();
                            lstVentas.Add(beVenta);
                        }

                        VentasBL BL = new VentasBL();
                        lstVentas = BL.aplicarReglas(lstVentas);
                        //Log_ImportarDA LOGIDA = new Log_ImportarDA();
                        //LOGIDA.Limpiar_Log();

                        VentasDA DAVenta = new VentasDA();
                        return DAVenta.INSListVentas(lstVentas, userLocal, idarchivo);
                    }
                    else
                    {
                        throw new Exception(resp);
                    }
                }
                else
                {
                    throw new Exception("El archivo ya se cargo anteriormente");
                }
            }
            catch (Exception ex)
            {
                return "0|  " + ex.Message;
            }
        }

        public string ComprasImportBL(string filename, string delimiter, BEUser userLocal)
        {
            //  Create the new table            

            List<BECompras> lstCompras = new List<BECompras>();
            BECompras beCompra = new BECompras();


            HotelsDA DAAR = new HotelsDA();
            string[] nombreArchivo = filename.Split('\\');
            int index = nombreArchivo.Length - 1;
            string resp;
            string idarchivo = "";

            try
            {
                if (DAAR.ValidarArchivosCargados(nombreArchivo[index]) == "0")
                {
                    //if (DA.InsArchivoCaragado(filename) == "1")
                    resp = DAAR.InsArchivoCaragado(nombreArchivo[index],ref idarchivo);
                    if (resp == "1")
                    {
                        List<string> lista = new List<string>();

                        //obtengo los datos del fichero. 

                        using (StreamReader fic = new StreamReader(filename))
                        {
                            string linea = null;
                            linea = fic.ReadLine();
                            while ((linea != null))
                            {
                                lista.Add(linea);
                                linea = fic.ReadLine();
                            }
                            fic.Close();
                        }
                        foreach (string registro in lista)
                        {
                            string[] columnNames = null;
                            beCompra = new BECompras();
                            columnNames = registro.Split('|');

                            if (columnNames.Length <= 1) throw new Exception("Existe una linea no valida");

                            beCompra.Num_Correlativo = columnNames[0].Trim().ToUpper();
                            beCompra.Fec_Contabilizacion = columnNames[1].Trim().ToUpper();
                            beCompra.Uni_Negocio = columnNames[2].Trim().ToUpper();
                            beCompra.tipoVenta = columnNames[3].Trim().ToUpper();
                            beCompra.fechaEmision = columnNames[5].Trim().ToUpper();
                            beCompra.tipo = columnNames[4].Trim().ToUpper();
                            beCompra.serie = columnNames[6].Trim().ToUpper();
                            beCompra.numero = columnNames[7].Trim().ToUpper();
                            beCompra.tipoPersona = columnNames[8].Trim().ToUpper();
                            beCompra.tipoDocPersona = columnNames[9].Trim().ToUpper();
                            beCompra.numDocumento = columnNames[10].Trim().ToUpper();
                            beCompra.razonSocialCliente = columnNames[11].Trim().ToUpper();
                            beCompra.apePaterno = columnNames[12].Trim().ToUpper();
                            beCompra.apeMaterno = columnNames[13].Trim().ToUpper();
                            beCompra.nombre1 = columnNames[14].Trim().ToUpper();
                            beCompra.nombre2 = columnNames[15].Trim().ToUpper();
                            beCompra.tipoMoneda = columnNames[16].Trim().ToUpper();
                            beCompra.codDestino = columnNames[17].Trim().ToUpper();
                            beCompra.numeroDestino = columnNames[18].Trim().ToUpper();
                            beCompra.baseImponibleOperGravada = columnNames[19].Trim().ToUpper();
                            beCompra.isc = columnNames[20].Trim().ToUpper();
                            beCompra.igv = columnNames[21].Trim().ToUpper();
                            beCompra.otros = columnNames[22].Trim().ToUpper();
                            beCompra.indicePercepcion = columnNames[23].Trim().ToUpper();
                            beCompra.tasaPercepcion = columnNames[24].Trim().ToUpper();
                            beCompra.seriePercepcion = columnNames[25].Trim().ToUpper();
                            beCompra.numDocPercepcion = columnNames[26].Trim().ToUpper();
                            beCompra.tipoTabla10 = columnNames[27].Trim().ToUpper();
                            beCompra.serieDocOriginal = columnNames[28].Trim().ToUpper();
                            beCompra.numDocOriginal = columnNames[29].Trim().ToUpper();
                            beCompra.fechaDocOriginal = columnNames[30].Trim().ToUpper();
                            beCompra.baseImponibleOperGravadaNC = columnNames[31].Trim().ToUpper();
                            beCompra.IGVNC = columnNames[32].Trim().ToUpper();
                            lstCompras.Add(beCompra);
                        }

                        //Log_ImportarDA LOGIDA = new Log_ImportarDA();
                        //LOGIDA.Limpiar_Log();

                        ComprasDA DA = new ComprasDA();
                        return DA.INSListCompras(lstCompras, userLocal, idarchivo);
                    }
                    else
                    {
                        throw new Exception(resp);
                    }
                }
                else
                {
                    throw new Exception("El archivo ya se cargo anteriormente");
                }
            }
            catch (Exception ex)
            {
                return "0|  " + ex.Message;
            }
            //    }
            //    else
            //    {
            //        return resp;
            //    }
            //}
            //else
            //{
            //    return "0:El archivo ya se cargo anteriormente";
            //}


        }
        public string Tipo_CambioImportBL(string filename, string delimiter, BEUser userLocal)
        {
            //  Create the new table            

            List<BETipo_Cambio> lstTipo_Cambio = new List<BETipo_Cambio>();
            BETipo_Cambio beTipo_Cambio = new BETipo_Cambio();

            List<string> lista = new List<string>();

            //obtengo los datos del fichero. 

            using (StreamReader fic = new StreamReader(filename))
            {
                string linea = null;
                linea = fic.ReadLine();
                while ((linea != null))
                {
                    lista.Add(linea);
                    linea = fic.ReadLine();
                }
                fic.Close();
            }
            foreach (string registro in lista)
            {
                string[] columnNames = null;
                beTipo_Cambio = new BETipo_Cambio();
                columnNames = registro.Split('|');

                if (columnNames.Length <= 1) throw new Exception("Existe una linea no valida");

                beTipo_Cambio.Fecha_TC = columnNames[0].Trim();
                beTipo_Cambio.PromPonderado_Compra_TC = columnNames[1].Trim();
                beTipo_Cambio.PromPonderado_Venta_TC = columnNames[2].Trim();
                lstTipo_Cambio.Add(beTipo_Cambio);
            }

            Log_ImportarDA LOGIDA = new Log_ImportarDA();
            LOGIDA.Limpiar_Log();

            ComprasDA DA = new ComprasDA();
            return DA.INSListTipo_Cambio(lstTipo_Cambio, userLocal);
        }

        public List<BELog_Importar> GetLog_Importar()
        {
            Log_ImportarDA getLog_Importar = new Log_ImportarDA();
            return getLog_Importar.GetImportar_DA();
        }
    }
}