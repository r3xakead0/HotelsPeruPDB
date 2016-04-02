using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SummitPDB.ServicesInterface;

public partial class ImportarArchivos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnImpotar_Click(object sender, EventArgs e)
    {
        if (fupHospedaje.HasFile)
        {
            //Store file name in the string variable
            string filename = FileUpload1.FileName;
            //Save file upload file in to server path for temporary
            FileUpload1.SaveAs(Server.MapPath(filename));
            //Export excel data into Gridview using below method
            ExportToGrid(Server.MapPath(filename));
        }   
        IImportarArchivos IService = new IImportarArchivos();
    }
}
