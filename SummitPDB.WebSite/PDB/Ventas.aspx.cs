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
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                if (validatePeriodo() == "1")
                {
                    //Validacion_Casillas();
                    loadDropPeriodos(true);
                    loadGridHotel();
                }/*sino mostrar mensaje de error y desabilitar el panel*/
            }
        }

        public void Validacion_Casillas()
        {
            txtApeMaterno.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtApePaterno.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtBaseImponible.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtBaseImponibleOperGravada.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtBaseImponibleOperGravadaNC.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtCantDoc.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            //txtCodDestino.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtDesde.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtFechaDocOriginal.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtFechaEmision.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtHasta.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtIgv.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtIGVNC.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            //txtIndicePercepcion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtIsc.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNombre1.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNombre2.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumDocOriginal.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumDocPercepcion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumDocumento.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumero.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumeroDestino.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtOtros.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtRazonSocialCliente.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtSerie.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtSerieDocOriginal.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtSeriePercepcion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            //txtTasaPercepcion.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            //txtTipo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            //txtTipoDocPersona.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            //txtTipoMoneda.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            //txtTipoPersona.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtTipoTabla10.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            //txtTipoVenta.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");


            txtSerie.MaxLength = 3;
        }

        #region void
        private String cCodLocal
        {
            get { return (String)ViewState["cCodLocal"]; }
            set { ViewState.Add("cCodLocal", value); }
        }
        private void ObtenerIdSelect(GridView Gv)
        {
            if (Gv.SelectedIndex != -1)
            {
                Label lblId = new Label();
                lblId = (Label)Gv.Rows[Gv.SelectedIndex].FindControl("lblId");
                //cVarAux = lblId.Text;
            }
        }
        protected void loadGridHotel(int npageIndex = 0)
        {
            IHotels IServiceHotel = new IHotels();
            BEHotel BEHotel = new BEHotel();
            IVentas IService = new IVentas();
            BEVentas BE = new BEVentas();
            BE.codLocal = ddlLocales.SelectedValue;
            BE.codPeriodo = ddlPeriodos.SelectedValue;

            BEHotel.codLocal = ddlLocales.SelectedValue;
            BEHotel.codPeriodo = ddlPeriodos.SelectedValue;

            /**/
            BE.tipoPrmSearch = Convert.ToInt32(ddlTipoPrm.SelectedValue);
            //if (rdoNombre.Checked)
            //    BE.tipoPrmSearch = 1;
            //if (rdoApellido.Checked)
            //    BE.tipoPrmSearch = 2;
            //if (rdoFicha.Checked)
            //    BE.tipoPrmSearch = 3;
            //if (rdoSerie.Checked)
            //    BE.tipoPrmSearch = 4;
            //if (rdoCorrelativo.Checked)
            //    BE.tipoPrmSearch = 5;
            BE.textPrmSearch = txtPrmSearch.Text.Trim();
            if (chkRangeDate.Checked)
            {
                BE.prmDesde = txtDesde.Text;
                BE.prmHasta = txtHasta.Text;
            }
            /**/
            gvHotels.DataSource = IService.IGetVentas(BE);
            gvHotels.PageIndex = npageIndex;
            gvHotels.DataBind();
            txtBaseImponible.Text = IServiceHotel.IGetImponible(BEHotel, "1");
            txtCantDoc.Text = IServiceHotel.IGeNumeroDocumentos(BEHotel, "V");
            txtIGVTot.Text = IServiceHotel.IGeIGVVentas(BEHotel);
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
                        { return PE.descPeriodo == objPerEmp.descPeriodo; });
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
        protected void loadListErrors()
        {
            IVentas IService = new IVentas();
            List<BEVentas> lstBE = new List<BEVentas>();
            BEVentas BEVentas = new BEVentas();

            BEVentas.codLocal = ddlLocales.SelectedValue;
            BEVentas.codPeriodo = ddlPeriodos.SelectedValue;
            /**/
            BEVentas.tipoPrmSearch = Convert.ToInt32(ddlTipoPrm.SelectedValue);
            BEVentas.textPrmSearch = txtPrmSearch.Text.Trim();
            if (chkRangeDate.Checked)
            {
                BEVentas.prmDesde = txtDesde.Text;
                BEVentas.prmHasta = txtHasta.Text;
            }
            /**/
            lstBE = IService.IGetVentas(BEVentas);


            lstErrorList.DataSource = IService.IvalidarCaracteres(lstBE);
            lstErrorList.DataBind();
        }
        protected void applyRules()
        {
            IVentas IService = new IVentas();
            List<BEVentas> lstBE = new List<BEVentas>();
            BEVentas BEVenta = new BEVentas();

            BEVenta.codLocal = ddlLocales.SelectedValue;
            BEVenta.codPeriodo = ddlPeriodos.SelectedValue;
            /**/
            BEVenta.tipoPrmSearch = Convert.ToInt32(ddlTipoPrm.SelectedValue);
            BEVenta.textPrmSearch = txtPrmSearch.Text.Trim();
            if (chkRangeDate.Checked)
            {
                BEVenta.prmDesde = txtDesde.Text;
                BEVenta.prmHasta = txtHasta.Text;
            }
            /**/
            lstBE = IService.IGetVentas(BEVenta);

            List<BEVentas> lstBE2 = new List<BEVentas>();
            lstBE2 = IService.IaplicarReglas(lstBE);
            IService.IUpdListHotels(lstBE2);
            gvHotels.DataSource = lstBE2;
            gvHotels.DataBind();

            /*List<BEHotel> lstBE2 = (List<BEHotel>)this.gvHotels.DataSource;
            gvHotels.DataSource = IService.IInsListHotels(lstBE2);
            gvHotels.DataBind();*/
        }
        protected void loadDocDistintos()
        {
            IHotels IService = new IHotels();
            BEHotel objBE = new BEHotel();
            objBE.codLocal = ddlLocales.SelectedValue;
            objBE.codPeriodo = ddlPeriodos.SelectedValue;
            lstDocDistintos.DataSource = IService.IGetDocDistintosVentas(objBE);
            lstDocDistintos.DataTextField = "correlativo";
            lstDocDistintos.DataBind();
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
        protected void btnValid_Click(object sender, EventArgs e)
        {
            loadListErrors();
            ClientScript.RegisterStartupScript(typeof(Page), "ButtonAlert", "showValid();", true);
        }
        protected void btnApplyRules_Click(object sender, EventArgs e)
        {
            applyRules();
        }
        protected void btnSaveApplyRulers_Click(object sender, EventArgs e)
        {
            IHotels IService = new IHotels();
            List<BEHotel> lstBE = new List<BEHotel>();
            BEHotel BEHotel = new BEHotel();
            BEHotel.codLocal = ddlLocales.SelectedValue;
            BEHotel.codPeriodo = ddlPeriodos.SelectedValue;
            lstBE = IService.IGetHotels(BEHotel);


            List<BEHotel> lstBE2 = new List<BEHotel>();
            lstBE2 = IService.IaplicarReglas(lstBE);
            string respuesta = IService.IUpdListHotels(lstBE2);
        }
        protected void ddlLocales_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDropPeriodos();
            ddlTipoPrm.SelectedValue = "1";
            txtPrmSearch.Text = string.Empty;
            chkRangeDate.Checked = false;
            txtDesde.Text = string.Empty;
            txtHasta.Text = string.Empty;
            loadGridHotel();
        }
        protected void btnDocDistintos_Click(object sender, EventArgs e)
        {
            loadDocDistintos();
            ClientScript.RegisterStartupScript(typeof(Page), "showPopupDocDistintos", "showPopup('dvDocDistintos',260);", true);
        }
        #endregion
        #region WebMethod
        //Insert Update
        [WebMethod]
        public static string InsUpdVentas(BEVentas obj)
        {
            IVentas IService = new IVentas();
            return obj.idVentas == "0" ? IService.IInsVentas(obj) : IService.IUpdVentas(obj);
        }

        //Delete
        [WebMethod]
        public static string DelVentas(BEVentas obj)
        {
            IVentas IService = new IVentas();
            return IService.IDelVentas(obj);
        }
        #endregion

        protected void ddlPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTipoPrm.SelectedValue = "1";
            txtPrmSearch.Text = string.Empty;
            chkRangeDate.Checked = false;
            txtDesde.Text = string.Empty;
            txtHasta.Text = string.Empty;
            loadGridHotel();
        }

        public void Cargar_Combos()
        {
            //IPeriodos IService = new IConceptos();
            ////Dim obj As UserStore = DirectCast(Session.Item("SessionUser"), UserStore)
            //BEUser BE = new BEUser();
            //BE = (BEUser)Session["LoginUser"];
            //List<BEPeriodoEmpresa> lstPeriodoEmpresa = new List<BEPeriodoEmpresa>();
            //lstPeriodoEmpresa = IService.IGetPeriodos(BE);
            //ddlPeriodos.DataSource = lstPeriodoEmpresa;
            //ddlPeriodos.DataValueField = "codPeriodoEmpresa";
            //ddlPeriodos.DataTextField = "descPeriodo";
            //ddlPeriodos.DataBind();
        }

    }
}