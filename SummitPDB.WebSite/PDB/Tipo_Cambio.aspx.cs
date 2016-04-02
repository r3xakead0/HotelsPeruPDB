using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitPDB.ServicesInterface;
using SummitPDB.BusinessEntities;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace SummitPDB.WebSite.PDB
{
    public partial class Tipo_Cambio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx"); 
            if (!IsPostBack)
            {
                if (validatePeriodo() == "1")
                {
                    loadDropPeriodos();
                  //  loadGridHotel();
                    Carga_de_Grilla();
                }/*sino mostrar mensaje de error y desabilitar el panel*/
            }
        }


        //private String cCodLocal
        //{
        //    get { return (String)ViewState["cCodLocal"]; }
        //    set { ViewState.Add("cCodLocal", value); }
        //}

        protected void loadGridHotel(int npageIndex = 0)
        {
            ICompras IService = new ICompras();
            BECompras BE = new BECompras();
            BE.codPeriodo = ddlPeriodos.SelectedValue;
            gvHotels.DataSource = IService.IGetCompras(BE);
            gvHotels.PageIndex = npageIndex;
            gvHotels.DataBind();
        }

        protected void loadDropPeriodos()
        {
            IPeriodos IService = new IPeriodos();

            BEPeriodo_Mant objPeriodo = new BEPeriodo_Mant();

            List<BEPeriodo_Mant> lstPeriodoEmpresa = new List<BEPeriodo_Mant>();
            lstPeriodoEmpresa = IService.IGetPeriodos(objPeriodo);

            ddlPeriodos.DataSource = lstPeriodoEmpresa;
            ddlPeriodos.DataValueField = "codPeriodo";
            ddlPeriodos.DataTextField = "descPeriodo";
            ddlPeriodos.DataBind();
        }

        public void Carga_de_Grilla()
        {
            try
            {
                BEUser BE = new BEUser();
                BE = (BEUser)Session["LoginUser"];
                List<BETipo_Cambio> lstTipo_Cambio = new List<BETipo_Cambio>();

                ITipo_Cambio IService_Tipo_Cambio = new ITipo_Cambio();
                List<BETipo_Cambio> lstBE = new List<BETipo_Cambio>();
                lstBE = IService_Tipo_Cambio.IGetTipo_Cambio(int.Parse( this.ddlPeriodos.SelectedValue));

                gvHotels.DataSource = lstBE;

                gvHotels.DataBind();

            }
            catch (Exception ex)
            {
                gvHotels.DataSource = null;

                gvHotels.DataBind();

            }
            finally
            {

            }

        }

        protected string validatePeriodo()
        {
            IPeriodos i = new IPeriodos();
            return i.IValPeriodo();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Carga_de_Grilla();
        }

        protected void ddlPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carga_de_Grilla();
        }



      

    }
}