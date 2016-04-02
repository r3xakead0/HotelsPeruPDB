using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitPDB.ServicesInterface;
using SummitPDB.BusinessEntities;
using System.IO;
using System.Web;

namespace SummitPDB.WebSite.GestionarArchivos
{
    public partial class FileExportar : System.Web.UI.Page
    {
        private String cCodLocal
        {
            get { return (String)ViewState["cCodLocal"]; }
            set { ViewState.Add("cCodLocal", value); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("~/Login.aspx");
            if (!IsPostBack)
            {
                loadDropPeriodos();
                Lbl_export.Visible = false;
                Lbl_Compras.Visible = false;
                Lbl_Ventas.Visible = false;
                Lbl_Tip_Cambio.Visible = false;
            }
        }
        protected void btnImpotar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (fupHospedaje.HasFile)
                //{
                //    BEUser BE = new BEUser();
                //    BE = (BEUser)Session["LoginUser"];
                //    //Store file name in the string variable
                //    string filename = fupHospedaje.FileName;
                //    //Save file upload file in to server path for temporary
                //    fupHospedaje.SaveAs(Server.MapPath(filename));
                //    //Export excel data into Gridview using below method
                //    IImportarArchivos IService = new IImportarArchivos();
                //    //IService.IHospedajeImportar(Server.MapPath(filename), BE);
                //    if (IService.IHospedajeImportar(Server.MapPath(filename), BE).Substring(0, 1) == "1")
                //        lblRespuesta1.Text = "Archivo hospedaje importado correctamente";
                //    else
                //        lblRespuesta1.Text = "No se realiso la importacion del archivo hospedaje";
                //}
                //if (fupVentas.HasFile)
                //{
                //    BEUser BE = new BEUser();
                //    BE = (BEUser)Session["LoginUser"];
                //    //Store file name in the string variable
                //    string filename = fupVentas.FileName;
                //    //Save file upload file in to server path for temporary
                //    fupVentas.SaveAs(Server.MapPath(filename));
                //    //Export excel data into Gridview using below method
                //    IImportarArchivos IService = new IImportarArchivos();
                //    if (IService.IVentasImportar(Server.MapPath(filename), BE).Substring(0, 1) == "1")
                //        lblRespuesta1.Text = "Archivo ventas importado correctamente";
                //    else
                //        lblRespuesta1.Text = "No se realiso la importacion del archivo ventas";
                //}
                //if (fupCompras.HasFile)
                //{
                //    BEUser BE = new BEUser();
                //    BE = (BEUser)Session["LoginUser"];
                //    //Store file name in the string variable
                //    string filename = fupCompras.FileName;
                //    //Save file upload file in to server path for temporary
                //    fupCompras.SaveAs(Server.MapPath(filename));
                //    //Export excel data into Gridview using below method
                //    IImportarArchivos IService = new IImportarArchivos();
                //    if (IService.IComprasImportar(Server.MapPath(filename), BE).Substring(0, 1) == "1")
                //        lblRespuesta1.Text = "Archivo compras importado correctamente";
                //    else
                //        lblRespuesta1.Text = "No se realiso la importacion del archivo compras";
                //}
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        public string[] DevolverAnioMes(string cadena)
        {
            char[] separador = { '-' };
            string[] fecha = cadena.Split(separador);
            switch (fecha[0])
            {
                case "Enero":
                    fecha[0] = "01";
                    break;

                case "Febrero":
                    fecha[0] = "02";
                    break;

                case "Marzo":
                    fecha[0] = "03";
                    break;

                case "Abril":
                    fecha[0] = "04";
                    break;

                case "Mayo":
                    fecha[0] = "05";
                    break;

                case "Junio":
                    fecha[0] = "06";
                    break;

                case "Julio":
                    fecha[0] = "07";
                    break;

                case "Agosto":
                    fecha[0] = "08";
                    break;

                case "Septiembre":
                    fecha[0] = "09";
                    break;

                case "Octubre":
                    fecha[0] = "10";
                    break;

                case "Noviembre":
                    fecha[0] = "11";
                    break;

                case "Diciembre":
                    fecha[0] = "12";
                    break;
            }
            return fecha;
        }
        public string devolverFecha(string cadena)
        {
            char[] separador = { '-' };
            string cadenaResultante = string.Empty;
            string[] fecha = cadena.Split(separador);
            switch (fecha[0])
            {
                case "Enero":
                    cadenaResultante = "01";
                    break;

                case "Febrero":
                    cadenaResultante = "02";
                    break;

                case "Marzo":
                    cadenaResultante = "03";
                    break;

                case "Abril":
                    cadenaResultante = "04";
                    break;

                case "Mayo":
                    cadenaResultante = "05";
                    break;

                case "Junio":
                    cadenaResultante = "06";
                    break;

                case "Julio":
                    cadenaResultante = "07";
                    break;

                case "Agosto":
                    cadenaResultante = "08";
                    break;

                case "Septiembre":
                    cadenaResultante = "09";
                    break;

                case "Octubre":
                    cadenaResultante = "10";
                    break;

                case "Noviembre":
                    cadenaResultante = "11";
                    break;

                case "Diciembre":
                    cadenaResultante = "12";
                    break;
            }
            cadenaResultante = fecha[1] + cadenaResultante;
            return cadenaResultante;
        }

        protected void Btn_Ixportar_Huspedes_Click(object sender, EventArgs e)
        {
            try
            {
                ILocal IService2 = new ILocal();
                BELocal BE = new BELocal();
                BEUser beh = new BEUser();
                List<BELocal> lstLocal = new List<BELocal>();
                beh = (BEUser)Session["LoginUser"];
                BE.codLocal = beh.codLocal;

                BEPeriodoEmpresa_Mant beExport = new BEPeriodoEmpresa_Mant();

                string[] fecha = DevolverAnioMes(this.ddlPeriodos.SelectedItem.Text);
                if (beh.codRol != "3")
                {
                    beExport.codLocal = beh.codLocal;
                    lstLocal = IService2.IGetLocal(BE);
                }
                else
                {
                    beExport.mes = fecha[0];
                    beExport.anioProces = fecha[1];
                }
                string nomlocal = string.Empty;
                foreach (BELocal localUser in lstLocal)
                {
                    nomlocal = localUser.nomLocal;
                }

                IExportar IService = new IExportar();


                beExport.codPeriodo = this.ddlPeriodos.SelectedValue;

                //beExport.x = this.ddlPeriodos.SelectedItem.Text;
                //beExport.nombre = nomlocal;
                beExport.Ruta = "C:/H" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt";

                File.Delete("C:/H" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt");


                Lbl_export.Text = IService.IExporHotel(beExport);
                Lbl_export.Visible = true;


                String FileName = "H" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".hos";
                String FilePath = "C:/H" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt"; //Replace this
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                response.TransmitFile(FilePath);
                response.Flush();
                response.End();


                string path = "C:/H" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt"; //get physical file path from server
                string name = Path.GetFileName(path); //get file name
                string ext = Path.GetExtension(path); //get file extension
                string type = "";

                // set known types based on file extension  
                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".htm":
                        case ".html":
                            type = "text/HTML";
                            break;

                        case ".txt":
                            type = "text/plain";
                            break;

                        case ".GIF":
                            type = "image/GIF";
                            break;

                        case ".pdf":
                            type = "Application/pdf";
                            break;

                        case ".doc":
                        case ".rtf":
                            type = "Application/msword";
                            break;

                        Default:
                            type = "";
                            break;
                    }
                }

                Response.AppendHeader("content-disposition", "attachment; filename=" + name);

                if (type != "")
                    Response.ContentType = type;
                Response.WriteFile(path);
                Response.End(); //give POP to user for file downlaod
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void Btn_Ventas_Click(object sender, EventArgs e)
        {

            try
            {
                ILocal IService2 = new ILocal();
                BELocal BE = new BELocal();
                BEUser beh = new BEUser();
                List<BELocal> lstLocal = new List<BELocal>();
                beh = (BEUser)Session["LoginUser"];
                BE.codLocal = beh.codLocal;

                BEPeriodoEmpresa_Mant beExport = new BEPeriodoEmpresa_Mant();

                string[] fecha = DevolverAnioMes(this.ddlPeriodos.SelectedItem.Text);
                if (beh.codRol != "3")
                {
                    beExport.codLocal = beh.codLocal;
                    lstLocal = IService2.IGetLocal(BE);
                }
                else
                {
                    beExport.mes = fecha[0];
                    beExport.anioProces = fecha[1];
                }

                string nomlocal = string.Empty;
                foreach (BELocal localUser in lstLocal)
                {
                    nomlocal = localUser.nomLocal;
                }

                IExportar IService = new IExportar();

                beExport.codPeriodo = this.ddlPeriodos.SelectedValue;
                
                //beExport.x = this.ddlPeriodos.SelectedItem.Text;
                //beExport.nombre = nomlocal;
                beExport.Ruta = "C:/V" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt";


                File.Delete("C:/V" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt");

                this.Lbl_Ventas.Text = IService.IExporVenta(beExport);
                Lbl_Ventas.Visible = true;



                String FileName = "V" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt";
                String FilePath = "C:/V" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt"; //Replace this
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                response.TransmitFile(FilePath);
                response.Flush();
                response.End();


                string path = "C:/V" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt"; //get physical file path from server
                string name = Path.GetFileName(path); //get file name
                string ext = Path.GetExtension(path); //get file extension
                string type = "";

                // set known types based on file extension  
                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".htm":
                        case ".html":
                            type = "text/HTML";
                            break;

                        case ".txt":
                            type = "text/plain";
                            break;

                        case ".GIF":
                            type = "image/GIF";
                            break;

                        case ".pdf":
                            type = "Application/pdf";
                            break;

                        case ".doc":
                        case ".rtf":
                            type = "Application/msword";
                            break;

                        Default:
                            type = "";
                            break;
                    }
                }

                Response.AppendHeader("content-disposition", "attachment; filename=" + name);

                if (type != "")
                    Response.ContentType = type;
                Response.WriteFile(path);
                Response.End(); //give POP to user for file downlaod
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void Btn_Compras_Click(object sender, EventArgs e)
        {

            try
            {
                ILocal IService2 = new ILocal();
                BELocal BE = new BELocal();
                BEUser beh = new BEUser();
                List<BELocal> lstLocal = new List<BELocal>();
                beh = (BEUser)Session["LoginUser"];
                BE.codLocal = beh.codLocal;

                BEPeriodoEmpresa_Mant beExport = new BEPeriodoEmpresa_Mant();
                string[] fecha = DevolverAnioMes(this.ddlPeriodos.SelectedItem.Text);
                if (beh.codRol != "3")
                {
                    beExport.codLocal = beh.codLocal;
                    lstLocal = IService2.IGetLocal(BE);
                }
                else
                {
                    beExport.mes = fecha[0];
                    beExport.anioProces = fecha[1];
                }

                string nomlocal = string.Empty;
                foreach (BELocal localUser in lstLocal)
                {
                    nomlocal = localUser.nomLocal;
                }

                IExportar IService = new IExportar();

                beExport.codPeriodo = this.ddlPeriodos.SelectedValue;
                //beExport.x = this.ddlPeriodos.SelectedItem.Text;
                //beExport.nombre = nomlocal;
                beExport.Ruta = "C:/C" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt";

                File.Delete("C:/C" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt");

                this.Lbl_Compras.Text = IService.IExporCompra(beExport);
                Lbl_Compras.Visible = true;

                String FileName = "C" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt";
                String FilePath = "C:/C" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt"; //Replace this
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                response.TransmitFile(FilePath);

                response.Flush();
                response.End();


                string path = "C:/C" + "20114803228" + devolverFecha(this.ddlPeriodos.SelectedItem.Text) + ".txt"; //get physical file path from server
                string name = Path.GetFileName(path); //get file name
                string ext = Path.GetExtension(path); //get file extension
                string type = "";

                // set known types based on file extension  
                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".htm":
                        case ".html":
                            type = "text/HTML";
                            break;

                        case ".txt":
                            type = "text/plain";
                            break;

                        case ".GIF":
                            type = "image/GIF";
                            break;

                        case ".pdf":
                            type = "Application/pdf";
                            break;

                        case ".doc":
                        case ".rtf":
                            type = "Application/msword";
                            break;

                        Default:
                            type = "";
                            break;
                    }
                }

                Response.AppendHeader("content-disposition", "attachment; filename=" + name);

                if (type != "")
                    Response.ContentType = type;
                Response.WriteFile(path);
                Response.End(); //give POP to user for file downlaod
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void Btn_Tipo_Cambio_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete("C:/20114803228.tc");

                IExportar IService = new IExportar();
                this.Lbl_Tip_Cambio.Text = IService.ITipo_Cambio(int.Parse(this.ddlPeriodos.SelectedValue));
                Lbl_Tip_Cambio.Visible = true;


                String FileName = "20114803228.tc";
                String FilePath = "C:/20114803228.tc"; //Replace this
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                response.TransmitFile(FilePath);
                response.Flush();
                response.End();


                string path = "C:/20114803228.tc"; //get physical file path from server
                string name = Path.GetFileName(path); //get file name
                string ext = Path.GetExtension(path); //get file extension
                string type = "";

                // set known types based on file extension  
                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".htm":
                        case ".html":
                            type = "text/HTML";
                            break;

                        case ".tc":
                            type = "text/plain";
                            break;

                        case ".txt":
                            type = "text/plain";
                            break;

                        case ".GIF":
                            type = "image/GIF";
                            break;

                        case ".pdf":
                            type = "Application/pdf";
                            break;

                        case ".doc":
                        case ".rtf":
                            type = "Application/msword";
                            break;

                        Default:
                            type = "";
                            break;
                    }
                }

                Response.AppendHeader("content-disposition", "attachment; filename=" + name);

                if (type != "")
                    Response.ContentType = type;
                Response.WriteFile(path);
                Response.End(); //give POP to user for file downlaod
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void loadDropPeriodos()
        {
            IPeriodos IService = new IPeriodos();
            //Dim obj As UserStore = DirectCast(Session.Item("SessionUser"), UserStore)
            BEUser BE = new BEUser();
            BE = (BEUser)Session["LoginUser"];
            if (BE.codRol != "3")
            {
                List<BEPeriodoEmpresa> lstPeriodoEmpresa = new List<BEPeriodoEmpresa>();
                lstPeriodoEmpresa = IService.IGetPeriodos(BE);
                if (lstPeriodoEmpresa.Count > 0)
                {

                    ddlPeriodos.DataSource = lstPeriodoEmpresa;
                    ddlPeriodos.DataValueField = "codPeriodoEmpresa";
                    ddlPeriodos.DataTextField = "descPeriodo";
                    ddlPeriodos.DataBind();
                }
            }
            else
            {
                BEPeriodo_Mant objPeriodo = new BEPeriodo_Mant();
                objPeriodo.codEstado = "1";
                List<BEPeriodo_Mant> lstPeriodoEmpresa = new List<BEPeriodo_Mant>();
                lstPeriodoEmpresa = IService.IGetPeriodos(objPeriodo);
                objPeriodo.codEstado = "2";
                lstPeriodoEmpresa.AddRange(IService.IGetPeriodos(objPeriodo));

                if (lstPeriodoEmpresa.Count > 0)
                {
                    ddlPeriodos.DataSource = lstPeriodoEmpresa;
                    ddlPeriodos.DataValueField = "codPeriodo";
                    ddlPeriodos.DataTextField = "descPeriodo";
                    ddlPeriodos.DataBind();
                }
            }
        }


    }
}