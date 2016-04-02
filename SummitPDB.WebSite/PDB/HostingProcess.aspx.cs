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
    public partial class HostingProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                if (validatePeriodo() == "1")
                {
                    Validacion_Casillas();
                    loadDropPais();
                    loadDropPeriodos(true);
                    loadGridHotel();
                    Bloqueo_y_Carga();
                    //loadGridDuplicar();
                }/*sino mostrar mensaje de error y desabilitar el panel*/
            }


        }

        public void Validacion_Casillas()
        {
            txtSerie.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtCorrelativo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtRuc.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNroFicha.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            //txtPasaporte.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNombre2.Attributes.Add("onkeypress", "javascript:return ValidText(event);");
            txtNombre.Attributes.Add("onkeypress", "javascript:return ValidText(event);");
            txtApeMaterno.Attributes.Add("onkeypress", "javascript:return ValidText(event);");
            txtApePaterno.Attributes.Add("onkeypress", "javascript:return ValidText(event);");
            ddlPaisPasaporte.Attributes.Add("onkeypress", "javascript:return ValidText(event);");
            ddlPaisProcedencia.Attributes.Add("onkeypress", "javascript:return ValidText(event);");

            txtNumCorrFactura.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumCorrNC.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumSerieFactura.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumSerieNC.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

            txtSerie.MaxLength = 3;
            txtCorrelativo.MaxLength = 12;
            //txtRuc.MaxLength = 12;
            //txtNroFicha.MaxLength = ;
            //txtPasaporte.MaxLength = 3;
            //txtNombre2.MaxLength = 3;
            //txtNombre.MaxLength = 3;
            //txtApeMaterno.MaxLength = 3;
            //txtApePaterno.MaxLength = 3;
            //ddlPaisPasaporte.MaxLength = 3;
            //ddlPaisProcedencia.MaxLength = 3;

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
            IHotels IService = new IHotels();
            BEHotel BEHotel = new BEHotel();
            BEHotel.codLocal = ddlLocales.SelectedValue;
            BEHotel.codPeriodo = ddlPeriodos.SelectedValue;
            /**/
            BEHotel.tipoPrmSearch = Convert.ToInt32(ddlTipoPrm.SelectedValue);
            BEHotel.textPrmSearch = txtPrmSearch.Text.Trim();
            //if (chkRangeDate.Checked)
            if (ddlTipoFechaPrm.SelectedValue != "0")
            {
                BEHotel.tipoFechaPrm = Convert.ToInt32(ddlTipoFechaPrm.SelectedValue);
                BEHotel.prmDesde = txtDesde.Text;
                BEHotel.prmHasta = txtHasta.Text;
            }
            /**/
            gvHotels.DataSource = IService.IGetHotels(BEHotel);
            gvHotels.PageIndex = npageIndex;
            gvHotels.DataBind();


            txtBaseImponible.Text = IService.IGetImponible(BEHotel, "1");
            txtCantDoc.Text = IService.IGeNumeroDocumentos(BEHotel, "H");
        }
        protected void loadGridDuplicar(int npageIndex = 0)
        {
            lblOldCorrelativo.Text = "";
            lblNewCorrelativo.Text = "";
            IHotels IService = new IHotels();
            BEHotel BE = new BEHotel();
            BE.idHospedaje = gvHotels.SelectedRow.Cells[0].Text;
            BE.correlativo = gvHotels.SelectedRow.Cells[2].Text;
            BE.codLocal = ddlLocales.SelectedValue;
            BE.codPeriodo = ddlPeriodos.SelectedValue;
            BE.fechaDocumento = gvHotels.SelectedRow.Cells[16].Text;
            gvDuplicarRegistros.DataSource = IService.IGetHotelsAnteriores(BE);
            gvDuplicarRegistros.DataBind();
            if (gvDuplicarRegistros.Rows.Count > 0)
            {
                string fecha1 = gvDuplicarRegistros.Rows[0].Cells[15].Text;
                string fecha2 = gvHotels.SelectedRow.Cells[16].Text;
                lblOldCorrelativo.Text = gvDuplicarRegistros.Rows[0].Cells[3].Text + "  - Fecha:" + fecha1.Substring(6) + "/" + fecha1.Substring(4, 2) + "/" + fecha1.Substring(0, 4);
                //lblNewCorrelativo.Text = gvHotels.SelectedRow.Cells[2].Text + "  - Fecha:" + fecha2.Substring(6) + "/" + fecha2.Substring(4, 2) + "/" + fecha2.Substring(0, 4);
                lblNewCorrelativo.Text = gvHotels.SelectedRow.Cells[2].Text + "  - Fecha:" + fecha2;
                ////this.lblOldCorrelativo_Usar_Duplicar.Text = gvDuplicarRegistros.Rows[0].Cells[3].Text;
                ////this.lblNewCorrelativo_Usar_Duplicar.Text = gvHotels.SelectedRow.Cells[2].Text;
            }
            /**/
            BE = new BEHotel();
            BE.correlativo = gvHotels.SelectedRow.Cells[2].Text;
            BE.idHospedaje = gvHotels.SelectedRow.Cells[0].Text;

            //foreach (BEHotel beHotel in IService.IGetporCorrelativo(BE))
            //{
            //    this.Lbl_Fecha_New.Text =beHotel.fechaDocumento ;
            //}
            //BE = IService.IGetporCorrelativo(BE);
            //this.Lbl_Fecha_New.Text=  BE.fechaDocumento;
            gvViewRegistros.DataSource = IService.IGetporCorrelativo(BE);
            gvViewRegistros.DataBind();


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
            else {
                foreach (BEPeriodoEmpresa objPerEmp in AlllistaPeriodos)
                {
                    List<BEPeriodoEmpresa> LstPerEmpToadd = lstPeriodoEmpresa.FindAll(
                        delegate(BEPeriodoEmpresa PE)
                        {
                            return PE.descPeriodo == objPerEmp.descPeriodo;
                        });
                    if (LstPerEmpToadd == null || LstPerEmpToadd.Count==0)
                        lstPeriodoEmpresa.Add(objPerEmp);
                }
            }



            if (lstPeriodoEmpresa.Count > 0)
            {

                ddlPeriodos.DataSource = lstPeriodoEmpresa;
                ddlPeriodos.DataValueField = "codPeriodoEmpresa";
                ddlPeriodos.DataTextField = "descPeriodo";
                ddlPeriodos.DataBind();
                cCodLocal = lstPeriodoEmpresa[0].codLocal;
                if (index < lstPeriodoEmpresa.Count) ddlPeriodos.SelectedIndex = index;
            }
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
        //protected void loadDropPais()
        //{
        //    IHotels IService = new IHotels();
        //    List<BEPais> lst = new List<BEPais>();
        //    lst = IService.GetPaises();
        //    if (lst.Count > 0)
        //    {

        //        ddlPaisPasaporte.DataSource = lst;
        //        ddlPaisPasaporte.DataValueField = "descPais";
        //        ddlPaisPasaporte.DataTextField = "descPais";
        //        ddlPaisPasaporte.DataBind();

        //        ddlPaisProcedencia.DataSource = lst;
        //        ddlPaisProcedencia.DataValueField = "descPais";
        //        ddlPaisProcedencia.DataTextField = "descPais";
        //        ddlPaisProcedencia.DataBind();
        //    }
        //}
        protected void loadDropPais()
        {
            IHotels IService = new IHotels();
            List<BEPais> lst = new List<BEPais>();
            lst = IService.GetPaises();
            if (lst.Count > 0)
            {
                ddlPaisPasaporte.DataSource = lst;
                ddlPaisPasaporte.DataValueField = "codPais";
                ddlPaisPasaporte.DataTextField = "descPais";
                ddlPaisPasaporte.DataBind();

                ddlPaisProcedencia.DataSource = lst;
                ddlPaisProcedencia.DataValueField = "codPais";
                ddlPaisProcedencia.DataTextField = "descPais";
                ddlPaisProcedencia.DataBind();
            }
        }

        protected string validatePeriodo()
        {
            IPeriodos i = new IPeriodos();
            return i.IValPeriodo();
        }
        protected void loadListErrors()
        {
            IHotels IService = new IHotels();
            List<BEHotel> lstBE = new List<BEHotel>();
            BEHotel BEHotel = new BEHotel();
            BEHotel.codLocal = ddlLocales.SelectedValue;
            BEHotel.codPeriodo = ddlPeriodos.SelectedValue;
            /**/
            BEHotel.tipoPrmSearch = Convert.ToInt32(ddlTipoPrm.SelectedValue);
            BEHotel.textPrmSearch = txtPrmSearch.Text.Trim();
            //if (chkRangeDate.Checked)
            if (ddlTipoFechaPrm.SelectedValue != "0")
            {
                BEHotel.prmDesde = txtDesde.Text;
                BEHotel.prmHasta = txtHasta.Text;
            }
            /**/
            lstBE = IService.IGetHotelsValidados(BEHotel);
            lstErrorList.DataSource = IService.IvalidarCaracteres(lstBE);
            lstErrorList.DataBind();
        }
        protected void applyRules()
        {
            IHotels IService = new IHotels();
            List<BEHotel> lstBE = new List<BEHotel>();
            BEHotel BEHotel = new BEHotel();
            BEHotel.codLocal = ddlLocales.SelectedValue;
            BEHotel.codPeriodo = ddlPeriodos.SelectedValue;
            /**/
            BEHotel.tipoPrmSearch = Convert.ToInt32(ddlTipoPrm.SelectedValue);
            BEHotel.textPrmSearch = txtPrmSearch.Text.Trim();
            //if (chkRangeDate.Checked)
            if (ddlTipoFechaPrm.SelectedValue != "0")
            {
                BEHotel.prmDesde = txtDesde.Text;
                BEHotel.prmHasta = txtHasta.Text;
            }
            /**/
            lstBE = IService.IGetHotels(BEHotel);
            List<BEHotel> lstBE2 = new List<BEHotel>();
            lstBE2 = IService.IaplicarReglas(lstBE);
            IService.IUpdListHotels(lstBE2);
            gvHotels.DataSource = lstBE2;
            gvHotels.DataBind();

            /*List<BEHotel> lstBE2 = (List<BEHotel>)this.gvHotels.DataSource;
            gvHotels.DataSource = IService.IInsListHotels(lstBE2);
            gvHotels.DataBind();*/
            //List<BEHotel> lstBE2 = new List<BEHotel>();
            //lstBE2 = IService.IaplicarReglas(lstBE);
            //string respuesta = IService.IUpdListHotels(lstBE2);
        }

        protected void loadDocDistintos()
        {
            IHotels IService = new IHotels();
            BEHotel objBE = new BEHotel();
            objBE.codLocal = ddlLocales.SelectedValue;
            objBE.codPeriodo = ddlPeriodos.SelectedValue;
            lstDocDistintos.DataSource = IService.IGetDocDistintos(objBE);
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
                e.Row.Attributes["OnClick"] = Page.ClientScript.GetPostBackClientHyperlink(gvHotels, "Select$" + e.Row.RowIndex.ToString());
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
        protected void btnDuplicar_Click(object sender, EventArgs e)
        {
            loadGridDuplicar();
            ClientScript.RegisterStartupScript(typeof(Page), "showPopupDuplicar", "showPopup('dvDuplicar',793);", true);
        }
        protected void btnDocDistintos_Click(object sender, EventArgs e)
        {
            loadDocDistintos();
            ClientScript.RegisterStartupScript(typeof(Page), "showPopupDocDistintos", "showPopup('dvDocDistintos',260);", true);
        }
        protected void IbtnSaveDuplicados_Click(object sender, EventArgs e)
        {
            List<BEHotel> lstBE = new List<BEHotel>();
            BEHotel BE;
            IHotels IService = new IHotels();
            CheckBox chk;
            foreach (GridViewRow rowItem in gvDuplicarRegistros.Rows)
            {
                chk = (CheckBox)(rowItem.Cells[0].FindControl("RowCheckBox"));
                if (chk.Checked)
                {
                    BE = new BEHotel();
                    BE.idHospedaje = rowItem.Cells[0].Text;
                    BE.serie = rowItem.Cells[1].Text;
                    lblOldCorrelativo.Text = rowItem.Cells[2].Text;

                    BE.correlativo = rowItem.Cells[2].Text;
                    //BE.ruc = rowItem.Cells[3].Text;
                    //BE.agencia = rowItem.Cells[4].Text;
                    //BE.pasaporte = rowItem.Cells[5].Text;
                    //BE.apellidoPaterno = rowItem.Cells[6].Text;
                    //BE.paisPasaporte = rowItem.Cells[7].Text;
                    //BE.nombre = rowItem.Cells[8].Text;
                    //BE.fechaIngresoHotel = rowItem.Cells[9].Text;
                    //BE.fechaSalidaHotel = rowItem.Cells[10].Text;
                    //BE.nroFicha = rowItem.Cells[11].Text;
                    //BE.unidad = rowItem.Cells[12].Text;
                    //BE.ingresoPais = rowItem.Cells[13].Text;
                    //BE.fechaDocumento = rowItem.Cells[14].Text;
                    //BE.codLocal = rowItem.Cells[15].Text;
                    //BE.codPeriodo = ddlPeriodos.SelectedValue;
                    //BE.segundoNombre = rowItem.Cells[17].Text;
                    //BE.apellidoMaterno = rowItem.Cells[18].Text;
                    //BE.paisProcedencia = rowItem.Cells[19].Text;
                    //BE.flagValidacion = rowItem.Cells[20].Text;
                    lstBE.Add(BE);
                }
            }
            gvViewRegistros.DataSource = lstBE;
            gvViewRegistros.DataBind();
            if (lstBE.Count > 0)
                IService.IHotelsDuplicateINS(lstBE);
            //ClientScript.RegisterStartupScript(typeof(Page), "showPopupDuplicar", "showPopup('dvDuplicar',793);", true);
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
        #endregion
        #region WebMethod
        //Valida Venta
        [WebMethod]
        public static string ValidaVenta(BEHotel obj)
        {
            IHotels IService = new IHotels();
            return IService.IValUsuarioVentas(obj);

        }
        //Ingresa Nota
        [WebMethod]
        public static string IngresaNota(BENotas obj)
        {
            IHotels IService = new IHotels();
            string fdoc = "";
            if (obj.fechaF.Length > 5)
                fdoc = obj.fechaF.Substring(6, 4) + obj.fechaF.Substring(3, 2) + obj.fechaF.Substring(0, 2);

            string stResp = IService.ISetNotaCredito(obj.SerieNC, obj.CorrNC, obj.SerieF, obj.CorrF, fdoc);

            if (stResp != null)
                if (stResp.Equals("0"))
                    return "No se actualizo ningun registro";
                else
                    if (stResp.Substring(0, 1).Equals("0"))
                        return stResp.Substring(2);
                    else
                        return "Se actualizaron " + stResp + " registro(s).";
            else
                return "0";
        }

        //Insert Update
        [WebMethod]
        public static string InsUpdHotels(BEHotel obj)
        {
            IHotels IService = new IHotels();
            string fdoc = obj.fechaDocumento.Substring(6, 4) + obj.fechaDocumento.Substring(3, 2) + obj.fechaDocumento.Substring(0, 2);
            obj.fechaDocumento = fdoc;

            if (obj.idHospedaje == "0")
            {
                if (obj.ingresoPais.Trim().Length > 8)
                    obj.ingresoPais = obj.ingresoPais.Substring(6, 4) + obj.ingresoPais.Substring(3, 2) + obj.ingresoPais.Substring(0, 2);

                if (obj.fechaIngresoHotel.Trim().Length > 8)
                    obj.fechaIngresoHotel = obj.fechaIngresoHotel.Substring(6, 4) + obj.fechaIngresoHotel.Substring(3, 2) + obj.fechaIngresoHotel.Substring(0, 2);

                if (obj.fechaSalidaHotel.Trim().Length > 8)
                    obj.fechaSalidaHotel = obj.fechaSalidaHotel.Substring(6, 4) + obj.fechaSalidaHotel.Substring(3, 2) + obj.fechaSalidaHotel.Substring(0, 2);
            }

            return obj.idHospedaje == "0" ? IService.IInsHotels(obj) : IService.IUpdHotels(obj);
        }

        //Delete
        [WebMethod]
        public static string DelHotels(BEHotel obj)
        {
            IHotels IService = new IHotels();
            return IService.IDelHotels(obj);
        }

        //Delete
        [WebMethod]
        public static string DelGroupHotels(BEHotel obj)
        {
            IHotels IService = new IHotels();
            BEHotel BEHotel = new BEHotel();
            BEHotel.codLocal = obj.codLocal;
            BEHotel.codPeriodo = obj.codPeriodo;
            BEHotel.correlativo = obj.correlativo;
            return IService.IDelHotelsGroup(BEHotel);
        }

        //Pre-Cierre
        [WebMethod]
        public static string UpdPeriodoLocal(BEPeriodoEmpresa obj)
        {
            IPeriodos IService = new IPeriodos();
            obj.codLocal = obj.codLocal;
            obj.codPeriodoEmpresa = obj.codPeriodoEmpresa;
            return IService.IUpdatePeriodoLocal(obj);
        }
        #endregion

        protected void ddlPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTipoPrm.SelectedValue = "1";
            txtPrmSearch.Text = string.Empty;
            //chkRangeDate.Checked = false;
            ddlTipoFechaPrm.SelectedValue = "0";
            txtDesde.Text = string.Empty;
            txtHasta.Text = string.Empty;
            loadGridHotel();
        }

        protected void ddlLocales_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDropPeriodos();
            ddlTipoPrm.SelectedValue = "1";
            txtPrmSearch.Text = string.Empty;
            //chkRangeDate.Checked = false;
            ddlTipoFechaPrm.SelectedValue = "0";
            txtDesde.Text = string.Empty;
            txtHasta.Text = string.Empty;
            loadGridHotel();
        }

        protected void btnSaveDuplicados_Click(object sender, EventArgs e)
        {
            List<BEHotel> lstBE = new List<BEHotel>();
            List<BEHotel> lstBE2 = new List<BEHotel>();
            BEHotel BE;
            IHotels IService = new IHotels();
            BE = new BEHotel();
            BE.correlativo = gvHotels.SelectedRow.Cells[2].Text;
            BE.idHospedaje = gvHotels.SelectedRow.Cells[0].Text;
            lstBE = IService.IGetporCorrelativo(BE);
            CheckBox chk;
            foreach (GridViewRow rowItem in gvDuplicarRegistros.Rows)
            {
                BE = new BEHotel();
                BE.idHospedaje = rowItem.Cells[1].Text;
                BE.serie = HttpUtility.HtmlDecode(rowItem.Cells[2].Text);
                //BE.correlativo = this.lblNewCorrelativo.Text;//lblNewCorrelativo_Usar_Duplicar.Text;
                BE.correlativo = gvHotels.SelectedRow.Cells[2].Text;
                BE.ruc = HttpUtility.HtmlDecode(rowItem.Cells[4].Text);
                BE.agencia = HttpUtility.HtmlDecode(rowItem.Cells[5].Text);
                BE.pasaporte = HttpUtility.HtmlDecode(rowItem.Cells[6].Text);
                BE.apellidoPaterno = HttpUtility.HtmlDecode(rowItem.Cells[7].Text);
                BE.paisPasaporte = HttpUtility.HtmlDecode(rowItem.Cells[8].Text);
                BE.nombre = HttpUtility.HtmlDecode(rowItem.Cells[9].Text);
                BE.fechaIngresoHotel = rowItem.Cells[10].Text;
                BE.fechaSalidaHotel = rowItem.Cells[11].Text;
                BE.nroFicha = HttpUtility.HtmlDecode(rowItem.Cells[12].Text);
                BE.unidad = HttpUtility.HtmlDecode(rowItem.Cells[13].Text);
                BE.ingresoPais = HttpUtility.HtmlDecode(rowItem.Cells[14].Text);
                BE.fechaDocumento = rowItem.Cells[15].Text;
                BE.codLocal = rowItem.Cells[16].Text;
                BE.codPeriodo = ddlPeriodos.SelectedValue;
                BE.segundoNombre = HttpUtility.HtmlDecode(rowItem.Cells[18].Text);
                BE.apellidoMaterno = HttpUtility.HtmlDecode(rowItem.Cells[19].Text);
                BE.paisProcedencia = HttpUtility.HtmlDecode(rowItem.Cells[20].Text);
                BE.flagValidacion = "1";//rowItem.Cells[21].Text;
                lstBE.Add(BE);
                lstBE2.Add(BE);
            }


            gvViewRegistros.DataSource = lstBE;
            gvViewRegistros.DataBind();
            if (lstBE.Count > 0)
                IService.IHotelsDuplicateINS(lstBE2);

            //lstBE = new List<BEHotel>();
            //gvDuplicarRegistros.DataSource = lstBE;
            //gvDuplicarRegistros.DataBind();

            ClientScript.RegisterStartupScript(typeof(Page), "showPopupDuplicar", "showPopup('dvDuplicar',793);", true);
        }

        protected void gvHotels_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public void Bloqueo_y_Carga()
        {
            IHotels IService = new IHotels();
            BEHotel BEHotel = new BEHotel();
            BEHotel.codLocal = ddlLocales.SelectedValue;

            txtUnidad.Text = IService.IGetUnidad(BEHotel);
            txtUnidad.BackColor = System.Drawing.Color.LightGray;
            txtUnidad.Enabled = false;
        }

        protected void txtSerie_TextChanged1(object sender, EventArgs e)
        {

        }



    }
}