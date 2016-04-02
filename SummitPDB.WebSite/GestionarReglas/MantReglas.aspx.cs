using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
//using EditableGridView.egClass;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using SummitPDB.ServicesInterface;
using SummitPDB.BusinessEntities;
using System.Web.Services;
using System.Web.UI;

namespace SummitPDB.WebSite.GestionarReglas
{
    public partial class MantReglas : System.Web.UI.Page
    {
        protected void loadGrid()
        {
            IReglas IService = new IReglas();
            List<BEReglas> lstBE = new List<BEReglas>();
            lstBE = IService.IGetCaracteresEspecialesBL();
            gvCaracter.DataSource = lstBE;
            gvCaracter.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx"); 
            if (gvCaracter.Rows.Count <= 1)
                ClientScript.RegisterStartupScript(typeof(Page), "frTest", "frShowHideButtonNew(1);", true);
            if (!IsPostBack)
            {
                IReglas IServiceDdl = new IReglas();
                ddlMantCaracter.DataSource = IServiceDdl.IGetEspeciales();
                ddlMantCaracter.DataTextField = "caracter";
                ddlMantCaracter.DataValueField = "codCaracter";
                ddlMantCaracter.DataBind();
                loadGrid();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            loadGrid();
        }
        protected void gvCaracter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOut", "this.className = this.orignalclassName;");
                e.Row.Attributes.Add("OnMouseOver", "this.orignalclassName = this.className;this.className = 'SelectedRow';");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                IReglas IServiceDdl = new IReglas();
                DropDownList ddlDepartment = (DropDownList)e.Row.FindControl("ddlCaracter");
                if (ddlDepartment != null)
                {
                    ddlDepartment.DataSource = IServiceDdl.IGetEspeciales();
                    ddlDepartment.DataTextField = "caracter";
                    ddlDepartment.DataValueField = "codCaracter";
                    ddlDepartment.DataBind();
                    ddlDepartment.SelectedValue = gvCaracter.DataKeys[e.Row.RowIndex].Values[1].ToString();
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                IReglas IServiceDdl = new IReglas();
                DropDownList ddlDepartment = (DropDownList)e.Row.FindControl("ddlCaracter");
                ddlDepartment.DataSource = IServiceDdl.IGetEspeciales();
                ddlDepartment.DataTextField = "caracter";
                ddlDepartment.DataValueField = "codCaracter";
                ddlDepartment.DataBind();
            }
        }
        protected void gvCaracter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                IReglas IService = new IReglas();
                BEReglas BE = new BEReglas();
                BE = new BEReglas();
                BE.equivalence = ((TextBox)gvCaracter.FooterRow.FindControl("txtEquivalente")).Text;
                BE.codCaracter = ((DropDownList)gvCaracter.FooterRow.FindControl("ddlCaracter")).SelectedValue;
                IService.IReglasIns(BE);
                loadGrid();
            }
        }
        protected void gvCaracter_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            IReglas IService = new IReglas();
            BEReglas BE = new BEReglas();
            BE = new BEReglas();
            BE.codRegla = gvCaracter.Rows[e.RowIndex].Cells[0].Text.Trim();
            IService.IReglasDel(BE);
            loadGrid();
            if (gvCaracter.Rows.Count < 1)
                Response.Redirect("~/GestionarReglas/MantReglas.aspx");
        }

        //Insert Update
        [WebMethod]
        public static string InsertRegla(BEReglas obj)
        {
            IReglas IService = new IReglas();
            return IService.IReglasIns(obj);
        }
    }
}