using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SummitPDB.BusinessEntities;
using System.Data.Common;
using System.Data;
using SummitPDB.ExceptionManagment;

namespace SummitPDB.DataAccess
{
    public class validateUsersDA : DataAccesBase
    {
        Database dbSQL;

        public validateUsersDA()
        {
            dbSQL = this.ConnectionStringSQL;
        }

        public BEUser validateLoginUser(BEUser users)
        {
            string respuesta = string.Empty;
            try
            {
                BEUser User = new BEUser();                
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_USERS_LOGIN"))
                {
                    dbSQL.AddInParameter(dbCmd, "@userName", DbType.String, users.UserName);
                    dbSQL.AddInParameter(dbCmd, "@userPassword", DbType.String, users.UserPassword);

                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("respuesta");
                        int index2 = dataReader.GetOrdinal("codUser");
                        int codLocal = dataReader.GetOrdinal("codLocal");
                        int fullname = dataReader.GetOrdinal("fullname");
                        int inxUsername = dataReader.GetOrdinal("username");
                        int codrol = dataReader.GetOrdinal("CODROL");
                        object[] values = new object[dataReader.FieldCount];

                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            User.Respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            User.Respuesta = User.Respuesta.Substring(0, 1);
                            User.UserCod = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            User.codLocal = values[codLocal] == DBNull.Value ? string.Empty : values[codLocal].ToString();
                            User.UserName = values[fullname] == DBNull.Value ? string.Empty : values[fullname].ToString();
                            User.UserNameAccount = values[inxUsername] == DBNull.Value ? string.Empty : values[inxUsername].ToString();
                            User.codRol = values[codrol] == DBNull.Value ? string.Empty : values[codrol].ToString();
                        }
                    }
                    return User;
                }
            }
            catch(Exception ex)
            {
                 ExceptionManager.SaveError("Ocurrio un error en el logo", string.Empty, string.Empty, ex, "validateLoginUser",true,false);
                 return null;
            }
            finally 
            {

            }

        }

        public List<BEManagementUser> GetUsers(string cfullName)
        {
            string respuesta = string.Empty;
            try
            {
                List<BEManagementUser> Users = new List<BEManagementUser>();
                BEManagementUser User = new BEManagementUser();
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_USUARIOS_GET"))
                {
                    dbSQL.AddInParameter(dbCmd, "@fullName", DbType.String, cfullName);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int index1 = dataReader.GetOrdinal("respuesta");
                        int index2 = dataReader.GetOrdinal("codUser");
                        int firstName = dataReader.GetOrdinal("firstName");
                        int lastName = dataReader.GetOrdinal("lastName");
                        int lastName2 = dataReader.GetOrdinal("lastName2");
                        int fullName = dataReader.GetOrdinal("fullName");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            User.Respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            User.Respuesta = User.Respuesta.Substring(0, 1);
                            User.UserCod = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            User.firstName = values[firstName] == DBNull.Value ? string.Empty : values[firstName].ToString();
                            User.lastName = values[lastName] == DBNull.Value ? string.Empty : values[lastName].ToString();
                            User.lastName2 = values[lastName2] == DBNull.Value ? string.Empty : values[lastName2].ToString();
                            User.fullName = values[fullName] == DBNull.Value ? string.Empty : values[fullName].ToString();
                            Users.Add(User);
                        }
                    }
                    return Users;
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
    }
}
