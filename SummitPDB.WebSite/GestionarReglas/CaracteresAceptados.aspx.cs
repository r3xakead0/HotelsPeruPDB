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

namespace SummitPDB.WebSite.GestionarReglas
{
    public partial class CaracteresAceptados : System.Web.UI.Page
    {
        protected void loadGrid()
        {
            IReglas IService = new IReglas();
            List<BEReglas> lstBE = new List<BEReglas>();
            lstBE = IService.IGetCaracteres();
            gvCaracter.DataSource = lstBE;
            gvCaracter.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx"); 
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        protected void gvCaracter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOut", "this.className = this.orignalclassName;");
                e.Row.Attributes.Add("OnMouseOver", "this.orignalclassName = this.className;this.className = 'SelectedRow';");
            }
        }
        protected void gvCaracter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                IReglas IService = new IReglas();
                BEReglas BE = new BEReglas();
                BE = new BEReglas();
                BE.caracter = ((TextBox)gvCaracter.FooterRow.FindControl("txtCaracter")).Text;
                BE.tipo = ((DropDownList)gvCaracter.FooterRow.FindControl("ddlTipoCaracter")).SelectedValue;
                IService.ICaracteresIns(BE);
                loadGrid();
            }
        }
        protected void gvCaracter_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gvCaracter.Rows.Count == 1)
                return;
            IReglas IService = new IReglas();
            BEReglas BE = new BEReglas();
            BE = new BEReglas();
            BE.codCaracter = gvCaracter.Rows[e.RowIndex].Cells[0].Text.Trim(); //gvCaracter.DataKeys[e.RowIndex].Values[0].ToString();//row.Cells[0].Text.Trim();
            IService.ICaracteresDel(BE);
            loadGrid();
        }

        /*
        private void sAgregarDM()
        {
            BEReglas BE = new BEReglas();
            List<BEReglas> lstBE = new List<BEReglas>();
            if (!(Session["LstBE"] == null))
            {
                lstBE = (List<BEReglas>)Session["LstBE"];
            }
            //GridViewRow row;
            //row = gvCaracterAceptado.Rows[gvCaracterAceptado.SelectedIndex];
            BE.caracter = "A";
            BE.tipo = "1";
            lstBE.Add(BE);
            gvCaracter.DataSource = lstBE;
            gvCaracter.DataBind();
            Session["LstBE"] = lstBE;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            IReglas IService = new IReglas();
            BEReglas BE = new BEReglas();
            foreach (GridViewRow row in gvCaracter.Rows)
            {
                if (row.Cells[0].Text.Trim() == "0")
                {
                    BE = new BEReglas();
                    //BE.codCaracter = row.Cells[0].Text.Trim();
                    BE.caracter = ((Label)row.FindControl("lblCaracter")).Text;
                    BE.tipo = ((Label)row.FindControl("lblTipo")).Text;
                    IService.ICaracteresIns(BE);
                }
            }  
        }
        protected void lnkInsert_Click(object sender, GridViewRowEventArgs e)
        {
            try
            {
                BEReglas BE = new BEReglas();
                List<BEReglas> lstBE = new List<BEReglas>();
                if (!(Session["LstBE"] == null))
                {
                    lstBE = (List<BEReglas>)Session["LstBE"];
                }
                BE.caracter = ((TextBox)gvCaracter.FooterRow.FindControl("txtCaracter")).Text;
                BE.tipo = ((DropDownList)gvCaracter.FooterRow.FindControl("ddlTipoCaracter")).SelectedValue;
                lstBE.Add(BE);
                gvCaracter.DataSource = lstBE;
                gvCaracter.DataBind();
                Session["LstBE"] = lstBE;
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvCaracter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    GridViewRow r = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);

            //    foreach (DataControlField c in ((GridView)sender).Columns)
            //    {
            //        TableCell nc = new TableCell();
            //        nc.Text = c.AccessibleHeaderText;
            //        nc.BackColor = System.Drawing.Color.Cornsilk;
            //        r.Cells.Add(nc);
            //    }

            //    Table t = gvCaracter.in;
            //    t.Controls.Add(r);
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOut", "this.className = this.orignalclassName;");
                e.Row.Attributes.Add("OnMouseOver", "this.orignalclassName = this.className;this.className = 'SelectedRow';");
            }
            
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DropDownList ddlDepartment = (DropDownList)e.Row.FindControl("ddlDepartment");
            //    if (ddlDepartment != null)
            //    {
            //        ddlDepartment.DataSource = new mainACCESS().getDepartmentList();
            //        ddlDepartment.DataBind();
            //        ddlDepartment.SelectedValue = gvEG.DataKeys[e.Row.RowIndex].Values[1].ToString();
            //    }
            //}
            //else if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    DropDownList ddlDepartment = (DropDownList)e.Row.FindControl("ddlDepartment");
            //    ddlDepartment.DataSource = new mainACCESS().getDepartmentList(); ;
            //    ddlDepartment.DataBind();
            //}
            
        }
        protected void gvCaracter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                //BEReglas BE = new BEReglas();
                //eInfo.EmployeeCode = Convert.ToString(((TextBox)gvEG.FooterRow.FindControl("txtEmployeeCode")).Text);
                //BE.caracter = ((TextBox)gvCaracter.FooterRow.FindControl("txtCaracter")).Text;
                //BE.tipo = ((DropDownList)gvCaracter.FooterRow.FindControl("ddlTipoCaracter")).SelectedValue;
                //eInfo.DepartmentName = Convert.ToString(((DropDownList)gvEG.FooterRow.FindControl("ddlDepartment")).SelectedItem.Text);
                //eInfo.EmployeeGroup = ((DropDownList)gvEG.FooterRow.FindControl("ddlEmployeeGroup")).SelectedValue;
                //eInfo.Email = ((TextBox)gvEG.FooterRow.FindControl("txtEmail")).Text;
                //eInfo.isActive = ((CheckBox)gvEG.FooterRow.FindControl("chkActive")).Checked;
                //new mainACCESS().insertEmployeeInfo(eInfo);
                //FillEmployeeGrid();
                BEReglas BE = new BEReglas();
                List<BEReglas> lstBE = new List<BEReglas>();
                if (!(Session["LstBE"] == null))
                {
                    lstBE = (List<BEReglas>)Session["LstBE"];
                }
                //GridViewRow row;
                //row = gvCaracterAceptado.Rows[gvCaracterAceptado.SelectedIndex];
                BE.codCaracter = "0";
                BE.caracter = ((TextBox)gvCaracter.FooterRow.FindControl("txtCaracter")).Text;
                BE.tipo = ((DropDownList)gvCaracter.FooterRow.FindControl("ddlTipoCaracter")).SelectedValue;
                lstBE.Add(BE);
                gvCaracter.DataSource = lstBE;
                gvCaracter.DataBind();
                Session["LstBE"] = lstBE;
            }
        }
        protected void gvCaracter_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Int64 ID = Convert.ToInt64(gvCaracter.DataKeys[e.RowIndex].Values[0].ToString());
            //new mainACCESS().deleteEmployeeInfo(ID);
            //FillEmployeeGrid();
            BEReglas BE = new BEReglas();
            List<BEReglas> lstBE = new List<BEReglas>();
            if (!(Session["LstBE"] == null))
            {
                lstBE = (List<BEReglas>)Session["LstBE"];
            }
            //GridViewRow row;
            //row = gvCaracterAceptado.Rows[gvCaracterAceptado.SelectedIndex];
            //BE.caracter = "A";
            //BE.tipo = "1";
            lstBE.RemoveAt(e.RowIndex);
            gvCaracter.DataSource = lstBE;
            gvCaracter.DataBind();
            Session["LstBE"] = lstBE;
        }
        */
    }
}