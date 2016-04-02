using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SummitPDB.BusinessEntities;
using System.Data.Common;
using System.Data;
using SummitPDB.ExceptionManagment;
using System.Transactions;

namespace SummitPDB.DataAccess
{
    public class VentasDA : DataAccesBase
    {
        Database dbSQL;
        public VentasDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        /*Select*/
        public List<BEVentas> GetVentas(BEVentas prmBE)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEVentas> lstBE = new List<BEVentas>();
                BEVentas BE = new BEVentas();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_VENTAS_PERIODO"))
                {
                    if (string.IsNullOrEmpty(prmBE.codLocal))
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, prmBE.codLocal);                    

                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, prmBE.codPeriodo);
                    dbSQL.AddInParameter(dbCmd, "@tipo", DbType.String, prmBE.tipoPrmSearch);
                    if (string.IsNullOrEmpty(prmBE.textPrmSearch)) dbSQL.AddInParameter(dbCmd, "@PrmBuscado", DbType.String, DBNull.Value);
                    else dbSQL.AddInParameter(dbCmd, "@PrmBuscado", DbType.String, prmBE.textPrmSearch);

                    if (string.IsNullOrEmpty(prmBE.prmDesde))
                        dbSQL.AddInParameter(dbCmd, "@fDesde", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@fDesde", DbType.String, prmBE.prmDesde);
                    if (string.IsNullOrEmpty(prmBE.prmHasta))
                        dbSQL.AddInParameter(dbCmd, "@fHasta", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@fHasta", DbType.String, prmBE.prmHasta);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int tipoVenta = dataReader.GetOrdinal("tipoVenta");
                        int tipo = dataReader.GetOrdinal("tipo");
                        int fechaEmision = dataReader.GetOrdinal("fechaEmision");
                        int serie = dataReader.GetOrdinal("serie");
                        int numero = dataReader.GetOrdinal("numero");
                        int tipoPersona = dataReader.GetOrdinal("tipoPersona");
                        int tipoDocPersona = dataReader.GetOrdinal("tipoDocPersona");
                        int numDocumento = dataReader.GetOrdinal("numDocumento");
                        int razonSocialCliente = dataReader.GetOrdinal("razonSocialCliente");
                        int apePaterno = dataReader.GetOrdinal("apePaterno");
                        int apeMaterno = dataReader.GetOrdinal("apeMaterno");
                        int nombre1 = dataReader.GetOrdinal("nombre1");
                        int nombre2 = dataReader.GetOrdinal("nombre2");
                        int tipoMoneda = dataReader.GetOrdinal("tipoMoneda");
                        int codDestino = dataReader.GetOrdinal("codDestino");
                        int numeroDestino = dataReader.GetOrdinal("numeroDestino");
                        int baseImponibleOperGravada = dataReader.GetOrdinal("baseImponibleOperGravada");
                        int isc = dataReader.GetOrdinal("isc");
                        int igv = dataReader.GetOrdinal("igv");
                        int otros = dataReader.GetOrdinal("otros");
                        int indicePercepcion = dataReader.GetOrdinal("indicePercepcion");
                        int tasaPercepcion = dataReader.GetOrdinal("tasaPercepcion");
                        int seriePercepcion = dataReader.GetOrdinal("seriePercepcion");
                        int numDocPercepcion = dataReader.GetOrdinal("numDocPercepcion");
                        int tipoTabla10 = dataReader.GetOrdinal("tipoTabla10");
                        int serieDocOriginal = dataReader.GetOrdinal("serieDocOriginal");
                        int numDocOriginal = dataReader.GetOrdinal("numDocOriginal");
                        int fechaDocOriginal = dataReader.GetOrdinal("fechaDocOriginal");
                        int baseImponibleOperGravadaNC = dataReader.GetOrdinal("baseImponibleOperGravadaNC");
                        int IGVNC = dataReader.GetOrdinal("IGVNC");
                        int idVentas = dataReader.GetOrdinal("idVentas");
                        int codLocal = dataReader.GetOrdinal("codLocal");
                        int Num_SAP = dataReader.GetOrdinal("Num_SAP");
                        int Fec_Contabilizacion = dataReader.GetOrdinal("Fec_Contabilizacion");
                        int Uni_Negocio = dataReader.GetOrdinal("Uni_Negocio");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            BE = new BEVentas();
                            BE.tipoVenta = values[tipoVenta] == DBNull.Value ? string.Empty : values[tipoVenta].ToString();
                            BE.tipo = values[tipo] == DBNull.Value ? string.Empty : values[tipo].ToString();
                            BE.fechaEmision = values[fechaEmision] == DBNull.Value ? string.Empty : values[fechaEmision].ToString();
                            BE.serie = values[serie] == DBNull.Value ? string.Empty : values[serie].ToString();
                            BE.numero = values[numero] == DBNull.Value ? string.Empty : values[numero].ToString();
                            BE.tipoPersona = values[tipoPersona] == DBNull.Value ? string.Empty : values[tipoPersona].ToString();
                            BE.tipoDocPersona = values[tipoDocPersona] == DBNull.Value ? string.Empty : values[tipoDocPersona].ToString();
                            BE.numDocumento = values[numDocumento] == DBNull.Value ? string.Empty : values[numDocumento].ToString();
                            BE.razonSocialCliente = values[razonSocialCliente] == DBNull.Value ? string.Empty : values[razonSocialCliente].ToString();
                            BE.apePaterno = values[apePaterno] == DBNull.Value ? string.Empty : values[apePaterno].ToString();
                            BE.apeMaterno = values[apeMaterno] == DBNull.Value ? string.Empty : values[apeMaterno].ToString();
                            BE.nombre1 = values[nombre1] == DBNull.Value ? string.Empty : values[nombre1].ToString();
                            BE.nombre2 = values[nombre2] == DBNull.Value ? string.Empty : values[nombre2].ToString();
                            BE.tipoMoneda = values[tipoMoneda] == DBNull.Value ? string.Empty : values[tipoMoneda].ToString();
                            BE.codDestino = values[codDestino] == DBNull.Value ? string.Empty : values[codDestino].ToString();
                            BE.numeroDestino = values[numeroDestino] == DBNull.Value ? string.Empty : values[numeroDestino].ToString();
                            BE.baseImponibleOperGravada = values[baseImponibleOperGravada] == DBNull.Value ? string.Empty : values[baseImponibleOperGravada].ToString();
                            BE.isc = values[isc] == DBNull.Value ? string.Empty : values[isc].ToString();
                            BE.igv = values[igv] == DBNull.Value ? string.Empty : values[igv].ToString();
                            BE.otros = values[otros] == DBNull.Value ? string.Empty : values[otros].ToString();
                            BE.indicePercepcion = values[indicePercepcion] == DBNull.Value ? string.Empty : values[indicePercepcion].ToString();
                            BE.tasaPercepcion = values[tasaPercepcion] == DBNull.Value ? string.Empty : values[tasaPercepcion].ToString();
                            BE.seriePercepcion = values[seriePercepcion] == DBNull.Value ? string.Empty : values[seriePercepcion].ToString();
                            BE.numDocPercepcion = values[numDocPercepcion] == DBNull.Value ? string.Empty : values[numDocPercepcion].ToString();
                            BE.tipoTabla10 = values[tipoTabla10] == DBNull.Value ? string.Empty : values[tipoTabla10].ToString();
                            BE.serieDocOriginal = values[serieDocOriginal] == DBNull.Value ? string.Empty : values[serieDocOriginal].ToString();
                            BE.numDocOriginal = values[numDocOriginal] == DBNull.Value ? string.Empty : values[numDocOriginal].ToString();
                            BE.fechaDocOriginal = values[fechaDocOriginal] == DBNull.Value ? string.Empty : values[fechaDocOriginal].ToString();
                            BE.baseImponibleOperGravadaNC = values[baseImponibleOperGravadaNC] == DBNull.Value ? string.Empty : values[baseImponibleOperGravadaNC].ToString();
                            BE.IGVNC = values[IGVNC] == DBNull.Value ? string.Empty : values[IGVNC].ToString();
                            BE.idVentas = values[idVentas] == DBNull.Value ? string.Empty : values[idVentas].ToString();
                            BE.codLocal = values[codLocal] == DBNull.Value ? string.Empty : values[codLocal].ToString();
                            BE.Num_SAP = values[Num_SAP] == DBNull.Value ? string.Empty : values[Num_SAP].ToString();
                            BE.Fec_Contabilizacion = values[Fec_Contabilizacion] == DBNull.Value ? string.Empty : values[Fec_Contabilizacion].ToString();
                            BE.Uni_Negocio = values[Uni_Negocio] == DBNull.Value ? string.Empty : values[Uni_Negocio].ToString();
                            lstBE.Add(BE);
                        }
                    }
                    return lstBE;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                return null;
            }
            finally
            {

            }
        }
        /*Insert*/
        public string InsVentas(BEVentas BE)
        {
            string respuesta = string.Empty;
            try
            {
                BEHotel User = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_VENTAS_INS"))
                {
                    dbSQL.AddInParameter(dbCmd, "@tipoVenta", DbType.String, BE.tipoVenta.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipo", DbType.String, BE.tipo.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@fechaEmision", DbType.String, BE.fechaEmision.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@serie", DbType.String, BE.serie.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numero", DbType.String, BE.numero.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipoPersona", DbType.String, BE.tipoPersona.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipoDocPersona", DbType.String, BE.tipoDocPersona.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numDocumento", DbType.String, BE.numDocumento.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@razonSocialCliente", DbType.String, BE.razonSocialCliente.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@apePaterno", DbType.String, BE.apePaterno.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@apeMaterno", DbType.String, BE.apeMaterno.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@nombre1", DbType.String, BE.nombre1.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@nombre2", DbType.String, BE.nombre2.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipoMoneda", DbType.String, BE.tipoMoneda.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@codDestino", DbType.String, BE.codDestino.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numeroDestino", DbType.String, BE.numeroDestino.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@baseImponibleOperGravada", DbType.String, BE.baseImponibleOperGravada.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@isc", DbType.String, BE.isc.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@igv", DbType.String, BE.igv.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@otros", DbType.String, BE.otros.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@indicePercepcion", DbType.String, BE.indicePercepcion.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tasaPercepcion", DbType.String, BE.tasaPercepcion.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@seriePercepcion", DbType.String, BE.seriePercepcion.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numDocPercepcion", DbType.String, BE.numDocPercepcion.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipoTabla10", DbType.String, BE.tipoTabla10.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@serieDocOriginal", DbType.String, BE.serieDocOriginal.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numDocOriginal", DbType.String, BE.numDocOriginal.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@fechaDocOriginal", DbType.String, BE.fechaDocOriginal.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@baseImponibleOperGravadaNC", DbType.String, BE.baseImponibleOperGravadaNC.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@IGVNC", DbType.String, BE.IGVNC.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, BE.codLocal.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@Num_SAP", DbType.String, string.Empty);
                    dbSQL.AddInParameter(dbCmd, "@Fec_Contabilizacion", DbType.String, string.Empty);
                    dbSQL.AddInParameter(dbCmd, "@Uni_Negocio", DbType.String, null);
                    dbSQL.AddInParameter(dbCmd, "@idarchivo", DbType.String, DBNull.Value);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("respuesta");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                        }
                    }
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                return "0|" + ex.Message;
            }
            finally
            {

            }
        }
        /*Update*/
        public string UpdVentas(BEVentas BE)
        {
            string respuesta = string.Empty;
            try
            {
                BEHotel User = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_VENTAS_UPD"))
                {
                    dbSQL.AddInParameter(dbCmd, "@idVentas", DbType.String, BE.idVentas.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipoVenta", DbType.String, BE.tipoVenta.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipo", DbType.String, BE.tipo.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@fechaEmision", DbType.String, BE.fechaEmision.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@serie", DbType.String, BE.serie.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numero", DbType.String, BE.numero.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipoPersona", DbType.String, BE.tipoPersona.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipoDocPersona", DbType.String, BE.tipoDocPersona.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numDocumento", DbType.String, BE.numDocumento.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@razonSocialCliente", DbType.String, BE.razonSocialCliente.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@apePaterno", DbType.String, BE.apePaterno.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@apeMaterno", DbType.String, BE.apeMaterno.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@nombre1", DbType.String, BE.nombre1.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@nombre2", DbType.String, BE.nombre2.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipoMoneda", DbType.String, BE.tipoMoneda.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@codDestino", DbType.String, BE.codDestino.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numeroDestino", DbType.String, BE.numeroDestino.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@baseImponibleOperGravada", DbType.String, BE.baseImponibleOperGravada.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@isc", DbType.String, BE.isc.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@igv", DbType.String, BE.igv.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@otros", DbType.String, BE.otros.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@indicePercepcion", DbType.String, BE.indicePercepcion.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tasaPercepcion", DbType.String, BE.tasaPercepcion.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@seriePercepcion", DbType.String, BE.seriePercepcion.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numDocPercepcion", DbType.String, BE.numDocPercepcion.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@tipoTabla10", DbType.String, BE.tipoTabla10.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@serieDocOriginal", DbType.String, BE.serieDocOriginal.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@numDocOriginal", DbType.String, BE.numDocOriginal.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@fechaDocOriginal", DbType.String, BE.fechaDocOriginal.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@baseImponibleOperGravadaNC", DbType.String, BE.baseImponibleOperGravadaNC.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@IGVNC", DbType.String, BE.IGVNC.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, BE.codLocal.ToUpper());
                    //dbSQL.AddInParameter(dbCmd, "@Num_SAP", DbType.String, BE.Num_SAP.ToUpper());
                    //dbSQL.AddInParameter(dbCmd, "@Fec_Contabilizacion", DbType.String, BE.Fec_Contabilizacion.ToUpper());
                    //dbSQL.AddInParameter(dbCmd, "@Uni_Negocio", DbType.String, BE.Uni_Negocio.ToUpper());

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("respuesta");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                        }
                    }
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                return "0|" + ex.Message;
            }
            finally
            {

            }
        }
        /*Delete*/
        public string DelVentas(BEVentas BE)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_VENTAS_DEL"))
                {
                    dbSQL.AddInParameter(dbCmd, "@idVentas", DbType.String, BE.idVentas);
                    dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, BE.numero);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("respuesta");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                        }
                    }
                    return respuesta.Substring(0, 1);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                return "0";
            }
            finally
            {

            }
        }

        /**/
        public string INSListVentas(List<BEVentas> lstVentas, BEUser UserLocal, string idarchivo)
        {
            string respuesta = string.Empty;
            try
            {
                BEVentas User = new BEVentas();
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (BEVentas BE in lstVentas)
                    {
                        using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_VENTAS_INS"))
                        {
                            dbSQL.AddInParameter(dbCmd, "@tipoVenta", DbType.String, BE.tipoVenta);
                            dbSQL.AddInParameter(dbCmd, "@tipo", DbType.String, BE.tipo);
                            dbSQL.AddInParameter(dbCmd, "@fechaEmision", DbType.String, BE.fechaEmision);
                            dbSQL.AddInParameter(dbCmd, "@serie", DbType.String, BE.serie);
                            dbSQL.AddInParameter(dbCmd, "@numero", DbType.String, BE.numero);
                            dbSQL.AddInParameter(dbCmd, "@tipoPersona", DbType.String, BE.tipoPersona);
                            dbSQL.AddInParameter(dbCmd, "@tipoDocPersona", DbType.String, BE.tipoDocPersona);
                            dbSQL.AddInParameter(dbCmd, "@numDocumento", DbType.String, BE.numDocumento);
                            dbSQL.AddInParameter(dbCmd, "@razonSocialCliente", DbType.String, BE.razonSocialCliente);
                            dbSQL.AddInParameter(dbCmd, "@apePaterno", DbType.String, BE.apePaterno);
                            dbSQL.AddInParameter(dbCmd, "@apeMaterno", DbType.String, BE.apeMaterno);
                            dbSQL.AddInParameter(dbCmd, "@nombre1", DbType.String, BE.nombre1);
                            dbSQL.AddInParameter(dbCmd, "@nombre2", DbType.String, BE.nombre2);
                            dbSQL.AddInParameter(dbCmd, "@tipoMoneda", DbType.String, BE.tipoMoneda);
                            dbSQL.AddInParameter(dbCmd, "@codDestino", DbType.String, BE.codDestino);
                            dbSQL.AddInParameter(dbCmd, "@numeroDestino", DbType.String, BE.numeroDestino);
                            dbSQL.AddInParameter(dbCmd, "@baseImponibleOperGravada", DbType.String, BE.baseImponibleOperGravada);
                            dbSQL.AddInParameter(dbCmd, "@isc", DbType.String, BE.isc);
                            dbSQL.AddInParameter(dbCmd, "@igv", DbType.String, BE.igv.Equals("0.00") ? "" : BE.igv);
                            dbSQL.AddInParameter(dbCmd, "@otros", DbType.String, BE.otros);
                            dbSQL.AddInParameter(dbCmd, "@indicePercepcion", DbType.String, BE.indicePercepcion);
                            dbSQL.AddInParameter(dbCmd, "@tasaPercepcion", DbType.String, BE.tasaPercepcion);
                            dbSQL.AddInParameter(dbCmd, "@seriePercepcion", DbType.String, BE.seriePercepcion);
                            dbSQL.AddInParameter(dbCmd, "@numDocPercepcion", DbType.String, BE.numDocPercepcion);
                            dbSQL.AddInParameter(dbCmd, "@tipoTabla10", DbType.String, BE.tipoTabla10);
                            dbSQL.AddInParameter(dbCmd, "@serieDocOriginal", DbType.String, BE.serieDocOriginal);
                            dbSQL.AddInParameter(dbCmd, "@numDocOriginal", DbType.String, BE.numDocOriginal);
                            dbSQL.AddInParameter(dbCmd, "@fechaDocOriginal", DbType.String, BE.fechaDocOriginal);
                            dbSQL.AddInParameter(dbCmd, "@baseImponibleOperGravadaNC", DbType.String, BE.baseImponibleOperGravadaNC);
                            dbSQL.AddInParameter(dbCmd, "@IGVNC", DbType.String, BE.IGVNC.Equals("0.00") ? "" : BE.IGVNC);
                            dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, UserLocal.codLocal);
                            dbSQL.AddInParameter(dbCmd, "@Num_SAP", DbType.String, BE.Num_SAP);
                            dbSQL.AddInParameter(dbCmd, "@Fec_Contabilizacion", DbType.String, BE.Fec_Contabilizacion);
                            dbSQL.AddInParameter(dbCmd, "@Uni_Negocio", DbType.String, BE.Uni_Negocio);
                            dbSQL.AddInParameter(dbCmd, "@idarchivo", DbType.String, idarchivo);

                            using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                            {
                                int index1 = dataReader.GetOrdinal("respuesta");
                                object[] values = new object[dataReader.FieldCount];
                                while (dataReader.Read())
                                {
                                    dataReader.GetValues(values);
                                    respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                                }
                            }
                        }
                    }
                    scope.Complete();
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                //return "0|" + ex.Message;
                return "0|" + ex.Message.Replace("0|", "");
            }
            finally
            {

            }
        }


        public string UpdListVentas(List<BEVentas> lstVentas)
        {
            string respuesta = string.Empty;
            try
            {
                BEVentas User = new BEVentas();
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (BEVentas users in lstVentas)
                    {
                        using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_VENTAS_UPD"))
                        {
                            dbSQL.AddInParameter(dbCmd, "@idVentas", DbType.String, users.idVentas);
                            dbSQL.AddInParameter(dbCmd, "@tipoVenta", DbType.String, users.tipoVenta);
                            dbSQL.AddInParameter(dbCmd, "@tipo", DbType.String, users.tipo);
                            dbSQL.AddInParameter(dbCmd, "@fechaEmision", DbType.String, users.fechaEmision);
                            dbSQL.AddInParameter(dbCmd, "@serie", DbType.String, users.serie);
                            dbSQL.AddInParameter(dbCmd, "@numero", DbType.String, users.numero);
                            dbSQL.AddInParameter(dbCmd, "@tipoPersona", DbType.String, users.tipoPersona);
                            dbSQL.AddInParameter(dbCmd, "@tipoDocPersona", DbType.String, users.tipoDocPersona);
                            dbSQL.AddInParameter(dbCmd, "@numDocumento", DbType.String, users.numDocumento);
                            dbSQL.AddInParameter(dbCmd, "@razonSocialCliente", DbType.String, users.razonSocialCliente);
                            dbSQL.AddInParameter(dbCmd, "@apePaterno", DbType.String, users.apePaterno);
                            dbSQL.AddInParameter(dbCmd, "@apeMaterno", DbType.String, users.apeMaterno);
                            dbSQL.AddInParameter(dbCmd, "@nombre1", DbType.String, users.nombre1);
                            dbSQL.AddInParameter(dbCmd, "@nombre2", DbType.String, users.nombre2);
                            dbSQL.AddInParameter(dbCmd, "@tipoMoneda", DbType.String, users.tipoMoneda);
                            dbSQL.AddInParameter(dbCmd, "@codDestino", DbType.String, users.codDestino);
                            dbSQL.AddInParameter(dbCmd, "@numeroDestino", DbType.String, users.numeroDestino);
                            dbSQL.AddInParameter(dbCmd, "@baseImponibleOperGravada", DbType.String, users.baseImponibleOperGravada);
                            dbSQL.AddInParameter(dbCmd, "@isc", DbType.String, users.isc);
                            dbSQL.AddInParameter(dbCmd, "@igv", DbType.String, users.igv);
                            dbSQL.AddInParameter(dbCmd, "@otros", DbType.String, users.otros);
                            dbSQL.AddInParameter(dbCmd, "@indicePercepcion", DbType.String, users.indicePercepcion);
                            dbSQL.AddInParameter(dbCmd, "@tasaPercepcion", DbType.String, users.tasaPercepcion);
                            dbSQL.AddInParameter(dbCmd, "@seriePercepcion", DbType.String, users.seriePercepcion);
                            dbSQL.AddInParameter(dbCmd, "@numDocPercepcion", DbType.String, users.numDocPercepcion);
                            dbSQL.AddInParameter(dbCmd, "@tipoTabla10", DbType.String, users.tipoTabla10);
                            dbSQL.AddInParameter(dbCmd, "@serieDocOriginal", DbType.String, users.serieDocOriginal);
                            dbSQL.AddInParameter(dbCmd, "@numDocOriginal", DbType.String, users.numDocOriginal);
                            dbSQL.AddInParameter(dbCmd, "@fechaDocOriginal", DbType.String, users.fechaDocOriginal);
                            dbSQL.AddInParameter(dbCmd, "@baseImponibleOperGravadaNC", DbType.String, users.baseImponibleOperGravadaNC);
                            dbSQL.AddInParameter(dbCmd, "@IGVNC", DbType.String, users.IGVNC);
                            dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, users.codLocal);
                            //dbSQL.AddInParameter(dbCmd, "@Num_SAP", DbType.String, users.Num_SAP);
                            //dbSQL.AddInParameter(dbCmd, "@Fec_Contabilizacion", DbType.String, users.Fec_Contabilizacion);
                            //dbSQL.AddInParameter(dbCmd, "@Uni_Negocio", DbType.String, users.Uni_Negocio);

                            using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                            {
                                int index1 = dataReader.GetOrdinal("respuesta");
                                object[] values = new object[dataReader.FieldCount];
                                while (dataReader.Read())
                                {
                                    dataReader.GetValues(values);
                                    respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                                }
                            }
                        }
                    }
                    scope.Complete();
                }
                return respuesta.Substring(0, 1);
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                return "0";
            }
            finally
            {

            }
        }
    }
}