using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using SummitPDB.ExceptionManagment;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SummitPDB.DataAccess
{
    public class PeriodosDA : DataAccesBase
    {
        Database dbSQL;
        public PeriodosDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        public List<BEPeriodo_Mant> GetPeriodos(BEPeriodo_Mant objPeriodos)
        {
            try
            {
                List<BEPeriodo_Mant> lstPeriodosEmpresa = new List<BEPeriodo_Mant>();
                BEPeriodo_Mant bePeriodo = new BEPeriodo_Mant();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_PERIODO_GENERAL"))
                {
                    if (string.IsNullOrEmpty(objPeriodos.anioProces))
                        dbSQL.AddInParameter(dbCmd, "@anioProces", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@anioProces", DbType.String, objPeriodos.anioProces);

                    if (string.IsNullOrEmpty(objPeriodos.codEstado))
                        dbSQL.AddInParameter(dbCmd, "@codEstado", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@codEstado", DbType.String, objPeriodos.codEstado);


                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int CODPERIODO = dataReader.GetOrdinal("CODPERIODO");
                        int ANIOPROCES = dataReader.GetOrdinal("ANIOPROCES");
                        int DESCPERIODO = dataReader.GetOrdinal("DESCPERIODO");
                        int CODESTADO = dataReader.GetOrdinal("CODESTADO");
                        int MES = dataReader.GetOrdinal("MES");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            bePeriodo = new BEPeriodo_Mant();

                            bePeriodo.descPeriodo = values[DESCPERIODO] == DBNull.Value ? string.Empty : values[DESCPERIODO].ToString();
                            bePeriodo.anioProces = values[ANIOPROCES] == DBNull.Value ? string.Empty : values[ANIOPROCES].ToString();
                            bePeriodo.codPeriodo = values[CODPERIODO] == DBNull.Value ? string.Empty : values[CODPERIODO].ToString();
                            bePeriodo.codEstado = values[CODESTADO] == DBNull.Value ? string.Empty : values[CODESTADO].ToString();
                            bePeriodo.mes = values[MES] == DBNull.Value ? string.Empty : values[MES].ToString();
                            lstPeriodosEmpresa.Add(bePeriodo);
                        }
                    }
                    return lstPeriodosEmpresa;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }
        public List<BEPeriodoEmpresa> GetPeriodosEmpresa(BEUser users)
        {
            try
            {
                List<BEPeriodoEmpresa> lstPeriodosEmpresa = new List<BEPeriodoEmpresa>();
                BEPeriodoEmpresa bePeriodo = new BEPeriodoEmpresa();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_PERIODO"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codUser", DbType.String, users.UserCod);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("DESCPERIODO");
                        int index2 = dataReader.GetOrdinal("codPeriodoEmpresa");
                        int index3 = dataReader.GetOrdinal("CODLOCAL");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            bePeriodo = new BEPeriodoEmpresa();
                            bePeriodo.descPeriodo = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            bePeriodo.codPeriodoEmpresa = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            bePeriodo.codLocal = values[index3] == DBNull.Value ? string.Empty : values[index3].ToString();
                            lstPeriodosEmpresa.Add(bePeriodo);
                        }
                    }
                    return lstPeriodosEmpresa;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }
        public string validatePeriodo()
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_VALIDATE_PERIODO"))
                {
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index0 = dataReader.GetOrdinal("respuesta");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            respuesta = values[index0] == DBNull.Value ? string.Empty : values[index0].ToString();

                        }
                    }
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }
        public string UpdatePeriodoLocal(BEPeriodoEmpresa periodo)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_PERIODO_UPD"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, periodo.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@codPeriodo", DbType.String, periodo.codPeriodoEmpresa);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index0 = dataReader.GetOrdinal("respuesta");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            respuesta = values[index0] == DBNull.Value ? string.Empty : values[index0].ToString();

                        }
                    }
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }

        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //

        public String PERIODO_ACTUALIZAR_ESTADOS(Int64 Anio, Int64 mes, Int64 Est)
        {
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_PERIODO_ESTADO"))
                {
                    dbSQL.AddInParameter(dbCmd, "@anio", DbType.Int64, Anio);
                    dbSQL.AddInParameter(dbCmd, "@mes", DbType.Int64, mes);
                    dbSQL.AddInParameter(dbCmd, "@est", DbType.Int64, Est);
                    dbSQL.AddOutParameter(dbCmd, "@RESP_OUT", DbType.String, 300);
                    dbSQL.ExecuteReader(dbCmd);
                    return dbSQL.GetParameterValue(dbCmd, "@RESP_OUT").ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }
        public String PERIODOEMPRESA_ACTUALIZAR_ESTADOS(Int64 Anio, Int64 mes, Int64 local, Int64 Est)
        {
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_PERIODO_EMPRESA_ESTADO"))
                {
                    dbSQL.AddInParameter(dbCmd, "@anio", DbType.Int64, Anio);
                    dbSQL.AddInParameter(dbCmd, "@mes", DbType.Int64, mes);
                    dbSQL.AddInParameter(dbCmd, "@local", DbType.Int64, local);
                    dbSQL.AddInParameter(dbCmd, "@est", DbType.Int64, Est);
                    dbSQL.ExecuteReader(dbCmd);
                    return "Estados_Actualizados";
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }
        public String CREAR_PERIODOS(Int64 Anio)
        {
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_CREACION_PERIODOS"))
                {
                    dbSQL.AddInParameter(dbCmd, "@anio", DbType.Int64, Anio);
                    dbSQL.ExecuteReader(dbCmd);
                    return "Periodos Creados";
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }

        public List<BEPeriodoEmpresa_Mant> GET_PERIODOSEMPRESA_LOCALANIO(Int64 Anio, Int64 Local)
        {
            try
            {
                List<BEPeriodoEmpresa_Mant> lstPeriodosEmpresa = new List<BEPeriodoEmpresa_Mant>();
                BEPeriodoEmpresa_Mant bePeriodo = new BEPeriodoEmpresa_Mant();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_PERIODOSEMPRESA_ANIO"))
                {
                    dbSQL.AddInParameter(dbCmd, "@anio", DbType.Int64, Anio);
                    dbSQL.AddInParameter(dbCmd, "@Local", DbType.Int64, Local);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("codPeriodoEmpresa");
                        int index2 = dataReader.GetOrdinal("codLocal");
                        int index3 = dataReader.GetOrdinal("codEstado");
                        int index4 = dataReader.GetOrdinal("anioProces");
                        int index5 = dataReader.GetOrdinal("Descripcion");
                        int index6 = dataReader.GetOrdinal("mes");
                        int index7 = dataReader.GetOrdinal("Estado");
                        int index8 = dataReader.GetOrdinal("Local");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            bePeriodo = new BEPeriodoEmpresa_Mant();
                            bePeriodo.descPeriodo = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            bePeriodo.codLocal = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            bePeriodo.codEstado = values[index3] == DBNull.Value ? string.Empty : values[index3].ToString();

                            bePeriodo.anioProces = values[index4] == DBNull.Value ? string.Empty : values[index4].ToString();

                            bePeriodo.descPeriodo = values[index5] == DBNull.Value ? string.Empty : values[index5].ToString();

                            bePeriodo.mes = values[index6] == DBNull.Value ? string.Empty : values[index6].ToString();

                            bePeriodo.descripcion = values[index7] == DBNull.Value ? string.Empty : values[index7].ToString();
                            bePeriodo.Hotel = values[index8] == DBNull.Value ? string.Empty : values[index8].ToString();


                            lstPeriodosEmpresa.Add(bePeriodo);
                        }
                    }
                    return lstPeriodosEmpresa;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }
        public List<BEPeriodoEmpresa_Mant> GET_PERIODOSEMPRESA_MANT(Int64 Anio, Int64 Mes)
        {
            try
            {
                List<BEPeriodoEmpresa_Mant> lstPeriodosEmpresa = new List<BEPeriodoEmpresa_Mant>();
                BEPeriodoEmpresa_Mant bePeriodo = new BEPeriodoEmpresa_Mant();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_PERIODO_DETALLE"))
                {
                    dbSQL.AddInParameter(dbCmd, "@anio", DbType.Int64, Anio);
                    dbSQL.AddInParameter(dbCmd, "@mes", DbType.Int64, Mes);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("Hotel");
                        int index2 = dataReader.GetOrdinal("Estado");
                        int index3 = dataReader.GetOrdinal("codEstado");
                        int index4 = dataReader.GetOrdinal("codLocal");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            bePeriodo = new BEPeriodoEmpresa_Mant();
                            bePeriodo.Hotel = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            bePeriodo.descPeriodo = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            bePeriodo.codEstado = values[index3] == DBNull.Value ? string.Empty : values[index3].ToString();
                            bePeriodo.codLocal = values[index4] == DBNull.Value ? string.Empty : values[index4].ToString();


                            lstPeriodosEmpresa.Add(bePeriodo);
                        }
                    }
                    return lstPeriodosEmpresa;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }

        public List<BEPeriodo_Mant> GET_PERIODOS_MANT(Int64 Anio)
        {
            try
            {
                List<BEPeriodo_Mant> lstPeriodosEmpresa = new List<BEPeriodo_Mant>();
                BEPeriodo_Mant bePeriodo = new BEPeriodo_Mant();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_PERIODOS_ANIO"))
                {
                    dbSQL.AddInParameter(dbCmd, "@anio", DbType.Int64, Anio);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("codPeriodo");
                        int index2 = dataReader.GetOrdinal("anioProces");
                        int index3 = dataReader.GetOrdinal("descPeriodo");
                        int index4 = dataReader.GetOrdinal("codEstado");
                        int index5 = dataReader.GetOrdinal("mes");
                        int index6 = dataReader.GetOrdinal("descripcion");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            bePeriodo = new BEPeriodo_Mant();
                            bePeriodo.codPeriodo = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            bePeriodo.anioProces = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            bePeriodo.descPeriodo = values[index3] == DBNull.Value ? string.Empty : values[index3].ToString();
                            bePeriodo.codEstado = values[index4] == DBNull.Value ? string.Empty : values[index4].ToString();
                            bePeriodo.mes = values[index5] == DBNull.Value ? string.Empty : values[index5].ToString();
                            bePeriodo.descripcion = values[index6] == DBNull.Value ? string.Empty : values[index6].ToString();

                            lstPeriodosEmpresa.Add(bePeriodo);
                        }
                    }
                    return lstPeriodosEmpresa;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los periodos", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }

        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //

    }
}