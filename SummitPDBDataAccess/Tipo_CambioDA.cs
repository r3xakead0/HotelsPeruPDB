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
    public class Tipo_CambioDA: DataAccesBase
    {
        Database dbSQL;
        public Tipo_CambioDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }

        public List<BETipo_Cambio> GET_Tipo_Cambio(Int64 CodPeriodo)
        {
            try
            {
                List<BETipo_Cambio> lstTipo_Cambio = new List<BETipo_Cambio>();
                BETipo_Cambio beTipo_Cambio = new BETipo_Cambio();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_TIPO_CAMBIO"))
                {
                    dbSQL.AddInParameter(dbCmd, "@Cod_Periodo", DbType.Int64, CodPeriodo);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("Cod_TC");
                        int index2 = dataReader.GetOrdinal("Fecha_TC");
                        int index3 = dataReader.GetOrdinal("PromPonderado_Compra_TC");
                        int index4 = dataReader.GetOrdinal("PromPonderado_Venta_TC");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            beTipo_Cambio = new BETipo_Cambio();
                            beTipo_Cambio.Fecha_TC = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            beTipo_Cambio.PromPonderado_Compra_TC = values[index3] == DBNull.Value ? string.Empty : values[index3].ToString();
                            beTipo_Cambio.PromPonderado_Venta_TC = values[index4] == DBNull.Value ? string.Empty : values[index4].ToString();

                            lstTipo_Cambio.Add(beTipo_Cambio);
                        }
                    }
                    return lstTipo_Cambio;
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
    }
}
