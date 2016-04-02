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
    public class EstadoDA : DataAccesBase
    {
        Database dbSQL;
        public EstadoDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
        public List<BEEstado> GetEstado()
        {
            try
            {
                List<BEEstado> lstEstado = new List<BEEstado>();
                BEEstado beEstado = new BEEstado();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_ESTADO"))
                {

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("codEstado");
                        int index2 = dataReader.GetOrdinal("descripcion");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            beEstado = new BEEstado();
                            beEstado.codEstado = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            beEstado.Descripcion = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();

                            lstEstado.Add(beEstado);
                        }
                    }
                    return lstEstado;
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
        //
        //Modificaciones realizadas por renzo laureano 29/11/2012
        //
    }
}
