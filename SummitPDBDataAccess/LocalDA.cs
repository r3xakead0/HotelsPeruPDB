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
    public class LocalDA : DataAccesBase
    {
        Database dbSQL;
        public LocalDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        public List<BELocal> GetLocal(BELocal local)
        {
            try
            {
                List<BELocal> lstLocal = new List<BELocal>();
                BELocal beLocal = new BELocal();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_LOCAL"))
                {
                    if (string.IsNullOrEmpty(local.codLocal))
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, DBNull.Value);
                    else
                        dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, local.codLocal);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index0 = dataReader.GetOrdinal("respuesta");
                        int index1 = dataReader.GetOrdinal("codLocal");
                        int index2 = dataReader.GetOrdinal("nomLocal");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            beLocal = new BELocal();
                            beLocal.codLocal = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            beLocal.nomLocal = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            lstLocal.Add(beLocal);
                        }
                    }
                    return lstLocal;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los locales", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
                return null;
            }
            finally
            {

            }
        }

    }
}