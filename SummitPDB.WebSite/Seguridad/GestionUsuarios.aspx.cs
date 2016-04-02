using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitPDB.BusinessEntities;
using SummitPDB.ServicesInterface;
using System.Web.Services;

namespace SummitPDB.WebSite.Seguridad
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        #region void

        protected void loadGridUsers(string cName)
        {
            IUsers IService = new IUsers();
            gvUsers.DataSource = IService.IGetUsers(cName);
            gvUsers.DataBind();
        }
        protected void loadDropLocal(string cCodLocal)
        {
            ILocal IService = new ILocal();
            BELocal BE = new BELocal();
            BE.codLocal = cCodLocal;
            ddlLocales.DataSource = IService.IGetLocal(BE);
            ddlLocales.DataValueField = "codLocal";
            ddlLocales.DataTextField = "nomLocal";
            ddlLocales.DataBind();
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx"); 
            if (!IsPostBack)
            {
                loadDropLocal("");
                loadGridUsers(txtUsuarioBuscado.Text.Trim());
            }
        }

        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            loadGridUsers(txtUsuarioBuscado.Text.Trim());
        }

        protected void gvUsers_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOut", "this.className = this.orignalclassName;");
                e.Row.Attributes.Add("OnMouseOver", "this.orignalclassName = this.className;this.className = 'SelectedRow';");
                //e.Row.Cells[2].Attributes.Add("onclick", "frEditRow('" + e.Row.Cells[0].Text + "')");
                e.Row.Cells[2].Attributes.Add("onclick", "frEditRow();");
                e.Row.Cells[3].Attributes.Add("onclick", "DeleteData();");
            }
        }

        #region WebMethod
        //Insert Update
        [WebMethod]
        public static string InsUpd(BEManagementUser objBE)
        {
            IUsers IService = new IUsers();
            return objBE.codUser == "0" ? IService.IInsert(objBE) : IService.IUpdate(objBE);
        }

        //Delete
        [WebMethod]
        public static string Del(BEManagementUser objBE)
        {
            IUsers IService = new IUsers();
            return IService.IDelete(objBE);
        }

        #endregion
    }
}