<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ImportarArchivos.aspx.cs" Inherits="SummitPDB.WebSite.GestionarReglas.ImportarArchivos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Importar Archivos</h2>
    <table border="0" class="tblmantenimiento">
    <tr>
    <th>Hospedaje:</th>
    <td>
    <asp:FileUpload ID="fupHospedaje" runat="server"  />
    <asp:RegularExpressionValidator runat="server" ID="valfupHospedaje" ControlToValidate="fupHospedaje" ValidationGroup="validFileImport" ErrorMessage="Seleccione solo archivos (.doc, .txt, .rtf)" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.doc|.txt|.rtf)$" />
    </td>
    </tr>
    <tr>
    <th>Ventas:</th>
    <td><asp:FileUpload ID="fupVentas" runat="server" /></td>
    </tr>
    <tr>
    <th>Compras:</th>
    <td><asp:FileUpload ID="fupCompras" runat="server" /></td>
    </tr>
    <tr>
    <th>Tip.Cambio:</th>
    <td><asp:FileUpload ID="fupTipCambio" runat="server" /></td>
    </tr>
    <tr>
    <th colspan="2">
        <asp:Button ID="btnImpotar" runat="server" text="Importar" CssClass="btnmantenimiento" ValidationGroup="validFileImport" OnClick="btnImpotar_Click" />
    </th>
    </tr>
    </table>
    <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="validFileImport" Enabled="true" HeaderText="Validacion..." />
</asp:Content>
