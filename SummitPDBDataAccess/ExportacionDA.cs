using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummitPDB.BusinessEntities;
using System.Data.Common;
using System.Data;
using SummitPDB.ExceptionManagment;
using System.Transactions;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SummitPDB.DataAccess
{
    public class ExportacionDA : DataAccesBase
    {

        Database dbSQL;
        public ExportacionDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //

        public String GetHoteles_Exportacion(BEPeriodoEmpresa_Mant Perido)
        {
            string respuesta = string.Empty;
            try
            {

                List<BEExportacion> Exportaciones = new List<BEExportacion>();
                BEExportacion Exportar = new BEExportacion();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_Exportacion_Hospedaje"))
                {

                    dbSQL.AddInParameter(dbCmd, "@Per_empresa", DbType.String, Perido.codPeriodo);

                    if (string.IsNullOrEmpty(Perido.codLocal))
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, Perido.codLocal);

                    if (string.IsNullOrEmpty(Perido.anioProces))
                        dbSQL.AddInParameter(dbCmd, "@Anio", DbType.Int32, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@Anio", DbType.Int32, Perido.anioProces);

                    if (string.IsNullOrEmpty(Perido.anioProces))
                        dbSQL.AddInParameter(dbCmd, "@Mes", DbType.Int32, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@Mes", DbType.Int32, Perido.mes);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int Resul = dataReader.GetOrdinal("Sunat");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);

                            StreamWriter sw = new StreamWriter(Path.GetFullPath(@Perido.Ruta), true);
                            //StreamWriter sw = new StreamWriter(Path.GetFullPath(@"d:/20114803228.hos"), true);

                            sw.WriteLine(values[Resul] == DBNull.Value ? string.Empty : values[Resul].ToString());
                            sw.Close();
                        }


                    }
                    return "Exportacion Exitosa";
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser", true, false);
                //return null;
            }
            finally
            {

            }
        }

        public String GetTipo_Cambio_Exportacion(Int64 Perido)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEExportacion> Exportaciones = new List<BEExportacion>();
                BEExportacion Exportar = new BEExportacion();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_Exportacion_TC"))
                {
                    dbSQL.AddInParameter(dbCmd, "@Per_empresa", DbType.String, Perido);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int Resul = dataReader.GetOrdinal("Sunat");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            StreamWriter sw = new StreamWriter(Path.GetFullPath(@"C:\20114803228.tc"), true);
                            sw.WriteLine(values[Resul] == DBNull.Value ? string.Empty : values[Resul].ToString());
                            sw.Close();
                        }
                    }
                    return "Exportacion Exitosa";
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
        public String GetVentas_Exportacion(BEPeriodoEmpresa_Mant Perido)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEExportacion> Exportaciones = new List<BEExportacion>();
                BEExportacion Exportar = new BEExportacion();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_Exportacion_Ventas"))
                {
                    dbSQL.AddInParameter(dbCmd, "@Per_empresa", DbType.String, Perido.codPeriodo);

                    if (string.IsNullOrEmpty(Perido.codLocal))
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, Perido.codLocal);

                    if (string.IsNullOrEmpty(Perido.anioProces))
                        dbSQL.AddInParameter(dbCmd, "@Anio", DbType.Int32, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@Anio", DbType.Int32, Perido.anioProces);

                    if (string.IsNullOrEmpty(Perido.anioProces))
                        dbSQL.AddInParameter(dbCmd, "@Mes", DbType.Int32, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@Mes", DbType.Int32, Perido.mes);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int Resul = dataReader.GetOrdinal("Sunat");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            StreamWriter sw = new StreamWriter(Path.GetFullPath(@Perido.Ruta), true);
                            sw.WriteLine(values[Resul] == DBNull.Value ? string.Empty : values[Resul].ToString());
                            sw.Close();
                        }
                    }
                    return "Exportacion Exitosa";
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
        public String GetCompra_Exportacion(BEPeriodoEmpresa_Mant Perido)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEExportacion> Exportaciones = new List<BEExportacion>();
                BEExportacion Exportar = new BEExportacion();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_Exportacion_Compras"))
                {
                    dbSQL.AddInParameter(dbCmd, "@Per_empresa", DbType.String, Perido.codPeriodo);

                    if (string.IsNullOrEmpty(Perido.codLocal))
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, Perido.codLocal);

                    if (string.IsNullOrEmpty(Perido.anioProces))
                        dbSQL.AddInParameter(dbCmd, "@Anio", DbType.Int32, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@Anio", DbType.Int32, Perido.anioProces);

                    if (string.IsNullOrEmpty(Perido.anioProces))
                        dbSQL.AddInParameter(dbCmd, "@Mes", DbType.Int32, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@Mes", DbType.Int32, Perido.mes);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int Resul = dataReader.GetOrdinal("Sunat");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            StreamWriter sw = new StreamWriter(Path.GetFullPath(@Perido.Ruta), true);
                            sw.WriteLine(values[Resul] == DBNull.Value ? string.Empty : values[Resul].ToString());
                            sw.Close();
                        }
                    }
                    return "Exportacion Exitosa";
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
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
    }
}
