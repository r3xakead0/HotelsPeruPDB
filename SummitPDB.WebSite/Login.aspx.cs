using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitPDB.BusinessEntities;
using SummitPDB.ServicesInterface;

namespace SummitPDB.WebSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BEUser user = new BEUser();
            user.UserName = txtIdUsuario.Text;
            user.UserPassword = txtClave.Text;
            IUsers iUsers = new IUsers();
            //user = new BEUser();
            user = iUsers.IvalidateLoguinUser(user);
            if (user != null )
            {
 if (user.Respuesta.Substring(0, 1) == "1")
            {
                Session["LoginUser"] = user;
                /*ejecar consulta para obtener el menu*/
                Response.Redirect("~/Default.aspx");
            }
            }
           
                
        }
    }
}