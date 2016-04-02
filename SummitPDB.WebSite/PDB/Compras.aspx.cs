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
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                if (validatePeriodo() == "1")
                {
                    //txtApeMaterno.Enabled = false;
                    //txtApeMaterno.BackColor = System.Drawing.Color.LightGray;

                    loadDropPeriodos(true);
                    loadGridHotel();
                }/*sino mostrar mensaje de error y desabilitar el panel*/
            }
        }

        #region void
        private String cCodLocal
        {
            get { return (String)ViewState["cCodLocal"]; }
            set { ViewState.Add("cCodLocal", value); }
        }
        protected void loadGridHotel(int npageIndex = 0)
        {
            ICompras IService = new ICompras();

            IHotels IServiceHotel = new IHotels();
            BEHotel BEHotel = new BEHotel();
            BEHotel.codLocal = ddlLocales.SelectedValue;
            BEHotel.codPeriodo = ddlPeriodos.SelectedValue;

            BECompras BE = new BECompras();
            BE.codLocal = ddlLocales.SelectedValue;
            BE.codPeriodo = ddlPeriodos.SelectedValue;
            BE.tipoPrmSearch = Convert.ToInt32(ddlTipoPrm.SelectedValue);
            BE.textPrmSearch = txtPrmSearch.Text.Trim();
            if (chkRangeDate.Checked)
            {
                BE.prmDesde = txtDesde.Text;
                BE.prmHasta = txtHasta.Text;
            }
            gvHotels.DataSource = IService.IGetCompras(BE);
            gvHotels.PageIndex = npageIndex;
            gvHotels.DataBind();

            txtBaseImponible.Text = IServiceHotel.IGetImponible(BEHotel, "2");
            txtCantDoc.Text = IServiceHotel.IGeNumeroDocumentos(BEHotel, "C");
            txtIGVTot.Text = IServiceHotel.IGeIGVCompras(BEHotel);
        }
        protected void loadDropPeriodos(Boolean loadLocal = false)
        {
            int index = ddlPeriodos.SelectedIndex;
            IPeriodos IService = new IPeriodos();
            //Dim obj As UserStore = DirectCast(Session.Item("SessionUser"), UserStore)
            BEUser BE = new BEUser();
            BE = (BEUser)Session["LoginUser"];
            List<BEPeriodoEmpresa> lstPeriodoEmpresa = new List<BEPeriodoEmpresa>();

            List<BEPeriodoEmpresa> AlllistaPeriodos = IService.IGetPeriodos(BE);

            cCodLocal = AlllistaPeriodos[0].codLocal;
            if (loadLocal)
                loadDropLocal(cCodLocal);

            cCodLocal = ddlLocales.SelectedValue;

            if (!string.IsNullOrEmpty(cCodLocal))
            {
                lstPeriodoEmpresa = AlllistaPeriodos.FindAll(
                delegate(BEPeriodoEmpresa PE)
                {
                    return PE.codLocal == cCodLocal;
                });
            }
            else
            {
                foreach (BEPeriodoEmpresa objPerEmp in AlllistaPeriodos)
                {
                    List<BEPeriodoEmpresa> LstPerEmpToadd = lstPeriodoEmpresa.FindAll(
                        delegate(BEPeriodoEmpresa PE)
                        {return PE.descPeriodo == objPerEmp.descPeriodo;});
                    if (LstPerEmpToadd == null || LstPerEmpToadd.Count == 0)
                        lstPeriodoEmpresa.Add(objPerEmp);
                }
            }

            ddlPeriodos.DataSource = lstPeriodoEmpresa;
            ddlPeriodos.DataValueField = "codPeriodoEmpresa";
            ddlPeriodos.DataTextField = "descPeriodo";
            ddlPeriodos.DataBind();


            if (index < lstPeriodoEmpresa.Count) ddlPeriodos.SelectedIndex = index;
        }
        protected void loadDropLocal(string cCodLocal)
        {
            ILocal IService = new ILocal();
            BELocal BE = new BELocal();
            BE.codLocal = cCodLocal;

            BEUser BEuser = new BEUser();
            BEuser = (BEUser)Session["LoginUser"];
            if (BEuser.codRol == "3")
                BE.codLocal = string.Empty;
            else
                BE.codLocal = cCodLocal;

            ddlLocales.DataSource = IService.IGetLocal(BE);
            ddlLocales.DataValueField = "codLocal";
            ddlLocales.DataTextField = "nomLocal";
            ddlLocales.DataBind();
        }
        protected string validatePeriodo()
        {
            IPeriodos i = new IPeriodos();
            return i.IValPeriodo();
        }
        #endregion
        #region function
        #endregion
        #region event

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            loadGridHotel();
        }
        protected void gvHotels_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOut", "this.className = this.orignalclassName;");
                e.Row.Attributes.Add("OnMouseOver", "this.orignalclassName = this.className;this.className = 'SelectedRow';");
                e.Row.Attributes["OnClick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvHotels, "Select$" + e.Row.RowIndex.ToString());
            }

        }
        protected void gvHotels_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadGridHotel(e.NewPageIndex);
        }
        #endregion
        #region WebMethod
        //Insert Update
        [WebMethod]
        public static string InsUpdCompras(BECompras obj)
        {
            ICompras IService = new ICompras();
            return obj.idCompras == "0" ? IService.IInsCompras(obj) : IService.IUpdCompras(obj);
        }


        //Delete
        [WebMethod]
        public static string DelCompras(BECompras obj)
        {
            ICompras IService = new ICompras();
            return IService.IDelCompras(obj);
        }
        #endregion

        protected void ddlPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGridHotel();
        }

        protected void ddlLocales_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDropPeriodos();
        }

    }
}