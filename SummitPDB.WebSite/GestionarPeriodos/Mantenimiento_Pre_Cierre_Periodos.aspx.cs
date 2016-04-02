using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitPDB.BusinessEntities;
using SummitPDB.ServicesInterface;
using System.Web.Services;

namespace SummitPDB.WebSite.GestionarPeriodos
{
    public partial class Mantenimiento_Pre_Cierre_Periodos : System.Web.UI.Page
    {
        private static int Cod_Local;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx"); 

            if (!IsPostBack)
            {

                this.Lbl_Mensaje.Visible = false;
                this.Cmb_Ano.Items.Clear();
                this.Cmb_Ano.Items.Add("2010");
                this.Cmb_Ano.Items.Add("2011");
                this.Cmb_Ano.Items.Add("2012");
                this.Cmb_Ano.Items.Add("2013");
                this.Cmb_Ano.Items.Add("2014");
                this.Cmb_Ano.Items.Add("2015");
                this.Cmb_Ano.Items.Add("2016");
                this.Cmb_Ano.Items.Add("2017");
                this.Cmb_Ano.Items.Add("2018");
                this.Cmb_Ano.Items.Add("2019");
                this.Cmb_Ano.Items.Add("2020");
                this.Cmb_Ano.Items.Add("2021");
                this.Cmb_Ano.Items.Add("2022");


                Carga_de_Grilla();
            }
        }

        public void Carga_de_Grilla()
        {
            try
            {
                this.Lbl_Sucursal.Text = " - ";
                BEUser BE = new BEUser();
                BE = (BEUser)Session["LoginUser"];
                List<BEPeriodoEmpresa_Mant> lstPeriodoEmpresa = new List<BEPeriodoEmpresa_Mant>();

                IPeriodos IService_Periodo = new IPeriodos();
                List<BEPeriodoEmpresa_Mant> lstBE = new List<BEPeriodoEmpresa_Mant>();
                lstBE = IService_Periodo.IGetPeriodosEmpresa_Localanio(int.Parse(this.Cmb_Ano.Text), int.Parse(BE.codLocal));

                Cod_Local = int.Parse(BE.codLocal);

                this.Lbl_Sucursal.Text = lstBE[0].Hotel;

                Grilla_Periodos.DataSource = lstBE;

                Grilla_Periodos.DataBind();

                DropDownList combo;
                IPeriodos IService = new IPeriodos();


                for (int i = 0; i <= 11; i++)
                {
                    combo = Grilla_Periodos.Rows[i].FindControl("ddlCountries") as DropDownList;
                    if (combo.SelectedValue == "3" || combo.SelectedValue == "0" || combo.SelectedValue == "2")
                    {
                        combo.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Grilla_Periodos.DataSource= null;

                Grilla_Periodos.DataBind();

            }
            finally
            {

            }
        
        }

        protected void Grilla_Periodos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                IEstado IService = new IEstado();
                List<BEEstado> lstBE = new List<BEEstado>();
                lstBE = IService.IgetEstados();
                //Find the DropDownList in the Row
                DropDownList ddlCountries = (e.Row.FindControl("ddlCountries") as DropDownList);
                ddlCountries.DataSource = lstBE;
                ddlCountries.DataTextField = "descripcion";
                ddlCountries.DataValueField = "codEstado";
                ddlCountries.DataBind();

                ////Add Default Item in the DropDownList
                ////ddlCountries.Items.Insert(0, new ListItem("Please select"));

                //// Select the Country of Customer in DropDownList

                string country = (e.Row.FindControl("lblCountry") as Label).Text;
                ddlCountries.Items.FindByValue(country).Selected = true;

            }
        }

        protected void Btn_Año_Click(object sender, EventArgs e)
        {
            Carga_de_Grilla();
        }

        protected void Btn_Guardar_Click(object sender, EventArgs e)
        {
            DropDownList combo;
            Int64 Estado;
            IPeriodos IService = new IPeriodos();
            
            for (int i = 0; i <= 11; i++)
            {
           
            combo =Grilla_Periodos.Rows[i].FindControl("ddlCountries") as DropDownList;
            Estado = Convert.ToInt32(combo.SelectedValue);
            this.Lbl_Mensaje.Text = IService.IGetPeriodosEmpresa_Actualizar_Estados(int.Parse(this.Cmb_Ano.Text), i+1, Cod_Local, Estado);

            }

            Carga_de_Grilla();
        }

        protected void Cmb_Ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carga_de_Grilla();
        }

    }
}