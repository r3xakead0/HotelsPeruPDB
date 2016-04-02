using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitPDB.ServicesInterface;
using SummitPDB.BusinessEntities;

namespace SummitPDB.WebSite.GestionarArchivos
{
    public partial class FileImports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {

            }
        }
        protected void btnImpotar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fupHospedaje.HasFile)
                {
                    BEUser BE = new BEUser();
                    BE = (BEUser)Session["LoginUser"];
                    //Store file name in the string variable
                    string filename = fupHospedaje.FileName;
                    //Save file upload file in to server path for temporary
                    fupHospedaje.SaveAs(Server.MapPath(filename));
                    //Export excel data into Gridview using below method
                    IImportarArchivos IService = new IImportarArchivos();
                    //IService.IHospedajeImportar(Server.MapPath(filename), BE);

                    //if ( filename.Substring(0,1) !="C" || filename.Substring(0,1) !="V" )
                    //{
                    //    lblRespuesta1.Text = "El archivo es incorrecto porfavor validar que se ha seleccionado el archivo correcto.";
                    //}else
                    //{
                    if (IService.IHospedajeImportar(Server.MapPath(filename), BE).Substring(0, 1) == "1")
                        lblRespuesta1.Text = "Archivo hospedaje importado correctamente";
                    else
                        lblRespuesta1.Text = "No se realizó la importación del archivo hospedaje por que ya fué importado u ocurrió algún error.";
                    //}


                }
                if (fupVentas.HasFile)
                {
                    BEUser BE = new BEUser();
                    BE = (BEUser)Session["LoginUser"];
                    //Store file name in the string variable
                    string filename = fupVentas.FileName;
                    //Save file upload file in to server path for temporary
                    fupVentas.SaveAs(Server.MapPath(filename));
                    //Export excel data into Gridview using below method
                    IImportarArchivos IService = new IImportarArchivos();


                    if (filename.Substring(0, 1) == "V" && filename.Substring(1, 11) == "20114803228")
                    {
                        if (IService.IVentasImportar(Server.MapPath(filename), BE).Substring(0, 1) == "1")
                            lblRespuesta1.Text = "Archivo ventas importado correctamente";
                        else
                            lblRespuesta1.Text = "No se realizó la importación del archivo ventas por que ya fué importado u ocurrió algún error.s";
                    }
                    else
                    {
                        lblRespuesta1.Text = "El archivo es incorrecto porfavor validar que se ha seleccionado el archivo correcto.";
                    }
                }
                if (fupCompras.HasFile)
                {
                    BEUser BE = new BEUser();
                    BE = (BEUser)Session["LoginUser"];
                    //Store file name in the string variable
                    string filename = fupCompras.FileName;
                    //Save file upload file in to server path for temporary
                    fupCompras.SaveAs(Server.MapPath(filename));
                    //Export excel data into Gridview using below method
                    IImportarArchivos IService = new IImportarArchivos();

                    if (filename.Substring(0, 1) == "C" && filename.Substring(1, 11) == "20114803228")
                    {
                        if (IService.IComprasImportar(Server.MapPath(filename), BE).Substring(0, 1) == "1")
                            lblRespuesta1.Text = "Archivo compras importado correctamente";
                        else
                            lblRespuesta1.Text = "No se realizó la importación del archivo compras que ya fué importado u ocurrió algún error.";
                    }
                    else
                    {
                        lblRespuesta1.Text = "El archivo es incorrecto porfavor validar que se ha seleccionado el archivo correcto.";
                    }
                }
                if (fupTipCambio.HasFile)
                {
                    BEUser BE = new BEUser();
                    BE = (BEUser)Session["LoginUser"];
                    //Store file name in the string variable
                    string filename = fupTipCambio.FileName;
                    //Save file upload file in to server path for temporary
                    fupTipCambio.SaveAs(Server.MapPath(filename));
                    //Export excel data into Gridview using below method
                    IImportarArchivos IService = new IImportarArchivos();

                    if (IService.ITipo_CambioImportar(Server.MapPath(filename), BE).Substring(0, 1) == "1")
                        lblRespuesta1.Text = "Archivo Tipo de Cambio importado correctamente";
                    else
                        lblRespuesta1.Text = "No se realizó la importación del archivo tipo de cambio por que ya fué importado u ocurrió algún error.";

                }

                Carga_de_Grilla();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        public void Carga_de_Grilla()
        {
            try
            {
                IImportarArchivos IService_Tipo_Cambio = new IImportarArchivos();
                List<BELog_Importar> lstBE = new List<BELog_Importar>();
                lstBE = IService_Tipo_Cambio.IgetLog_Importar();

                if (lstBE.Count == 0)
                {
                    Grid_Detalle.Visible = false;
                    this.Lbl_Errores.Visible = false;
                    Grid_Detalle.DataSource = null;
                    Grid_Detalle.DataBind();
                }
                else
                {
                    Grid_Detalle.Visible = true;
                    Grid_Detalle.DataSource = lstBE;
                    this.Lbl_Errores.Visible = true;
                    Grid_Detalle.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }

        }

    }
}