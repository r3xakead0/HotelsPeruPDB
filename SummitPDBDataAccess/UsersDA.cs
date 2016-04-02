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
    public class UsersDA : DataAccesBase
    {
        Database dbSQL;
        public UsersDA()
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
                        object[] values = new object[dataReader.FieldCount];

                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            User.Respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            User.UserCod = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
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
        /*Select*/
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
                        int codLocal = dataReader.GetOrdinal("codLocal");
                        int nomLocal = dataReader.GetOrdinal("nomLocal");
                        int codRol = dataReader.GetOrdinal("codRol");
                        int userName = dataReader.GetOrdinal("userName");
                        int userPassword = dataReader.GetOrdinal("userPassword");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            User = new BEManagementUser();
                            User.Respuesta = values[index1] == DBNull.Value ? string.Empty : values[index1].ToString();
                            User.UserCod = values[index2] == DBNull.Value ? string.Empty : values[index2].ToString();
                            User.firstName = values[firstName] == DBNull.Value ? string.Empty : values[firstName].ToString();
                            User.lastName = values[lastName] == DBNull.Value ? string.Empty : values[lastName].ToString();
                            User.lastName2 = values[lastName2] == DBNull.Value ? string.Empty : values[lastName2].ToString();
                            User.fullName = values[fullName] == DBNull.Value ? string.Empty : values[fullName].ToString();
                            User.codLocal = values[codLocal] == DBNull.Value ? string.Empty : values[codLocal].ToString();
                            User.nomLocal = values[nomLocal] == DBNull.Value ? string.Empty : values[nomLocal].ToString();
                            User.codRol = values[codRol] == DBNull.Value ? string.Empty : values[codRol].ToString();
                            User.UserName = values[userName] == DBNull.Value ? string.Empty : values[userName].ToString();
                            User.UserPassword = values[userPassword] == DBNull.Value ? string.Empty : values[userPassword].ToString();
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
        /*Insert*/
        public string InsGestionUsuario(BEManagementUser objBE)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_USERS_INS"))
                {
                    dbSQL.AddInParameter(dbCmd, "@firstName", DbType.String, objBE.firstName);
                    dbSQL.AddInParameter(dbCmd, "@LastName", DbType.String, objBE.lastName);
                    dbSQL.AddInParameter(dbCmd, "@LastName2", DbType.String, objBE.lastName2);
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, objBE.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@userName", DbType.String, objBE.UserName);
                    dbSQL.AddInParameter(dbCmd, "@userPassword", DbType.String, objBE.UserPassword);
                    dbSQL.AddInParameter(dbCmd, "@codRol", DbType.String, objBE.codRol);
                    
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
        /*Update*/
        public string UpdGestionUsuario(BEManagementUser objBE)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_USERS_UPD"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codUser", DbType.String, objBE.codUser);
                    dbSQL.AddInParameter(dbCmd, "@firstName", DbType.String, objBE.firstName);
                    dbSQL.AddInParameter(dbCmd, "@LastName", DbType.String, objBE.lastName);
                    dbSQL.AddInParameter(dbCmd, "@LastName2", DbType.String, objBE.lastName2);
                    dbSQL.AddInParameter(dbCmd, "@codLocal", DbType.String, objBE.codLocal);
                    dbSQL.AddInParameter(dbCmd, "@userName", DbType.String, objBE.UserName);
                    dbSQL.AddInParameter(dbCmd, "@userPassword", DbType.String, objBE.UserPassword);
                    dbSQL.AddInParameter(dbCmd, "@codRol", DbType.String, objBE.codRol);

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
        public string DelGestionUsuario(BEManagementUser objBE)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_USERS_DEL"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codUser", DbType.String, objBE.codUser);

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
        /*Update*/
        public string UpdPassword(BEUser objBE)
        {
            string respuesta = string.Empty;
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_MANT_PASSWORD_UPD"))
                {
                    dbSQL.AddInParameter(dbCmd, "@userName", DbType.String, objBE.UserName);
                    dbSQL.AddInParameter(dbCmd, "@newPassword", DbType.String, objBE.UserPassword);
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

        /*Menus*/
        public List<BEMenu> GetMenuTop(BEMenu BE)
        {
            List<BEMenu> Menus = new List<BEMenu>();
            try
            {
                using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("SP_GET_MENU_TOP"))
                {
                    dbSQL.AddInParameter(dbCmd, "@codUser", DbType.String, BE.codUser);
                    using (IDataReader dataReader = dbSQL.ExecuteReader(dbCmd))
                    {
                        int SiteMapID = dataReader.GetOrdinal("SiteMapID");
                        int Title = dataReader.GetOrdinal("Title");
                        //int Description = dataReader.GetOrdinal("Description");
                        int Url = dataReader.GetOrdinal("Url");
                        int ParentID = dataReader.GetOrdinal("ParentID");
                        object[] values = new object[dataReader.FieldCount];
                        while (dataReader.Read())
                        {
                            dataReader.GetValues(values);
                            BE = new BEMenu();
                            BE.ID = values[SiteMapID] == DBNull.Value ? 0 : Convert.ToInt32(values[SiteMapID]);
                            BE.Text = values[Title] == DBNull.Value ? string.Empty : values[Title].ToString();
                            BE.Url = values[Url] == DBNull.Value ? string.Empty : values[Url].ToString();
                            BE.ParentID = values[ParentID] == DBNull.Value ? 0 : Convert.ToInt32(values[ParentID]);
                            Menus.Add(BE);
                        }
                    }
                    return Menus;
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
