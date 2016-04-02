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
    public class HotelsDA : DataAccesBase
    {
        Database dbSQL;
        public HotelsDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        /*Select*/
        public List<BEHotel> GetHotelsAnteriores(BEHotel BEHotel)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEHotel> Hotels = new List<BEHotel>();
                BEHotel Hotel = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_DUPLICAR_REGISTROS"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, BEHotel.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, BEHotel.codPeriodo);
                    dbSQL.AddInParameter(dbCmd, "@idHospedaje", DbType.String, BEHotel.idHospedaje);
                    dbSQL.AddInParameter(dbCmd, "@fechaDocumento", DbType.String, BEHotel.fechaDocumento);
                    dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, BEHotel.correlativo);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int fechaDocumento = dataReader.GetOrdinal("fechaDocumento");
                        int serie = dataReader.GetOrdinal("serie");
                        int correlativo = dataReader.GetOrdinal("correlativo");
                        int agencia = dataReader.GetOrdinal("agencia");
                        int ruc = dataReader.GetOrdinal("ruc");
                        int pasaporte = dataReader.GetOrdinal("pasaporte");
                        int paisPasaporte = dataReader.GetOrdinal("paisPasaporte");
                        int apellidoMaterno = dataReader.GetOrdinal("apellidoMaterno");
                        int apellidoPaterno = dataReader.GetOrdinal("apellidoPaterno");
                        int nombre = dataReader.GetOrdinal("nombre");
                        int segundoNombre = dataReader.GetOrdinal("segundoNombre");
                        int fechaIngresoHotel = dataReader.GetOrdinal("fechaIngresoHotel");
                        int fechaSalidaHotel = dataReader.GetOrdinal("fechaSalidaHotel");
                        int nroFicha = dataReader.GetOrdinal("nroFicha");
                        int unidad = dataReader.GetOrdinal("unidad");
                        int ingresoPais = dataReader.GetOrdinal("ingresoPais");
                        int x = dataReader.GetOrdinal("x");
                        int y = dataReader.GetOrdinal("y");
                        int idHospedaje = dataReader.GetOrdinal("idHospedaje");
                        int fechaProceso = dataReader.GetOrdinal("fechaProceso");
                        int codLocal = dataReader.GetOrdinal("codLocal");
                        //int codPeriodo = dataReader.GetOrdinal("codPeriodoEmpresa");
                        int paisProcedencia = dataReader.GetOrdinal("paisProcedencia");
                        int flagValidacion = dataReader.GetOrdinal("flagValidacion");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            Hotel = new BEHotel();
                            Hotel.fechaDocumento = values[fechaDocumento] == DBNull.Value ? string.Empty : values[fechaDocumento].ToString();
                            Hotel.serie = values[serie] == DBNull.Value ? string.Empty : values[serie].ToString();
                            Hotel.correlativo = values[correlativo] == DBNull.Value ? string.Empty : values[correlativo].ToString();
                            Hotel.agencia = values[agencia] == DBNull.Value ? string.Empty : values[agencia].ToString();
                            Hotel.ruc = values[ruc] == DBNull.Value ? string.Empty : values[ruc].ToString();
                            Hotel.pasaporte = values[pasaporte] == DBNull.Value ? string.Empty : values[pasaporte].ToString();
                            Hotel.paisPasaporte = values[paisPasaporte] == DBNull.Value ? string.Empty : values[paisPasaporte].ToString();
                            Hotel.apellidoMaterno = values[apellidoMaterno] == DBNull.Value ? string.Empty : values[apellidoMaterno].ToString();
                            Hotel.apellidoPaterno = values[apellidoPaterno] == DBNull.Value ? string.Empty : values[apellidoPaterno].ToString();
                            Hotel.nombre = values[nombre] == DBNull.Value ? string.Empty : values[nombre].ToString();
                            Hotel.segundoNombre = values[segundoNombre] == DBNull.Value ? string.Empty : values[segundoNombre].ToString();
                            Hotel.fechaIngresoHotel = values[fechaIngresoHotel] == DBNull.Value ? string.Empty : values[fechaIngresoHotel].ToString();
                            Hotel.fechaSalidaHotel = values[fechaSalidaHotel] == DBNull.Value ? string.Empty : values[fechaSalidaHotel].ToString();
                            Hotel.nroFicha = values[nroFicha] == DBNull.Value ? string.Empty : values[nroFicha].ToString();
                            Hotel.unidad = values[unidad] == DBNull.Value ? string.Empty : values[unidad].ToString();
                            Hotel.ingresoPais = values[ingresoPais] == DBNull.Value ? string.Empty : values[ingresoPais].ToString();
                            Hotel.x = values[x] == DBNull.Value ? string.Empty : values[x].ToString();
                            Hotel.y = values[y] == DBNull.Value ? string.Empty : values[y].ToString();
                            Hotel.idHospedaje = values[idHospedaje] == DBNull.Value ? string.Empty : values[idHospedaje].ToString();
                            Hotel.fechaProceso = values[fechaProceso] == DBNull.Value ? string.Empty : values[fechaProceso].ToString();
                            Hotel.codLocal = values[codLocal] == DBNull.Value ? string.Empty : values[codLocal].ToString();
                            //Hotel.codPeriodo = values[codPeriodo] == DBNull.Value ? string.Empty : values[codPeriodo].ToString();
                            Hotel.paisProcedencia = values[paisProcedencia] == DBNull.Value ? string.Empty : values[paisProcedencia].ToString();
                            Hotel.flagValidacion = values[flagValidacion] == DBNull.Value ? string.Empty : values[flagValidacion].ToString();
                            Hotels.Add(Hotel);
                        }
                    }
                    return Hotels;
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

        public List<BEHotel> GetHotelsporCorrelativo(BEHotel BEHotel)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEHotel> Hotels = new List<BEHotel>();
                BEHotel Hotel = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_REGISTROS_HOS_CORRELATIVO"))
                {
                    dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, BEHotel.correlativo);
                    dbSQL.AddInParameter(dbCmd, "@idHospedaje", DbType.String, BEHotel.idHospedaje);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int fechaDocumento = dataReader.GetOrdinal("fechaDocumento");
                        int serie = dataReader.GetOrdinal("serie");
                        int correlativo = dataReader.GetOrdinal("correlativo");
                        int agencia = dataReader.GetOrdinal("agencia");
                        int ruc = dataReader.GetOrdinal("ruc");
                        int pasaporte = dataReader.GetOrdinal("pasaporte");
                        int paisPasaporte = dataReader.GetOrdinal("paisPasaporte");
                        int apellidoMaterno = dataReader.GetOrdinal("apellidoMaterno");
                        int apellidoPaterno = dataReader.GetOrdinal("apellidoPaterno");
                        int nombre = dataReader.GetOrdinal("nombre");
                        int segundoNombre = dataReader.GetOrdinal("segundoNombre");
                        int fechaIngresoHotel = dataReader.GetOrdinal("fechaIngresoHotel");
                        int fechaSalidaHotel = dataReader.GetOrdinal("fechaSalidaHotel");
                        int nroFicha = dataReader.GetOrdinal("nroFicha");
                        int unidad = dataReader.GetOrdinal("unidad");
                        int ingresoPais = dataReader.GetOrdinal("ingresoPais");
                        int x = dataReader.GetOrdinal("x");
                        int y = dataReader.GetOrdinal("y");
                        int idHospedaje = dataReader.GetOrdinal("idHospedaje");
                        int fechaProceso = dataReader.GetOrdinal("fechaProceso");
                        int codLocal = dataReader.GetOrdinal("codLocal");
                        //int codPeriodo = dataReader.GetOrdinal("codPeriodoEmpresa");
                        int paisProcedencia = dataReader.GetOrdinal("paisProcedencia");
                        int flagValidacion = dataReader.GetOrdinal("flagValidacion");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            Hotel = new BEHotel();
                            Hotel.fechaDocumento = values[fechaDocumento] == DBNull.Value ? string.Empty : values[fechaDocumento].ToString();
                            Hotel.serie = values[serie] == DBNull.Value ? string.Empty : values[serie].ToString();
                            Hotel.correlativo = values[correlativo] == DBNull.Value ? string.Empty : values[correlativo].ToString();
                            Hotel.agencia = values[agencia] == DBNull.Value ? string.Empty : values[agencia].ToString();
                            Hotel.ruc = values[ruc] == DBNull.Value ? string.Empty : values[ruc].ToString();
                            Hotel.pasaporte = values[pasaporte] == DBNull.Value ? string.Empty : values[pasaporte].ToString();
                            Hotel.paisPasaporte = values[paisPasaporte] == DBNull.Value ? string.Empty : values[paisPasaporte].ToString();
                            Hotel.apellidoMaterno = values[apellidoMaterno] == DBNull.Value ? string.Empty : values[apellidoMaterno].ToString();
                            Hotel.apellidoPaterno = values[apellidoPaterno] == DBNull.Value ? string.Empty : values[apellidoPaterno].ToString();
                            Hotel.nombre = values[nombre] == DBNull.Value ? string.Empty : values[nombre].ToString();
                            Hotel.segundoNombre = values[segundoNombre] == DBNull.Value ? string.Empty : values[segundoNombre].ToString();
                            Hotel.fechaIngresoHotel = values[fechaIngresoHotel] == DBNull.Value ? string.Empty : values[fechaIngresoHotel].ToString();
                            Hotel.fechaSalidaHotel = values[fechaSalidaHotel] == DBNull.Value ? string.Empty : values[fechaSalidaHotel].ToString();
                            Hotel.nroFicha = values[nroFicha] == DBNull.Value ? string.Empty : values[nroFicha].ToString();
                            Hotel.unidad = values[unidad] == DBNull.Value ? string.Empty : values[unidad].ToString();
                            Hotel.ingresoPais = values[ingresoPais] == DBNull.Value ? string.Empty : values[ingresoPais].ToString();
                            Hotel.x = values[x] == DBNull.Value ? string.Empty : values[x].ToString();
                            Hotel.y = values[y] == DBNull.Value ? string.Empty : values[y].ToString();
                            Hotel.idHospedaje = values[idHospedaje] == DBNull.Value ? string.Empty : values[idHospedaje].ToString();
                            Hotel.fechaProceso = values[fechaProceso] == DBNull.Value ? string.Empty : values[fechaProceso].ToString();
                            Hotel.codLocal = values[codLocal] == DBNull.Value ? string.Empty : values[codLocal].ToString();
                            //Hotel.codPeriodo = values[codPeriodo] == DBNull.Value ? string.Empty : values[codPeriodo].ToString();
                            Hotel.paisProcedencia = values[paisProcedencia] == DBNull.Value ? string.Empty : values[paisProcedencia].ToString();
                            Hotel.flagValidacion = values[flagValidacion] == DBNull.Value ? string.Empty : values[flagValidacion].ToString();
                            Hotels.Add(Hotel);
                        }
                    }
                    return Hotels;
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
        public List<BEHotel> GetHotelsValidados(BEHotel BEHotel)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEHotel> Hotels = new List<BEHotel>();
                BEHotel Hotel = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_REGISTROS_PERIODO_VAL"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, BEHotel.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, BEHotel.codPeriodo);
                    dbSQL.AddInParameter(dbCmd, "@tipo", DbType.String, BEHotel.tipoPrmSearch);
                    if (string.IsNullOrEmpty(BEHotel.textPrmSearch))
                        dbSQL.AddInParameter(dbCmd, "@PrmBuscado", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@PrmBuscado", DbType.String, BEHotel.textPrmSearch);
                    if (string.IsNullOrEmpty(BEHotel.prmDesde))
                        dbSQL.AddInParameter(dbCmd, "@fDesde", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@fDesde", DbType.String, BEHotel.prmDesde);
                    dbSQL.AddInParameter(dbCmd, "@fHasta", DbType.String, BEHotel.prmHasta);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int fechaDocumento = dataReader.GetOrdinal("fechaDocumento");
                        int serie = dataReader.GetOrdinal("serie");
                        int correlativo = dataReader.GetOrdinal("correlativo");
                        int agencia = dataReader.GetOrdinal("agencia");
                        int ruc = dataReader.GetOrdinal("ruc");
                        int pasaporte = dataReader.GetOrdinal("pasaporte");
                        int paisPasaporte = dataReader.GetOrdinal("paisPasaporte");
                        int apellidoMaterno = dataReader.GetOrdinal("apellidoMaterno");
                        int apellidoPaterno = dataReader.GetOrdinal("apellidoPaterno");
                        int nombre = dataReader.GetOrdinal("nombre");
                        int segundoNombre = dataReader.GetOrdinal("segundoNombre");
                        int fechaIngresoHotel = dataReader.GetOrdinal("fechaIngresoHotel");
                        int fechaSalidaHotel = dataReader.GetOrdinal("fechaSalidaHotel");
                        int nroFicha = dataReader.GetOrdinal("nroFicha");
                        int unidad = dataReader.GetOrdinal("unidad");
                        int ingresoPais = dataReader.GetOrdinal("ingresoPais");
                        int x = dataReader.GetOrdinal("x");
                        int y = dataReader.GetOrdinal("y");
                        int idHospedaje = dataReader.GetOrdinal("idHospedaje");
                        int fechaProceso = dataReader.GetOrdinal("fechaProceso");
                        int codLocal = dataReader.GetOrdinal("codLocal");
                        int codPeriodo = dataReader.GetOrdinal("codPeriodoEmpresa");
                        int paisProcedencia = dataReader.GetOrdinal("paisProcedencia");
                        int flagValidacion = dataReader.GetOrdinal("flagValidacion");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            Hotel = new BEHotel();
                            Hotel.fechaDocumento = values[fechaDocumento] == DBNull.Value ? string.Empty : values[fechaDocumento].ToString();
                            Hotel.serie = values[serie] == DBNull.Value ? string.Empty : values[serie].ToString();
                            Hotel.correlativo = values[correlativo] == DBNull.Value ? string.Empty : values[correlativo].ToString();
                            Hotel.agencia = values[agencia] == DBNull.Value ? string.Empty : values[agencia].ToString();
                            Hotel.ruc = values[ruc] == DBNull.Value ? string.Empty : values[ruc].ToString();
                            Hotel.pasaporte = values[pasaporte] == DBNull.Value ? string.Empty : values[pasaporte].ToString();
                            Hotel.paisPasaporte = values[paisPasaporte] == DBNull.Value ? string.Empty : values[paisPasaporte].ToString();
                            Hotel.apellidoMaterno = values[apellidoMaterno] == DBNull.Value ? string.Empty : values[apellidoMaterno].ToString();
                            Hotel.apellidoPaterno = values[apellidoPaterno] == DBNull.Value ? string.Empty : values[apellidoPaterno].ToString();
                            Hotel.nombre = values[nombre] == DBNull.Value ? string.Empty : values[nombre].ToString();
                            Hotel.segundoNombre = values[segundoNombre] == DBNull.Value ? string.Empty : values[segundoNombre].ToString();
                            Hotel.fechaIngresoHotel = values[fechaIngresoHotel] == DBNull.Value ? string.Empty : values[fechaIngresoHotel].ToString();
                            Hotel.fechaSalidaHotel = values[fechaSalidaHotel] == DBNull.Value ? string.Empty : values[fechaSalidaHotel].ToString();
                            Hotel.nroFicha = values[nroFicha] == DBNull.Value ? string.Empty : values[nroFicha].ToString();
                            Hotel.unidad = values[unidad] == DBNull.Value ? string.Empty : values[unidad].ToString();
                            Hotel.ingresoPais = values[ingresoPais] == DBNull.Value ? string.Empty : values[ingresoPais].ToString();
                            Hotel.x = values[x] == DBNull.Value ? string.Empty : values[x].ToString();
                            Hotel.y = values[y] == DBNull.Value ? string.Empty : values[y].ToString();
                            Hotel.idHospedaje = values[idHospedaje] == DBNull.Value ? string.Empty : values[idHospedaje].ToString();
                            Hotel.fechaProceso = values[fechaProceso] == DBNull.Value ? string.Empty : values[fechaProceso].ToString();
                            Hotel.codLocal = values[codLocal] == DBNull.Value ? string.Empty : values[codLocal].ToString();
                            Hotel.codPeriodo = values[codPeriodo] == DBNull.Value ? string.Empty : values[codPeriodo].ToString();
                            Hotel.paisProcedencia = values[paisProcedencia] == DBNull.Value ? string.Empty : values[paisProcedencia].ToString();
                            Hotel.flagValidacion = values[flagValidacion] == DBNull.Value ? string.Empty : values[flagValidacion].ToString();


                            //Hotel.nDiasResidencia = Hotel.fechaIngresoHotel.



                            Hotels.Add(Hotel);
                        }
                    }
                    return Hotels;
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
        public List<BEHotel> GetHotelsAll(string codigoLocal)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEHotel> Hotels = new List<BEHotel>();
                BEHotel Hotel = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_REGISTROS_PERIODO_ALL"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, codigoLocal);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int fechaDocumento = dataReader.GetOrdinal("fechaDocumento");
                        int serie = dataReader.GetOrdinal("serie");
                        int correlativo = dataReader.GetOrdinal("correlativo");
                        int agencia = dataReader.GetOrdinal("agencia");
                        int ruc = dataReader.GetOrdinal("ruc");
                        int pasaporte = dataReader.GetOrdinal("pasaporte");
                        int paisPasaporte = dataReader.GetOrdinal("paisPasaporte");
                        int apellidoMaterno = dataReader.GetOrdinal("apellidoMaterno");
                        int apellidoPaterno = dataReader.GetOrdinal("apellidoPaterno");
                        int nombre = dataReader.GetOrdinal("nombre");
                        int segundoNombre = dataReader.GetOrdinal("segundoNombre");
                        int fechaIngresoHotel = dataReader.GetOrdinal("fechaIngresoHotel");
                        int fechaSalidaHotel = dataReader.GetOrdinal("fechaSalidaHotel");
                        int nroFicha = dataReader.GetOrdinal("nroFicha");
                        int unidad = dataReader.GetOrdinal("unidad");
                        int ingresoPais = dataReader.GetOrdinal("ingresoPais");
                        int x = dataReader.GetOrdinal("x");
                        int y = dataReader.GetOrdinal("y");
                        int idHospedaje = dataReader.GetOrdinal("idHospedaje");
                        int fechaProceso = dataReader.GetOrdinal("fechaProceso");
                        int codLocal = dataReader.GetOrdinal("codLocal");
                        int paisProcedencia = dataReader.GetOrdinal("paisProcedencia");
                        int flagValidacion = dataReader.GetOrdinal("flagValidacion");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            Hotel = new BEHotel();
                            Hotel.fechaDocumento = values[fechaDocumento] == DBNull.Value ? string.Empty : values[fechaDocumento].ToString();
                            Hotel.serie = values[serie] == DBNull.Value ? string.Empty : values[serie].ToString();
                            Hotel.correlativo = values[correlativo] == DBNull.Value ? string.Empty : values[correlativo].ToString();
                            Hotel.agencia = values[agencia] == DBNull.Value ? string.Empty : values[agencia].ToString();
                            Hotel.ruc = values[ruc] == DBNull.Value ? string.Empty : values[ruc].ToString();
                            Hotel.pasaporte = values[pasaporte] == DBNull.Value ? string.Empty : values[pasaporte].ToString();
                            Hotel.paisPasaporte = values[paisPasaporte] == DBNull.Value ? string.Empty : values[paisPasaporte].ToString();
                            Hotel.apellidoMaterno = values[apellidoMaterno] == DBNull.Value ? string.Empty : values[apellidoMaterno].ToString();
                            Hotel.apellidoPaterno = values[apellidoPaterno] == DBNull.Value ? string.Empty : values[apellidoPaterno].ToString();
                            Hotel.nombre = values[nombre] == DBNull.Value ? string.Empty : values[nombre].ToString();
                            Hotel.segundoNombre = values[segundoNombre] == DBNull.Value ? string.Empty : values[segundoNombre].ToString();
                            Hotel.fechaIngresoHotel = values[fechaIngresoHotel] == DBNull.Value ? string.Empty : values[fechaIngresoHotel].ToString();
                            Hotel.fechaSalidaHotel = values[fechaSalidaHotel] == DBNull.Value ? string.Empty : values[fechaSalidaHotel].ToString();
                            Hotel.nroFicha = values[nroFicha] == DBNull.Value ? string.Empty : values[nroFicha].ToString();
                            Hotel.unidad = values[unidad] == DBNull.Value ? string.Empty : values[unidad].ToString();
                            Hotel.ingresoPais = values[ingresoPais] == DBNull.Value ? string.Empty : values[ingresoPais].ToString();
                            Hotel.x = values[x] == DBNull.Value ? string.Empty : values[x].ToString();
                            Hotel.y = values[y] == DBNull.Value ? string.Empty : values[y].ToString();
                            Hotel.idHospedaje = values[idHospedaje] == DBNull.Value ? string.Empty : values[idHospedaje].ToString();
                            Hotel.fechaProceso = values[fechaProceso] == DBNull.Value ? string.Empty : values[fechaProceso].ToString();
                            Hotel.codLocal = values[codLocal] == DBNull.Value ? string.Empty : values[codLocal].ToString();
                            Hotel.codPeriodo = string.Empty;
                            Hotel.paisProcedencia = values[paisProcedencia] == DBNull.Value ? string.Empty : values[paisProcedencia].ToString();
                            Hotel.flagValidacion = values[flagValidacion] == DBNull.Value ? string.Empty : values[flagValidacion].ToString();
                            Hotels.Add(Hotel);
                        }
                    }
                    return Hotels;
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
        public string SetNotaCredito(string xSerieNC, string xCorrNC, string xSerieF, string xCorrF, string xfechaF)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEHotel> Hotels = new List<BEHotel>();
                BEHotel Hotel = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_SET_HOSPEDAJE"))
                {

                    if (string.IsNullOrEmpty(xSerieNC))
                        dbSQL.AddInParameter(dbCmd, "@SerieNC", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@SerieNC", DbType.String, xSerieNC);

                    if (string.IsNullOrEmpty(xCorrNC))
                        dbSQL.AddInParameter(dbCmd, "@CorrNC", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@CorrNC", DbType.String, xCorrNC);

                    if (string.IsNullOrEmpty(xSerieF))
                        dbSQL.AddInParameter(dbCmd, "@SerieF", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@SerieF", DbType.String, xSerieF);

                    if (string.IsNullOrEmpty(xCorrF))
                        dbSQL.AddInParameter(dbCmd, "@CorrF", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@CorrF", DbType.String, xCorrF);

                    if (string.IsNullOrEmpty(xfechaF))
                        dbSQL.AddInParameter(dbCmd, "@fechaF", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@fechaF", DbType.String, xfechaF);

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
                return null;
            }
            finally
            {

            }
        }
        public List<BEHotel> GetHotels(BEHotel BEHotel)
        {
            //DateTime olddate = Convert.ToDateTime("01/12/2013"); //Convert.ToDateTime(fechaIngresoHotel.ToString("dd/MM/yyyy"));
            //DateTime newdate = Convert.ToDateTime("12/01/2013"); //Convert.ToDateTime(fechaSalidaHotel.ToString("dd/MM/yyyy"));
            //int months = Math.Abs((olddate.Month + (olddate.Year * 12)) - (newdate.Month + (newdate.Year * 12)));



            string respuesta = string.Empty;
            int count = 0;
            try
            {
                List<BEHotel> Hotels = new List<BEHotel>();
                BEHotel Hotel = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_REGISTROS_PERIODO"))
                {

                    if (string.IsNullOrEmpty(BEHotel.codLocal))
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, BEHotel.codLocal);

                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, BEHotel.codPeriodo);
                    dbSQL.AddInParameter(dbCmd, "@tipo", DbType.String, BEHotel.tipoPrmSearch);
                    if (string.IsNullOrEmpty(BEHotel.textPrmSearch))
                        dbSQL.AddInParameter(dbCmd, "@PrmBuscado", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@PrmBuscado", DbType.String, BEHotel.textPrmSearch);
                    if (string.IsNullOrEmpty(BEHotel.prmDesde))
                        dbSQL.AddInParameter(dbCmd, "@fDesde", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@fDesde", DbType.String, BEHotel.prmDesde);
                    //dbSQL.AddInParameter(dbCmd, "@fHasta", DbType.String, BEHotel.prmHasta);
                    if (string.IsNullOrEmpty(BEHotel.prmHasta))
                        dbSQL.AddInParameter(dbCmd, "@fHasta", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@fHasta", DbType.String, BEHotel.prmHasta);
                    dbSQL.AddInParameter(dbCmd, "@tipoFechaPrm", DbType.Int16, BEHotel.tipoFechaPrm);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int fechaDocumento = dataReader.GetOrdinal("fechaDocumento");
                        int serie = dataReader.GetOrdinal("serie");
                        int correlativo = dataReader.GetOrdinal("correlativo");
                        int agencia = dataReader.GetOrdinal("agencia");
                        int ruc = dataReader.GetOrdinal("ruc");
                        int pasaporte = dataReader.GetOrdinal("pasaporte");
                        int paisPasaporte = dataReader.GetOrdinal("paisPasaporte");
                        int apellidoMaterno = dataReader.GetOrdinal("apellidoMaterno");
                        int apellidoPaterno = dataReader.GetOrdinal("apellidoPaterno");
                        int nombre = dataReader.GetOrdinal("nombre");
                        int segundoNombre = dataReader.GetOrdinal("segundoNombre");
                        int fechaIngresoHotel = dataReader.GetOrdinal("fechaIngresoHotel");
                        int fechaSalidaHotel = dataReader.GetOrdinal("fechaSalidaHotel");
                        int nroFicha = dataReader.GetOrdinal("nroFicha");
                        int unidad = dataReader.GetOrdinal("unidad");
                        int ingresoPais = dataReader.GetOrdinal("ingresoPais");
                        int x = dataReader.GetOrdinal("x");
                        int y = dataReader.GetOrdinal("y");
                        int idHospedaje = dataReader.GetOrdinal("idHospedaje");
                        int fechaProceso = dataReader.GetOrdinal("fechaProceso");
                        int codLocal = dataReader.GetOrdinal("codLocal");
                        int codPeriodo = dataReader.GetOrdinal("codPeriodoEmpresa");
                        int paisProcedencia = dataReader.GetOrdinal("paisProcedencia");
                        int flagValidacion = dataReader.GetOrdinal("flagValidacion");
                        int descPais_Pasap = dataReader.GetOrdinal("descPais_Pasap");
                        int descPais_Proc = dataReader.GetOrdinal("descPais_Proc");
                        object[] values = new object[dataReader.FieldCount];
                        
                        while (dataReader.Read())
                        {
                            count++;
                            dataReader.GetValues(values);
                            Hotel = new BEHotel();

                            Hotel.fechaDocumento = values[fechaDocumento] == DBNull.Value ? string.Empty : values[fechaDocumento].ToString();

                            if (!string.IsNullOrEmpty(Hotel.fechaDocumento) && Hotel.fechaDocumento.Length == 8)
                                Hotel.fechaDocumento = Hotel.fechaDocumento.Substring(6) + "/" + Hotel.fechaDocumento.Substring(4, 2) + "/" + Hotel.fechaDocumento.Substring(0, 4);
                            Hotel.serie = values[serie] == DBNull.Value ? string.Empty : values[serie].ToString();
                            Hotel.correlativo = values[correlativo] == DBNull.Value ? string.Empty : values[correlativo].ToString();
                            Hotel.agencia = values[agencia] == DBNull.Value ? string.Empty : values[agencia].ToString();
                            Hotel.ruc = values[ruc] == DBNull.Value ? string.Empty : values[ruc].ToString();
                            Hotel.pasaporte = values[pasaporte] == DBNull.Value ? string.Empty : values[pasaporte].ToString();
                            Hotel.paisPasaporte = values[paisPasaporte] == DBNull.Value ? string.Empty : values[paisPasaporte].ToString();
                            Hotel.apellidoMaterno = values[apellidoMaterno] == DBNull.Value ? string.Empty : values[apellidoMaterno].ToString();
                            Hotel.apellidoPaterno = values[apellidoPaterno] == DBNull.Value ? string.Empty : values[apellidoPaterno].ToString();
                            Hotel.nombre = values[nombre] == DBNull.Value ? string.Empty : values[nombre].ToString();
                            Hotel.segundoNombre = values[segundoNombre] == DBNull.Value ? string.Empty : values[segundoNombre].ToString();

                            Hotel.fechaIngresoHotel = values[fechaIngresoHotel] == DBNull.Value ? string.Empty : values[fechaIngresoHotel].ToString();

                            if (!string.IsNullOrEmpty(Hotel.fechaIngresoHotel) && Hotel.fechaIngresoHotel.Length == 8)
                                Hotel.fechaIngresoHotel = Hotel.fechaIngresoHotel.Substring(6) + "/" + Hotel.fechaIngresoHotel.Substring(4, 2) + "/" + Hotel.fechaIngresoHotel.Substring(0, 4);

                            Hotel.fechaSalidaHotel = values[fechaSalidaHotel] == DBNull.Value ? string.Empty : values[fechaSalidaHotel].ToString();
                            if (!string.IsNullOrEmpty(Hotel.fechaSalidaHotel) && Hotel.fechaSalidaHotel.Length == 8)
                                Hotel.fechaSalidaHotel = Hotel.fechaSalidaHotel.Substring(6) + "/" + Hotel.fechaSalidaHotel.Substring(4, 2) + "/" + Hotel.fechaSalidaHotel.Substring(0, 4);

                            Hotel.nroFicha = values[nroFicha] == DBNull.Value ? string.Empty : values[nroFicha].ToString();
                            Hotel.unidad = values[unidad] == DBNull.Value ? string.Empty : values[unidad].ToString();

                            Hotel.ingresoPais = values[ingresoPais] == DBNull.Value ? string.Empty : values[ingresoPais].ToString();
                            if (!string.IsNullOrEmpty(Hotel.ingresoPais) && Hotel.ingresoPais.Length == 8)
                                Hotel.ingresoPais = Hotel.ingresoPais.Substring(6) + "/" + Hotel.ingresoPais.Substring(4, 2) + "/" + Hotel.ingresoPais.Substring(0, 4);

                            Hotel.x = values[x] == DBNull.Value ? string.Empty : values[x].ToString();
                            Hotel.y = values[y] == DBNull.Value ? string.Empty : values[y].ToString();
                            Hotel.idHospedaje = values[idHospedaje] == DBNull.Value ? string.Empty : values[idHospedaje].ToString();
                            Hotel.fechaProceso = values[fechaProceso] == DBNull.Value ? string.Empty : values[fechaProceso].ToString();
                            Hotel.codLocal = values[codLocal] == DBNull.Value ? string.Empty : values[codLocal].ToString();
                            Hotel.codPeriodo = values[codPeriodo] == DBNull.Value ? string.Empty : values[codPeriodo].ToString();
                            Hotel.paisProcedencia = values[paisProcedencia] == DBNull.Value ? " " : values[paisProcedencia].ToString();
                            Hotel.flagValidacion = values[flagValidacion] == DBNull.Value ? string.Empty : values[flagValidacion].ToString();

                            Hotel.descPais_Pasap = values[descPais_Pasap].ToString();
                            Hotel.descPais_Proc = values[descPais_Proc].ToString();
                            if (!string.IsNullOrEmpty(Hotel.ingresoPais) & !string.IsNullOrEmpty(Hotel.fechaSalidaHotel))
                            {
                                //fechasalida hotel - fecha ingreso pais||
                                int anioIngresoPais = Convert.ToInt32(Hotel.ingresoPais.Substring(6, 4));
                                int mesIngresoPais = Convert.ToInt32(Hotel.ingresoPais.Substring(3, 2));
                                int diaIngresoPais = Convert.ToInt32(Hotel.ingresoPais.Substring(0, 2));
                                DateTime dateIngresoPais = new DateTime(anioIngresoPais, mesIngresoPais, diaIngresoPais);

                                int anioSalidaHotel = Convert.ToInt32(Hotel.fechaSalidaHotel.Substring(6, 4));
                                int mesSalidaHotel = Convert.ToInt32(Hotel.fechaSalidaHotel.Substring(3, 2));
                                int diaSalidaHotel = Convert.ToInt32(Hotel.fechaSalidaHotel.Substring(0, 2));
                                DateTime dateSalidaHotel = new DateTime(anioSalidaHotel, mesSalidaHotel, diaSalidaHotel);

                                int daysDiff = ((TimeSpan)(dateSalidaHotel - dateIngresoPais)).Days + 1;
                                Hotel.nDiasResidencia = daysDiff;
                            }
                            Hotels.Add(Hotel);
                        }
                    }
                    return Hotels;
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
        public string InsHotels(BEHotel users)
        {
            string respuesta = string.Empty;
            try
            {
                BEHotel User = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGISTROHOS_INS"))
                {
                    dbSQL.AddInParameter(dbCmd, "@fechaDocumento", DbType.String, users.fechaDocumento.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@serie", DbType.String, users.serie.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, users.correlativo.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@agencia", DbType.String, users.agencia.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@ruc", DbType.String, users.ruc.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@pasaporte", DbType.String, users.pasaporte.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@paisPasaporte", DbType.String, users.paisPasaporte.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@apellidoMaterno", DbType.String, users.apellidoMaterno.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@apellidoPaterno", DbType.String, users.apellidoPaterno.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@nombre", DbType.String, users.nombre.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@segundoNombre", DbType.String, users.segundoNombre.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@fechaIngresoHotel", DbType.String, users.fechaIngresoHotel.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@fechaSalidaHotel", DbType.String, users.fechaSalidaHotel);
                    dbSQL.AddInParameter(dbCmd, "@nroFicha", DbType.String, users.nroFicha.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@unidad", DbType.String, users.unidad.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@ingresoPais", DbType.String, users.ingresoPais.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@x", DbType.String, string.Empty);
                    dbSQL.AddInParameter(dbCmd, "@y", DbType.String, string.Empty);
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, users.codLocal.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@paisProcedencia", DbType.String, users.paisProcedencia.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@flagValidacion", DbType.String, users.flagValidacion.ToUpper());
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
        public string UpdHotels(BEHotel users)
        {
            string respuesta = string.Empty;
            try
            {
                BEHotel User = new BEHotel();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGISTROHOS_UPD"))
                {

                    dbSQL.AddInParameter(dbCmd, "@idHospedaje", DbType.String, users.idHospedaje.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@fechaDocumento", DbType.String, users.fechaDocumento.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@serie", DbType.String, users.serie.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, users.correlativo.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@ruc", DbType.String, users.ruc.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@agencia", DbType.String, users.agencia.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@pasaporte", DbType.String, users.pasaporte.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@paisPasaporte", DbType.String, users.paisPasaporte.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@apellidoMaterno", DbType.String, users.apellidoMaterno.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@apellidoPaterno", DbType.String, users.apellidoPaterno.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@nombre", DbType.String, users.nombre.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@segundoNombre", DbType.String, users.segundoNombre.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@fechaIngresoHotel", DbType.String, users.fechaIngresoHotel.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@fechaSalidaHotel", DbType.String, users.fechaSalidaHotel.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@nroFicha", DbType.String, users.nroFicha.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@unidad", DbType.String, users.unidad.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@ingresoPais", DbType.String, users.ingresoPais.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, users.codLocal.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@paisProcedencia", DbType.String, users.paisProcedencia.ToUpper());
                    dbSQL.AddInParameter(dbCmd, "@flagValidacion", DbType.String, users.flagValidacion.ToUpper());
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
        /*Delete*/
        public string DelHotels(BEHotel registro)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGISTROSHOS_DEL"))
                {
                    dbSQL.AddInParameter(dbCmd, "@idHospedaje", DbType.String, registro.idHospedaje);
                    dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, registro.correlativo);

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

        public string GetImponible(BEHotel beHotel, string tipo)
        {
            string SumaImponible = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_BASEIMPONIBLE"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, beHotel.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, beHotel.codPeriodo);
                    dbSQL.AddInParameter(dbCmd, "@tipo", DbType.String, tipo);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("SumaImponible");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            SumaImponible = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                        }
                    }
                    return SumaImponible;
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

        public string GetNumeroDocumento(BEHotel beHotel, string tipo)
        {
            string numeroDocumentos = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_NUMERO_DOCUMENTOS"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, beHotel.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, beHotel.codPeriodo);
                    dbSQL.AddInParameter(dbCmd, "@tipo", DbType.String, tipo);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("numeroDocumentos");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            numeroDocumentos = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                        }
                    }
                    return numeroDocumentos;
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
        public string GetIGVVentas(BEHotel beHotel)
        {
            string IVG = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_IGV_ventas"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, beHotel.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, beHotel.codPeriodo);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("totalIGV");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            IVG = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                        }
                    }
                    return IVG;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error obteniendo la sumatoria de IGV", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                return "0";
            }
        }
        public string GetIGVCompras(BEHotel beHotel)
        {
            string IVG = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_IGV_compras"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, beHotel.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, beHotel.codPeriodo);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("totalIGV");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            IVG = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                        }
                    }
                    return IVG;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error obteniendo la sumatoria de IGV", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                return "0";
            }
        }

        /*Delete Group*/
        public string DelHotelsGroup(BEHotel registro)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGISHOS_DEL_GROUP"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, registro.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, registro.codPeriodo);
                    dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, registro.correlativo);

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
        public string ValUsuarioVentas(BEHotel beHotel)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_EXISTE_CORRELATIVO"))
                {
                    dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, beHotel.correlativo);

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

        public string UpdListHotels(List<BEHotel> lstHotel)
        {
            string respuesta = string.Empty;
            try
            {
                BEHotel User = new BEHotel();
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (BEHotel users in lstHotel)
                    {
                        using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGISTROHOS_UPD"))
                        {
                            dbSQL.AddInParameter(dbCmd, "@idHospedaje", DbType.String, users.idHospedaje);
                            dbSQL.AddInParameter(dbCmd, "@fechaDocumento", DbType.String, users.fechaDocumento);
                            dbSQL.AddInParameter(dbCmd, "@serie", DbType.String, users.serie);
                            dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, users.correlativo);
                            dbSQL.AddInParameter(dbCmd, "@ruc", DbType.String, users.ruc);
                            dbSQL.AddInParameter(dbCmd, "@agencia", DbType.String, users.agencia);
                            dbSQL.AddInParameter(dbCmd, "@pasaporte", DbType.String, users.pasaporte);
                            dbSQL.AddInParameter(dbCmd, "@paisPasaporte", DbType.String, users.paisPasaporte);
                            dbSQL.AddInParameter(dbCmd, "@apellidoMaterno", DbType.String, users.apellidoMaterno);
                            dbSQL.AddInParameter(dbCmd, "@apellidoPaterno", DbType.String, users.apellidoPaterno);
                            dbSQL.AddInParameter(dbCmd, "@nombre", DbType.String, users.nombre);
                            dbSQL.AddInParameter(dbCmd, "@segundoNombre", DbType.String, users.segundoNombre);
                            dbSQL.AddInParameter(dbCmd, "@fechaIngresoHotel", DbType.String, users.fechaIngresoHotel);
                            dbSQL.AddInParameter(dbCmd, "@fechaSalidaHotel", DbType.String, users.fechaSalidaHotel);
                            dbSQL.AddInParameter(dbCmd, "@nroFicha", DbType.String, users.nroFicha);
                            dbSQL.AddInParameter(dbCmd, "@unidad", DbType.String, users.unidad);
                            dbSQL.AddInParameter(dbCmd, "@ingresoPais", DbType.String, users.ingresoPais);
                            //dbSQL.AddInParameter(dbCmd, "@x", DbType.String, users.x);
                            //dbSQL.AddInParameter(dbCmd, "@y", DbType.String, users.y);
                            dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, users.codLocal);
                            dbSQL.AddInParameter(dbCmd, "@paisProcedencia", DbType.String, users.paisProcedencia);
                            dbSQL.AddInParameter(dbCmd, "@flagValidacion", DbType.String, users.flagValidacion);
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
                return "0|" + ex.Message.Replace("0|", ""); //return "0|" + ex.Message;
            }
            finally
            {

            }
        }

        /**/
        public string INSListHotelsDuplicate(List<BEHotel> lstHotel)
        {
            string respuesta = string.Empty;
            try
            {
                BEHotel User = new BEHotel();
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (BEHotel users in lstHotel)
                    {
                        using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGISTROHOS_INS"))
                        {
                            dbSQL.AddInParameter(dbCmd, "@fechaDocumento", DbType.String, users.fechaDocumento);
                            dbSQL.AddInParameter(dbCmd, "@serie", DbType.String, users.serie);
                            dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, users.correlativo);
                            dbSQL.AddInParameter(dbCmd, "@agencia", DbType.String, users.agencia);
                            dbSQL.AddInParameter(dbCmd, "@ruc", DbType.String, users.ruc);
                            dbSQL.AddInParameter(dbCmd, "@pasaporte", DbType.String, users.pasaporte);
                            dbSQL.AddInParameter(dbCmd, "@paisPasaporte", DbType.String, users.paisPasaporte);
                            dbSQL.AddInParameter(dbCmd, "@apellidoMaterno", DbType.String, users.apellidoMaterno);
                            dbSQL.AddInParameter(dbCmd, "@apellidoPaterno", DbType.String, users.apellidoPaterno);
                            dbSQL.AddInParameter(dbCmd, "@nombre", DbType.String, users.nombre);
                            dbSQL.AddInParameter(dbCmd, "@segundoNombre", DbType.String, users.segundoNombre);
                            dbSQL.AddInParameter(dbCmd, "@fechaIngresoHotel", DbType.String, users.fechaIngresoHotel);
                            dbSQL.AddInParameter(dbCmd, "@fechaSalidaHotel", DbType.String, users.fechaSalidaHotel);
                            dbSQL.AddInParameter(dbCmd, "@nroFicha", DbType.String, users.nroFicha);
                            dbSQL.AddInParameter(dbCmd, "@unidad", DbType.String, users.unidad);
                            dbSQL.AddInParameter(dbCmd, "@ingresoPais", DbType.String, users.ingresoPais);
                            dbSQL.AddInParameter(dbCmd, "@x", DbType.String, users.x);
                            dbSQL.AddInParameter(dbCmd, "@y", DbType.String, users.y);
                            dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, users.codLocal);
                            dbSQL.AddInParameter(dbCmd, "@paisProcedencia", DbType.String, users.paisProcedencia);
                            dbSQL.AddInParameter(dbCmd, "@flagValidacion", DbType.String, users.flagValidacion);
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
        public string INSListHotels(List<BEHotel> lstHotel, BEUser UserLocal, string idarchivo)
        {
            string respuesta = string.Empty;
            Boolean conError = false;
            try
            {
                BEHotel User = new BEHotel();
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (BEHotel users in lstHotel)
                    {
                        using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGISTROHOS_INS"))
                        {
                            dbSQL.AddInParameter(dbCmd, "@fechaDocumento", DbType.String, users.fechaDocumento);
                            dbSQL.AddInParameter(dbCmd, "@serie", DbType.String, users.serie);
                            dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, users.correlativo);
                            dbSQL.AddInParameter(dbCmd, "@agencia", DbType.String, users.agencia);
                            dbSQL.AddInParameter(dbCmd, "@ruc", DbType.String, users.ruc);
                            dbSQL.AddInParameter(dbCmd, "@pasaporte", DbType.String, users.pasaporte);
                            dbSQL.AddInParameter(dbCmd, "@paisPasaporte", DbType.String, users.paisPasaporte);
                            dbSQL.AddInParameter(dbCmd, "@apellidoMaterno", DbType.String, users.apellidoMaterno);
                            dbSQL.AddInParameter(dbCmd, "@apellidoPaterno", DbType.String, users.apellidoPaterno);
                            dbSQL.AddInParameter(dbCmd, "@nombre", DbType.String, users.nombre);
                            dbSQL.AddInParameter(dbCmd, "@segundoNombre", DbType.String, users.segundoNombre);
                            dbSQL.AddInParameter(dbCmd, "@fechaIngresoHotel", DbType.String, users.fechaIngresoHotel);
                            dbSQL.AddInParameter(dbCmd, "@fechaSalidaHotel", DbType.String, users.fechaSalidaHotel);
                            dbSQL.AddInParameter(dbCmd, "@nroFicha", DbType.String, users.nroFicha);
                            dbSQL.AddInParameter(dbCmd, "@unidad", DbType.String, users.unidad);
                            dbSQL.AddInParameter(dbCmd, "@ingresoPais", DbType.String, users.ingresoPais);
                            dbSQL.AddInParameter(dbCmd, "@x", DbType.String, users.x);
                            dbSQL.AddInParameter(dbCmd, "@y", DbType.String, users.y);
                            dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, users.codLocal);
                            dbSQL.AddInParameter(dbCmd, "@paisProcedencia", DbType.String, users.paisProcedencia);
                            dbSQL.AddInParameter(dbCmd, "@flagValidacion", DbType.String, users.flagValidacion);
                            dbSQL.AddInParameter(dbCmd, "@idarchivo", DbType.String, idarchivo);
                            using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                            {
                                int index1 = dataReader.GetOrdinal("respuesta");
                                object[] values = new object[dataReader.FieldCount];
                                while (dataReader.Read())
                                {
                                    dataReader.GetValues(values);
                                    respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                                    conError = respuesta.Substring(0, 1).Equals("0");
                                }
                            }
                        }
                    }
                    scope.Complete();
                }
                if (conError)
                    throw new Exception("ERROR AL INSERTAR VER LOG DE IMPORTACIONES");

                return respuesta;
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                //if (string.IsNullOrEmpty(respuesta))
                return "0|" + ex.Message.Replace("0|", ""); //return ex.Message;
                //else
                //    return respuesta;
            }
            finally
            {

            }
        }

        /*alan*/
        public List<BELocal> GetLocales()
        {
            string respuesta = string.Empty;
            List<BELocal> lstLocales = new List<BELocal>();
            BELocal beLocal = new BELocal();
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_LISTA_EMPRESAS"))
                {
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("codLocal");
                        int index2 = dataReader.GetOrdinal("nomLocal");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            beLocal = new BELocal();
                            dataReader.GetValues(values);
                            beLocal.codLocal = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            beLocal.nomLocal = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            lstLocales.Add(beLocal);
                        }
                    }
                    return lstLocales;
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

        public string GetUnidad(BEHotel beHotel)
        {
            string SumaImponible = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_UNIDAD"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, beHotel.codLocal);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("descripcion");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            SumaImponible = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                        }
                    }
                    return SumaImponible;
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

        public string ValidarArchivosCargados(string nombreArchivo)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_VALIDATE_ARCHIVO_CARGADO"))
                {
                    dbSQL.AddInParameter(dbCmd, "@nombrearchivo", DbType.String, nombreArchivo);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int inxrespuesta = dataReader.GetOrdinal("respuesta");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);

                            respuesta = values[inxrespuesta] == DBNull.Value ? string.Empty : values[inxrespuesta].ToString();
                        }
                    }
                }

                return respuesta.Substring(0, 1);
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

        public string InsArchivoCaragado(string nombreArchivo, ref string idarchivo)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_ARCHIVO_INS"))
                {
                    dbSQL.AddInParameter(dbCmd, "@nombrearchivo", DbType.String, nombreArchivo);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int inxrespuesta = dataReader.GetOrdinal("respuesta");
                        int inxidarchivo = dataReader.GetOrdinal("idarchivo");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            respuesta = values[inxrespuesta] == DBNull.Value ? string.Empty : values[inxrespuesta].ToString();
                            idarchivo = values[inxidarchivo] == DBNull.Value ? string.Empty : values[inxidarchivo].ToString();
                        }
                    }
                }

                return respuesta.Substring(0, 1);
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                if (string.IsNullOrEmpty(respuesta))
                    return ex.Message;
                else
                    return respuesta;
            }
            finally
            {

            }
        }

        public List<BEPais> GetPaises()
        {
            string respuesta = string.Empty;
            List<BEPais> lstPais = new List<BEPais>();
            BEPais bePais = new BEPais();
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_PAIS"))
                {
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("codPais");
                        int index2 = dataReader.GetOrdinal("descPais");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            bePais = new BEPais();
                            dataReader.GetValues(values);
                            bePais.codPais = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            bePais.descPais = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            lstPais.Add(bePais);
                        }
                    }
                    return lstPais;
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

        public List<BEHotel> GetDocDistintos(BEHotel objBE)
        {
            string respuesta = string.Empty;
            List<BEHotel> lst = new List<BEHotel>();
            BEHotel BE = new BEHotel();
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_DOCUMENTOS_DIFERENTES"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, objBE.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, objBE.codPeriodo);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("Documento");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            BE = new BEHotel();
                            dataReader.GetValues(values);
                            BE.correlativo = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            lst.Add(BE);
                        }
                    }
                    return lst;
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

        public List<BEHotel> GetDocDistintosVentas(BEHotel objBE)
        {
            string respuesta = string.Empty;
            List<BEHotel> lst = new List<BEHotel>();
            BEHotel BE = new BEHotel();
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_DOCUMENTOS_DIFERENTES_ventas"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, objBE.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, objBE.codPeriodo);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("Documento");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            BE = new BEHotel();
                            dataReader.GetValues(values);
                            BE.correlativo = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            lst.Add(BE);
                        }
                    }
                    return lst;
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

        public string ValidarUsuarioLocal(string codlocal, BEUser user)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_VALIDATE_LOCAL_USER"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, codlocal);
                    dbSQL.AddInParameter(dbCmd, "@codUser", DbType.String, user.UserCod);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int inxrespuesta = dataReader.GetOrdinal("respuesta");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);

                            respuesta = values[inxrespuesta] == DBNull.Value ? string.Empty : values[inxrespuesta].ToString();
                        }
                    }
                }

                return respuesta.Substring(0, 1);
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
    }
}