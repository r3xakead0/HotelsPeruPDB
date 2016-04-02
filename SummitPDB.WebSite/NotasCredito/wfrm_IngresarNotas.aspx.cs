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

namespace SummitPDB.WebSite.NotasCredito
{
    public partial class wfrm_IngresarNotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                Validacion_Casillas();
            }
        }
        public void Validacion_Casillas()
        {
            txtNumCorrFactura.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumCorrNC.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumSerieFactura.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtNumSerieNC.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            IHotels IService = new IHotels();
            string fdoc = "";
            if (txtfecDoc.Text.Length > 5)
                fdoc = txtfecDoc.Text.Substring(6, 4) + txtfecDoc.Text.Substring(3, 2) + txtfecDoc.Text.Substring(0, 2);

            lblMsg.Text = "Se actualizaron " + IService.ISetNotaCredito(txtNumSerieNC.Text, txtNumCorrNC.Text, txtNumSerieFactura.Text, txtNumCorrFactura.Text, fdoc)
                          + " registro(s).";

            txtNumSerieNC.Text = string.Empty;
            txtNumCorrNC.Text = string.Empty;
            txtNumSerieFactura.Text = string.Empty;
            txtNumCorrFactura.Text = string.Empty;
            txtfecDoc.Text = string.Empty;
        }
    }
}