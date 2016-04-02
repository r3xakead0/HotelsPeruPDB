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
    public class ReglasDA : DataAccesBase
    {
        Database dbSQL;
        public ReglasDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        public List<BEReglas> GetCaracteres()
        {
            try
            {
                List<BEReglas> lstReglas = new List<BEReglas>();
                BEReglas beReglas = new BEReglas();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_CARACTERES"))
                {
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int respuesta = dataReader.GetOrdinal("respuesta");
                        int CODCARACTER = dataReader.GetOrdinal("CODCARACTER");
                        int DESCCARACTER = dataReader.GetOrdinal("DESCCARACTER");
                        int TYPECARACTER = dataReader.GetOrdinal("TYPECARACTER");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            beReglas = new BEReglas();
                            beReglas.codCaracter = values[CODCARACTER] == DBNull.Value ? string.Empty : values[CODCARACTER].ToString();
                            beReglas.caracter = values[DESCCARACTER] == DBNull.Value ? string.Empty : values[DESCCARACTER].ToString();
                            beReglas.tipo = values[TYPECARACTER] == DBNull.Value ? string.Empty : values[TYPECARACTER].ToString();

                            lstReglas.Add(beReglas);
                        }
                    }
                    return lstReglas;
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
        public List<BEReglas> GetNoEspeciales()
        {
            try
            {
                List<BEReglas> lstReglas = new List<BEReglas>();
                BEReglas beReglas = new BEReglas();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_NO_ESPECIALES"))
                {
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int respuesta = dataReader.GetOrdinal("respuesta");
                        int CODCARACTER = dataReader.GetOrdinal("CODCARACTER");
                        int DESCCARACTER = dataReader.GetOrdinal("DESCCARACTER");
                        int TYPECARACTER = dataReader.GetOrdinal("TYPECARACTER");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            beReglas = new BEReglas();
                            beReglas.codCaracter = values[CODCARACTER] == DBNull.Value ? string.Empty : values[CODCARACTER].ToString();
                            beReglas.caracter = values[DESCCARACTER] == DBNull.Value ? string.Empty : values[DESCCARACTER].ToString();
                            beReglas.tipo = values[TYPECARACTER] == DBNull.Value ? string.Empty : values[TYPECARACTER].ToString();

                            lstReglas.Add(beReglas);
                        }
                    }
                    return lstReglas;
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
        public List<BEReglas> GetEspeciales()
        {
            try
            {
                List<BEReglas> lstReglas = new List<BEReglas>();
                BEReglas beReglas = new BEReglas();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_CARACTERES_ESPECIALES"))
                {
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int respuesta = dataReader.GetOrdinal("respuesta");
                        int CODCARACTER = dataReader.GetOrdinal("CODCARACTER");
                        int DESCCARACTER = dataReader.GetOrdinal("DESCCARACTER");
                        int TYPECARACTER = dataReader.GetOrdinal("TYPECARACTER");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            beReglas = new BEReglas();
                            beReglas.codCaracter = values[CODCARACTER] == DBNull.Value ? string.Empty : values[CODCARACTER].ToString();
                            beReglas.caracter = values[DESCCARACTER] == DBNull.Value ? string.Empty : values[DESCCARACTER].ToString();
                            beReglas.tipo = values[TYPECARACTER] == DBNull.Value ? string.Empty : values[TYPECARACTER].ToString();

                            lstReglas.Add(beReglas);
                        }
                    }
                    return lstReglas;
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
        public string CaracteresINS(BEReglas caracter)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_CARACTER_INS"))
                {
                    dbSQL.AddInParameter(dbCmd, "@descCaracter", DbType.String, caracter.caracter);
                    dbSQL.AddInParameter(dbCmd, "@typeCaracter", DbType.String, caracter.tipo);
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
                return respuesta.Substring(0, 1); ;
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
        public string CaracteresDEL(BEReglas caracter)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_CARACTER_DEL"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codCaracter", DbType.String, caracter.codCaracter);
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
                return respuesta.Substring(0, 1); ;
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
        public string ReglasIns(BEReglas reglas)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGLAS_INS"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codCaracter", DbType.String, reglas.codCaracter);
                    dbSQL.AddInParameter(dbCmd, "@equivalence", DbType.String, reglas.equivalence);
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
                return respuesta.Substring(0, 1); ;
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
        public string ReglasDel(BEReglas regla)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGLAS_DEL"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codRegla", DbType.String, regla.codRegla);
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
                return respuesta.Substring(0, 1); ;
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
        public List<BEReglas> GetCaracteresEspeciales()
        {
            try
            {
                List<BEReglas> lstReglas = new List<BEReglas>();
                BEReglas beReglas = new BEReglas();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_REGLAS"))
                {
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int respuesta = dataReader.GetOrdinal("respuesta");
                        int CODRULE = dataReader.GetOrdinal("CODRULE");
                        int CODCARACTER = dataReader.GetOrdinal("CODCARACTER");
                        int DESCCARACTER = dataReader.GetOrdinal("DESCCARACTER");
                        int EQUIVALENCE = dataReader.GetOrdinal("EQUIVALENCE");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            beReglas = new BEReglas();
                            beReglas.codRegla = values[CODRULE] == DBNull.Value ? string.Empty : values[CODRULE].ToString();
                            beReglas.codCaracter = values[CODCARACTER] == DBNull.Value ? string.Empty : values[CODCARACTER].ToString();
                            beReglas.caracter = values[DESCCARACTER] == DBNull.Value ? string.Empty : values[DESCCARACTER].ToString();
                            beReglas.equivalence = values[EQUIVALENCE] == DBNull.Value ? string.Empty : values[EQUIVALENCE].ToString();

                            lstReglas.Add(beReglas);
                        }
                    }
                    return lstReglas;
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
        /*Transaction*/
        public string ReglasLisIns(List<BEReglas> lstreglas)
        {
            string respuesta = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (BEReglas reglas in lstreglas)
                    {
                        using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_REGLAS_INS"))
                        {
                            dbSQL.AddInParameter(dbCmd, "@codCaracter", DbType.String, reglas.codCaracter);
                            dbSQL.AddInParameter(dbCmd, "@equivalence", DbType.String, reglas.equivalence);
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
                    }
                    scope.Complete();

                }
                return respuesta.Substring(0, 1); ;
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
        public BEHotel VlidarHospedajeAnterior(string idHospedaje, string fechaDocumento,string correlativo)
        {
            string respuesta = string.Empty;
            BEHotel beFechaDoc = new BEHotel();
            beFechaDoc.respuesta = "0";
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_VAL_HOSEDAJE_ANTERIOR"))
                {
                    dbSQL.AddInParameter(dbCmd, "@idHospedaje", DbType.String, idHospedaje);
                    dbSQL.AddInParameter(dbCmd, "@fechaDocumento", DbType.String, fechaDocumento);
                    dbSQL.AddInParameter(dbCmd, "@correlativo", DbType.String, correlativo);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int inxrespuesta = dataReader.GetOrdinal("respuesta");
                        int inxidHospedaje = dataReader.GetOrdinal("idHospedaje");
                        int inxidFechaDocumento = dataReader.GetOrdinal("fechaDoc");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            beFechaDoc = new BEHotel();
                            respuesta = values[inxrespuesta] == DBNull.Value ? string.Empty : values[inxrespuesta].ToString();
                            if (respuesta.Substring(0, 1) == "1")
                            {
                                beFechaDoc.idHospedaje = values[inxidHospedaje] == DBNull.Value ? string.Empty : values[inxidHospedaje].ToString();
                                beFechaDoc.fechaDocumento = values[inxidFechaDocumento] == DBNull.Value ? string.Empty : values[inxidFechaDocumento].ToString();
                                beFechaDoc.respuesta = respuesta.Substring(0, 1);
                            }
                            else
                                beFechaDoc.respuesta = respuesta.Substring(0, 1);
                        }
                    }
                }

                return beFechaDoc;
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
