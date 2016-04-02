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
    public class ComprasDA : DataAccesBase
    {
        Database dbSQL;
        public ComprasDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        /*Select*/
        public List<BECompras> GetCompras(BECompras prmBE)
        {
            string respuesta = string.Empty;
            try
            {
                List<BECompras> lstBE = new List<BECompras>();
                BECompras BE = new BECompras();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_COMPRAS_PERIODO"))
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
                        int idCompras = dataReader.GetOrdinal("idCompras");
                        int codLocal = dataReader.GetOrdinal("codLocal");

                        int Num_Correlativo = dataReader.GetOrdinal("Num_Correlativo");
                        int Fec_Contabilizacion = dataReader.GetOrdinal("Fec_Contabilizacion");
                        int Uni_Negocio = dataReader.GetOrdinal("Uni_Negocio");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            BE = new BECompras();
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
                            BE.idCompras = values[idCompras] == DBNull.Value ? string.Empty : values[idCompras].ToString();
                            BE.codLocal = values[codLocal] == DBNull.Value ? string.Empty : values[codLocal].ToString();
                            BE.Num_Correlativo = values[Num_Correlativo] == DBNull.Value ? string.Empty : values[Num_Correlativo].ToString();
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

        public string INSListCompras(List<BECompras> lstCompras, BEUser UserLocal, string idarchivo)
        {
            string respuesta = string.Empty;
            try
            {
                BECompras User = new BECompras();
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (BECompras BE in lstCompras)
                    {
                        using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_COMPRAS_INS"))
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
                            dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, UserLocal.codLocal.ToUpper());
                            dbSQL.AddInParameter(dbCmd, "@Num_Correlativo", DbType.String, BE.Num_Correlativo.ToUpper());
                            dbSQL.AddInParameter(dbCmd, "@Fec_Contabilizacion", DbType.String, BE.Fec_Contabilizacion.ToUpper());
                            dbSQL.AddInParameter(dbCmd, "@Uni_Negocio", DbType.String, BE.Uni_Negocio.ToUpper());
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
                return "0|" + ex.Message.Replace("0|","");
            }
            finally
            {

            }
        }
        /*Delete*/
        public string DelCompras(BECompras BE)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_COMPRAS_DEL"))
                {
                    dbSQL.AddInParameter(dbCmd, "@idCompras", DbType.String, BE.idCompras);

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
        public string InsCompras(BECompras BE)
        {
            string respuesta = string.Empty;
            try
            {
                BEHotel User = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_COMPRAS_INS"))
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
                    dbSQL.AddInParameter(dbCmd, "@otros", DbType.String, BE.otros);
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

                    dbSQL.AddInParameter(dbCmd, "@Num_Correlativo", DbType.String, BE.Num_Correlativo.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@Fec_Contabilizacion", DbType.String, BE.Fec_Contabilizacion.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@Uni_Negocio", DbType.String, BE.Uni_Negocio.ToUpper());
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

        public string UpdCompras(BECompras BE)
        {
            string respuesta = string.Empty;
            try
            {
                BEHotel User = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_COMPRAS_UPD"))
                {
                    dbSQL.AddInParameter(dbCmd, "@idCompras", DbType.String, BE.idCompras.ToUpper());
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
                    dbSQL.AddInParameter(dbCmd, "@otros", DbType.String, BE.otros);
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
                    //dbSQL.AddInParameter(dbCmd, "@Num_Correlativo", DbType.String, BE.Num_Correlativo.ToUpper());
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
        public string INSListTipo_Cambio(List<BETipo_Cambio> lstipo_Cambio, BEUser UserLocal)
        {
            string respuesta = string.Empty;
            try
            {
                BETipo_Cambio User = new BETipo_Cambio();
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (BETipo_Cambio BE in lstipo_Cambio)
                    {
                        using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_TIPO_CAMBIO_INS"))
                        {
                            dbSQL.AddInParameter(dbCmd, "@Fecha", DbType.String, BE.Fecha_TC);
                            dbSQL.AddInParameter(dbCmd, "@Promedio_Compra", DbType.String, BE.PromPonderado_Compra_TC);
                            dbSQL.AddInParameter(dbCmd, "@Promedio_Venta", DbType.String, BE.PromPonderado_Venta_TC);

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
