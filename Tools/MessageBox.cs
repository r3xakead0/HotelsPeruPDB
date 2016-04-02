using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
//using System.Web.UI;

namespace SummitPDB.Tools
{
    public class MessageBox
    {
        public static string ShowConfirmDialog()
        {
            return "return confirm('¿Está seguro que desea continuar?');";
        }
        /*
        public static string ShowConfirmDialogActualizarFechas()
        {
            return "return confirm('¿Está usted seguro que desea actualizar las fechas?');";
        }
        public static string ShowConfirmDialogSeleccionarRecibos()
        {
            return "return confirm('¿Está usted seguro que desea seleccionar los recibos?');";
        }
        public static void Show(Page pagina, string strMensaje, string strPagina)
        {

            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("<script language=\"javascript\">");
            sbScript.Append("function ShowMessage()	");
            sbScript.Append("{");
            sbScript.Append("window.alert('" + strMensaje + "');window.location.href='" + strPagina + "'");
            sbScript.Append("}");
            sbScript.Append("ShowMessage();");
            sbScript.Append("</script>");


            if (!pagina.ClientScript.IsStartupScriptRegistered("MSG_BOX"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MSG_BOX", sbScript.ToString());
            }
        }
        public static void Show(Page pagina, UpdatePanel upanel, string strMensaje, string strPagina)
        {

            //StringBuilder sbScript = new StringBuilder();

            //sbScript.Append("<script language=\"javascript\">");
            //sbScript.Append("function ShowMessage()	");
            //sbScript.Append("{");
            //sbScript.Append("window.alert('" + strMensaje + "');window.location.href='" + strPagina + "'");
            //sbScript.Append("}");
            //sbScript.Append("ShowMessage();");
            //sbScript.Append("</script>");

            ScriptManager.RegisterClientScriptBlock(upanel, pagina.GetType(), "MSG_BOX_Regreso", "window.alert('" + strMensaje + "');window.location.href='" + strPagina + "'", true);

            // ScriptManager.RegisterClientScriptBlock(upanel, pagina.GetType(), "MSG_BOX_Regreso", sbScript.ToString(),true);

        }
        public static void Show(Page pagina, string strMensaje)
        {
            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("<script language=\"javascript\">");
            sbScript.Append("function ShowMessage()	");
            sbScript.Append("{");
            sbScript.Append("window.alert('" + strMensaje + "')");
            sbScript.Append("}");
            sbScript.Append("ShowMessage();");
            sbScript.Append("</script>");

            if (!pagina.ClientScript.IsStartupScriptRegistered("MSG_BOX"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MSG_BOX", sbScript.ToString());
            }
        }
        public static void Show(Page pagina, string strMensaje, bool cerrarPopup)
        {
            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("<script language=\"javascript\">");
            sbScript.Append("function ShowMessage()	");
            sbScript.Append("{");
            sbScript.Append("window.alert('" + strMensaje + "');");
            if (cerrarPopup)
                sbScript.Append("window.close();");
            sbScript.Append("}");
            sbScript.Append("ShowMessage();");
            sbScript.Append("</script>");

            if (!pagina.ClientScript.IsStartupScriptRegistered("MSG_BOX"))
            {
                pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MSG_BOX", sbScript.ToString());
            }

        }

        public static void Show(Page pagina, UpdatePanel upanel, string strMensaje)
        {
            ScriptManager.RegisterClientScriptBlock(upanel, pagina.GetType(), "msgbox", "window.alert('" + strMensaje + "');", true);
        }
        public static void ShowConfirm(Page pagina, UpdatePanel upanel, string strMensaje)
        {
            ScriptManager.RegisterClientScriptBlock(upanel, pagina.GetType(), "msgbox2", "return window.confirm('" + strMensaje + "');", true);

        }
        public static string ShowConfirmReturn(string mensaje)
        {
            return "return window.confirm('" + mensaje + "');";
        }
        */
    }
}
