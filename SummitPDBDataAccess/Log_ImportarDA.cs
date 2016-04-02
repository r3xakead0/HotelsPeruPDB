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
    public class Log_ImportarDA : DataAccesBase
    {
        
        Database dbSQL;
        public Log_ImportarDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        public void Limpiar_Log()
        {
            try
            {
                List<BELog_Importar> lstLog_Importar = new List<BELog_Importar>();
                BELog_Importar beLog_Importar = new BELog_Importar();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_Limpiar_LOG"))
                {

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                       
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.SaveError("Ocurrio un error al obtener los locales", string.Empty, string.Empty, ex, "GetPeriodos", true, false);
              
            }
            finally
            {

            }
        }
        public List<BELog_Importar> GetImportar_DA()
        {
            try
            {
                List<BELog_Importar> lstLog_Importar = new List<BELog_Importar>();
                BELog_Importar beLog_Importar = new BELog_Importar();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_LOG_IMPORTAR"))
                {

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("descripcion");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            beLog_Importar = new BELog_Importar();
                            beLog_Importar.Resultado = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();

                            lstLog_Importar.Add(beLog_Importar);
                        }
                    }
                    return lstLog_Importar;
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
