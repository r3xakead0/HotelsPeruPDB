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
    class ConceptosDA: DataAccesBase
    {
        Database dbSQL;
        public ConceptosDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }
        /*Select*/
        public List<BEConceptos> GetConceptos()
        {
            try
            {
                List<BEConceptos> lstConceptos = new List<BEConceptos>();
                BEConceptos beConceptos  = new BEConceptos();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_CONCEPTOS"))
                {

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("Tipo");
                        int index2 = dataReader.GetOrdinal("Valor_Padre");

                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            //dataReader.GetValues(values);
                            //beEstado = new BEEstado();
                            //beEstado.codEstado = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            //beEstado.Descripcion = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();

                            //lstEstado.Add(beEstado);
                        }
                    }
                    return lstConceptos;
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
