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
    public partial class CambiarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx"); 
            if (!IsPostBack)
            {
                BEUser BE = new BEUser();
                BE = (BEUser)Session["LoginUser"];
                txtUsuario.Text = BE.UserNameAccount;
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            BEUser BE = new BEUser();
            BE.UserName = txtUsuario.Text.Trim();
            BE.UserPassword = txtPassword.Text.Trim();
            IUsers IService = new IUsers();
            IService.IUpdPassword(BE);
            ClientScript.RegisterStartupScript(typeof(Page), "succed", "alert('Se cambio el password correctamente');", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        [WebMethod]
        public static string UpdPassword(BEUser objBE)
        {
            BEUser BE = new BEUser();
            BE.UserName = objBE.UserName.Trim();
            BE.UserPassword = objBE.UserPassword.Trim();
            BE.UserPasswordRep = objBE.UserPasswordRep.Trim();
            IUsers IService = new IUsers();
            return IService.IUpdPassword(objBE);
        }
    }
}