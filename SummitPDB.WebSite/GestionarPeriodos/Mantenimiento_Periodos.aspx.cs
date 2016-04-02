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
    public partial class Mantenimiento_Periodos : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx"); 

            ////Add Default Item in the DropDownList
            //ddlCountries.Items.Insert(0, new ListItem("Please select"));

            ////Select the Country of Customer in DropDownList
            //string country = (e.Row.FindControl("lblCountry") as Label).Text;
            //ddlCountries.Items.FindByValue(country).Selected = true;
         

        
            if (!IsPostBack)
            {

                    this.Lbl_Mensaje_Proceso.Visible = false;
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
                    this.Cmb_Ano.Items.Add("2023");
                    this.Cmb_Ano.Items.Add("2024");
                    this.Cmb_Ano.Items.Add("2025");
                    this.Cmb_Ano.Items.Add("2026");
                    this.Cmb_Ano.Items.Add("2027");
                    this.Cmb_Ano.Items.Add("2028");
                    this.Cmb_Ano.Items.Add("2029");
                    this.Cmb_Ano.Items.Add("2030");
                    this.Cmb_Ano.Items.Add("2031");
                    this.Cmb_Ano.Items.Add("2032");
                    this.Cmb_Ano.Items.Add("2033");
                    this.Cmb_Ano.Items.Add("2034");
                    this.Cmb_Ano.Items.Add("2035");
                    this.Cmb_Ano.Items.Add("2036");
                    this.Cmb_Ano.Items.Add("2037");
                    this.Cmb_Ano.Items.Add("2038");
                    this.Cmb_Ano.Items.Add("2039");
                    this.Cmb_Ano.Items.Add("2040");


                    this.Cmb_Meses.Items.Add("Enero");
                    this.Cmb_Meses.Items.Add("Febrero");
                    this.Cmb_Meses.Items.Add("Marzo");
                    this.Cmb_Meses.Items.Add("Abril");
                    this.Cmb_Meses.Items.Add("Mayo");
                    this.Cmb_Meses.Items.Add("Junio");
                    this.Cmb_Meses.Items.Add("Julio");
                    this.Cmb_Meses.Items.Add("Agosto");
                    this.Cmb_Meses.Items.Add("Septiembre");
                    this.Cmb_Meses.Items.Add("Octubre");
                    this.Cmb_Meses.Items.Add("Noviembre");
                    this.Cmb_Meses.Items.Add("Diciembre");
                    
                    Carga_de_Grilla();
                    Carga_de_Grilla_Detalle();
                    Lbl_Mensaje_Proceso.Visible = false;
            }
        }
        public void Carga_de_Grilla_Detalle()
        {
            IPeriodos IService = new IPeriodos();
            List<BEPeriodoEmpresa_Mant> lstBE = new List<BEPeriodoEmpresa_Mant>();
            int mes_int = 0;
            switch (this.Cmb_Meses.Text)
            {
                case "Enero":
                    mes_int=1;
                    break;
                case "Febrero":
                    mes_int=2;
                    break;
                case "Marzo":
                    mes_int=3;
                    break;
                case "Abril":
                    mes_int=4;
                    break;
                case "Mayo":
                    mes_int=5;
                    break;
                case "Junio":
                    mes_int=6;
                    break;
                case "Julio":
                    mes_int=7;
                    break;
                case "Agosto":
                    mes_int=8;
                    break;
                case "Septiembre":
                    mes_int=9;
                    break;
                case "Octubre":
                    mes_int=10;
                    break;
                case "Noviembre":
                    mes_int=11;
                    break;
                case "Diciembre":
                    mes_int=12;
                    break;
                default:
                    mes_int=0;
                    break;
            }

            lstBE = IService.IGetPeriodosEmpresa_MANT(int.Parse(this.Cmb_Ano.Text),mes_int);
            Grid_Detalle.DataSource = lstBE;
            Grid_Detalle.DataBind();
        }
        public void Carga_de_Grilla()
        {
            IPeriodos IService = new IPeriodos();
            List<BEPeriodo_Mant> lstBE = new List<BEPeriodo_Mant>();
            lstBE = IService.IGetPeriodos_MANT(int.Parse(this.Cmb_Ano.Text));
            Grilla_Periodos.DataSource = lstBE;
            Grilla_Periodos.DataBind();

        }

        protected void Btn_Proceso_Click(object sender, EventArgs e)
        {
            IPeriodos IService = new IPeriodos();
            this.Lbl_Mensaje_Proceso.Text = IService.IGetPeriodos_Creacion(int.Parse(this.Cmb_Ano.Text));
            Carga_de_Grilla();

            this.Lbl_Mensaje_Proceso.Visible = true;
        }

        protected void Grilla_Periodos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            this.Lbl_Mensaje_Proceso.Text = this.Grilla_Periodos.Rows[e.RowIndex].Cells[0].Text.Trim();
        }

        protected void Grilla_Periodos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           // this.Lbl_Mensaje_prueba.Text = this.Grilla_Periodos.Rows[e.NewSelectedIndex].Cells[0].Text.Trim() + this.Grilla_Periodos.Rows[e.NewSelectedIndex].Cells[1].Text.Trim() + this.Grilla_Periodos.Rows[e.NewSelectedIndex].Cells[2].Text.Trim() + this.Grilla_Periodos.Rows[e.NewSelectedIndex].Cells[3].Text.Trim();
        }

        protected void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Carga_de_Grilla_Detalle();
        }

        protected void Btn_Año_Click(object sender, EventArgs e)
        {
            Carga_de_Grilla();
            Carga_de_Grilla_Detalle();
        }

        protected void Grilla_Periodos_Hotel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                IEstado IService = new IEstado();
                List<BEEstado> lstBE = new List<BEEstado>();
                lstBE = IService.IgetEstados();
                //Find the DropDownList in the Row

                DropDownList ddlCountries_Hotel = (e.Row.FindControl("ddlCountries_Hotel") as DropDownList);
                ddlCountries_Hotel.DataSource = lstBE;
                ddlCountries_Hotel.DataTextField = "descripcion";
                ddlCountries_Hotel.DataValueField = "codEstado";
                ddlCountries_Hotel.DataBind();
                ////Add Default Item in the DropDownList
                ////ddlCountries.Items.Insert(0, new ListItem("Please select"));
          
                //// Select the Country of Customer in DropDownList

                string country_Hotel = (e.Row.FindControl("lblCountry_Hotel") as Label).Text;
                ddlCountries_Hotel.Items.FindByValue(country_Hotel).Selected = true;
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

        protected void Btn_Guardar_Click(object sender, EventArgs e)
        {
            DropDownList combo;
            Int64 Estado;
            IPeriodos IService = new IPeriodos();
            string resp;
            for (int i = 0; i <= 11; i++)
            {

                combo = Grilla_Periodos.Rows[i].FindControl("ddlCountries") as DropDownList;
                Estado = Convert.ToInt32(combo.SelectedValue);
               // Lbl_Mensaje_Proceso.Text = IService.IGetPeriodos_Actualizar_Estados(int.Parse(this.Cmb_Ano.Text), i + 1, Estado);
                resp =IService.IGetPeriodos_Actualizar_Estados(int.Parse(this.Cmb_Ano.Text), i + 1, Estado);
                switch (resp)
                {
                    case "1":
                        Lbl_Mensaje_Proceso.Text = "No todas las sucursales en el mes de" + this.Cmb_Meses.Text + " se encuentran en estado de Precierre porfavor verificar";
                        i = 12;
                        break;
                    case "0":
                        Lbl_Mensaje_Proceso.Text = "El proceso se completo Exitosamente";
                        break;
                  
                }
                
            }

            Carga_de_Grilla();
            Carga_de_Grilla_Detalle();
            Lbl_Mensaje_Proceso.Visible = true;
        }

        protected void Btn_Guardar_Hotel_Click(object sender, EventArgs e)
        {
            int mes_int = 0;
            switch (this.Cmb_Meses.Text)
            {
                case "Enero":
                    mes_int = 1;
                    break;
                case "Febrero":
                    mes_int = 2;
                    break;
                case "Marzo":
                    mes_int = 3;
                    break;
                case "Abril":
                    mes_int = 4;
                    break;
                case "Mayo":
                    mes_int = 5;
                    break;
                case "Junio":
                    mes_int = 6;
                    break;
                case "Julio":
                    mes_int = 7;
                    break;
                case "Agosto":
                    mes_int = 8;
                    break;
                case "Septiembre":
                    mes_int = 9;
                    break;
                case "Octubre":
                    mes_int = 10;
                    break;
                case "Noviembre":
                    mes_int = 11;
                    break;
                case "Diciembre":
                    mes_int = 12;
                    break;
                default:
                    mes_int = 0;
                    break;
            }
            Label lbl_Cod_Local;

            DropDownList combo;
            Int64 Estado;
            IPeriodos IService = new IPeriodos();

            for (int i = 0; i <= Grid_Detalle.Rows.Count-1; i++)
            {

                lbl_Cod_Local = this.Grid_Detalle.Rows[i].FindControl("lblCodLocal_Hotel") as Label;
                combo = Grid_Detalle.Rows[i].FindControl("ddlCountries_Hotel") as DropDownList;
                Estado = Convert.ToInt32(combo.SelectedValue);
                this.Lbl_Mensaje_Proceso.Text = IService.IGetPeriodosEmpresa_Actualizar_Estados(int.Parse(this.Cmb_Ano.Text), mes_int, int.Parse(lbl_Cod_Local.Text), Estado);

            }
            Carga_de_Grilla_Detalle();

            Carga_de_Grilla();
        }

        protected void Grid_Detalle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Cmb_Ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carga_de_Grilla();
        }

        protected void Cmb_Meses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carga_de_Grilla_Detalle();
        }



    }
}