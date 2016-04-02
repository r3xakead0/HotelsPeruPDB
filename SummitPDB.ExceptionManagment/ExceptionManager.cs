using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using SummitPDB.Tools;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SummitPDB.ExceptionManagment
{
    public class ExceptionManager : Exception
    {
        #region Atributos
        private static string _descripcion;
        private static string _error;
        private static string _stackTrace;
        private static string _servicioWeb;
        private static string _componente;
        private static string _usuario;
        private bool _grabarErrorBD;
        private static Exception errorEx = null;
        #endregion

        #region Propiedades

        public bool GrabarErrorBD
        {
            get
            {
                return _grabarErrorBD;
            }
            set
            {
                _grabarErrorBD = value;
            }
        }
        public static string Usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }
        public static string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        public static string stackTrace
        {
            get
            {
                return _stackTrace;
            }
            set
            {
                _stackTrace = value;
            }
        }
        public static string ServicioWeb
        {
            get
            {
                return _servicioWeb;
            }
            set
            {
                _servicioWeb = value;
            }
        }
        public static string Componente
        {
            get
            {
                return _componente;
            }
            set
            {
                _componente = value;
            }
        }
        public static string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
            }
        }
        #endregion


        public static void SaveError(string strDescripcion, string strUsuario, string strURLServicioWeb, Exception strError,
                            string strComponente, bool blGrabarErrorBD, bool blGrabarErrorSistema)
        {
            try
            {
                bool FlagActivo = Convert.ToBoolean(ConfigurationManager.AppSettings["ExceptionManagerActivo"].ToString());
                if (FlagActivo)
                {

                    inicializarVariables(strDescripcion, strUsuario, strURLServicioWeb, strComponente, strError);
                    if (blGrabarErrorBD)
                        saveErrorBD();

                    if (blGrabarErrorSistema)
                        saveErrorSystem(strComponente);
                }
            }
            catch (Exception ex)
            {
                errorEx = ex;
                saveErrorSystem("ExceptionManager");

            }
        }


        private static void inicializarVariables(string strDescripcion, string strUsuario, string strURLServicioWeb, string strComponente, Exception strError)
        {
            Descripcion = strDescripcion;
            ServicioWeb = strURLServicioWeb;
            Componente = strComponente;
            Usuario = strUsuario;
            errorEx = strError;

            if (strError != null)
            {
                Error = strError.Message;
                stackTrace = strError.StackTrace;
            }
            else
            {
                Error = null;
                stackTrace = null;
            }

        }

        private static void saveErrorSystem(string nombreOrigen)
        {
            try
            {
                EventLog ev;

                string sOrigen;
                string sLog;
                sOrigen = "SummitPDBSolution";
                sLog = "PDBSolution";

                byte[] errorInfo = Encoding.ASCII.GetBytes(nombreOrigen);

                if (!(EventLog.SourceExists(sOrigen)))
                {
                    EventLog.CreateEventSource(sOrigen, sLog);
                }

                ev = new EventLog(sLog, System.Environment.MachineName, sOrigen);

                ev.WriteEntry(establecerMensajeError(), System.Diagnostics.EventLogEntryType.Error, 1, 1, errorInfo);

                ev.Close();


            }
            catch
            {

            }

        }
        private static string establecerMensajeError()
        {
            string sMensaje = string.Empty;
            string sStack = string.Empty;
            sMensaje += "[Datos Generales]" + "\n\n";
            sMensaje += "Titulo=" + Descripcion + "\n";
            sMensaje += "Detalles=" + "\n\t";
            sMensaje += "Mensaje:" + "\t\t" + Error + "\n\t";
            sMensaje += "PC:" + "\t\t" + string.Empty + "\n\t";
            sMensaje += "Usuario:" + "\t\t" + Usuario + "\n\t";
            sMensaje += "Proc. Almacenado:" + "\t" + string.Empty + "\n\t";
            sMensaje += "Fecha y Hora:" + "\t" + DateTime.Now.ToShortDateString() + "\n";

            if (errorEx != null)
                if (errorEx.StackTrace != null)
                    sStack = errorEx.StackTrace;
                else
                    sStack = string.Empty;
            else
                sStack = string.Empty;

            sMensaje += "[Datos Adicionales]" + "\n\n\t";
            sMensaje += "Linea de ejecución:" + "\t" + sStack;

            return sMensaje;

        }
        private static void saveErrorBD()
        {
            Database dbSQL = DatabaseFactory.CreateDatabase(TipoConnection.ConeccionSQL.ToString());


            using (DbCommand dbCmd = dbSQL.GetStoredProcCommand("ERRORES_INSERT"))
            {
                dbSQL.AddInParameter(dbCmd, "@Descripcion", DbType.String, Descripcion);
                dbSQL.AddInParameter(dbCmd, "@Error", DbType.String, Error);
                dbSQL.AddInParameter(dbCmd, "@StackTrace", DbType.String, stackTrace);
                dbSQL.AddInParameter(dbCmd, "@ServicioWeb", DbType.String, ServicioWeb);
                dbSQL.AddInParameter(dbCmd, "@Componente", DbType.String, Componente);
                dbSQL.AddInParameter(dbCmd, "@Usuario", DbType.String, Usuario);
                dbSQL.ExecuteNonQuery(dbCmd);
            }


        }



    }
}
