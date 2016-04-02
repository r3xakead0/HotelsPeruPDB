<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileImports.aspx.cs" Inherits="SummitPDB.WebSite.GestionarArchivos.FileImports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style id="cssStyle" type="text/css" media="all">
.CS
{
background-color:#abcdef;
color: Yellow;
border: 1px solid #AB00CC;
font: Verdana 10px;
padding: 1px 4px;
font-family: Palatino Linotype, Arial, Helvetica, sans-serif;

}
    .style1
    {
        width: 396px;
    }
    .style2
    {
        height: 10px;
    }
    .style3
    {
        width: 506px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<h2>Importar Archivos</h2>
    <table border="0" class="tblmantenimiento">
    <tr>
    <th>Hospedaje:</th>
    <td class="style3">
    <asp:FileUpload ID="fupHospedaje" runat="server" style="width: 235px"  />
    <asp:RegularExpressionValidator runat="server" ID="valfupHospedaje" ControlToValidate="fupHospedaje" ValidationGroup="validFileImport" ErrorMessage="Seleccione solo archivos (.doc, .txt, .rtf)" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.doc|.txt|.rtf)$" />
    </td>
    <td class="style1">
        <asp:Label ID="Lbl_Errores" runat="server" 
            Text="Lista de Errores en la importacion" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
    <th>Ventas:</th>
    <td class="style3"><asp:FileUpload ID="fupVentas" runat="server" CssClass="" /></td>
    <td class="style1" rowspan="4">
    <div class="" style="width: 393px; height: 120px; overflow: auto;">
     <asp:GridView ID="Grid_Detalle" CssClass="grid" runat="server" 
            Height="17px" Width="627px" Visible="False" >
       </asp:GridView>
     </div>
    </td>
    </tr>
    <tr>
    <th>Compras:</th>
    <td class="style3"><asp:FileUpload ID="fupCompras" runat="server" /></td>
    </tr>
    <tr>
    <th>Tip.Cambio:</th>
    <td class="style3"><asp:FileUpload ID="fupTipCambio" runat="server" /></td>
    </tr>
    <tr>
    <th colspan="2" class="style2">
        <asp:Button ID="btnImpotar" runat="server" text="Importar" CssClass="btnmantenimiento" ValidationGroup="validFileImport" OnClick="btnImpotar_Click" />
    </th>
    </tr>
    </table>
    <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="validFileImport" Enabled="true" HeaderText="Validacion..." />
    <asp:Label ID="lblRespuesta1" runat="server" Text="" />
    <asp:Label ID="lblRespuesta2" runat="server" Text="" />
    <asp:Label ID="lblRespuesta3" runat="server" Text="" />
    <asp:Label ID="lblRespuesta4" runat="server" Text="" />
    <asp:Label ID="lblError" runat="server" Text="" />
    <%--<asp:FileUpload ID="FileUpload1" runat="server" Style=" top:1px; left:-10px; width: 265px; position: relative; height: 26px; opacity: 0; filter: alpha(opacity=0)" Font-Size="30pt" />--%>
</asp:Content>
