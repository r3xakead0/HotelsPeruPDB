<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FileExportar.aspx.cs" Inherits="SummitPDB.WebSite.GestionarArchivos.FileExportar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Exportar Archivos</h2>
    <table border="0" class="tblmantenimiento">
        
        <tr>
            <th>
                Periodo: &nbsp;
            </th>
            <td>
                <asp:DropDownList ID="ddlPeriodos" runat="server" AutoPostBack="true" 
                    Width="160px" />
            </td>
        </tr>
        <tr>
            <th>
                Hospedaje:
            </th>
            <td>
                <asp:Button ID="Btn_Ixportar_Huspedes" runat="server" CssClass="btnmantenimiento"
                    Text="Exportar" OnClick="Btn_Ixportar_Huspedes_Click" Width="90px" />
                <asp:Label ID="Lbl_export" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Ventas:
            </th>
            <td>
                <asp:Button ID="Btn_Ventas" runat="server" CssClass="btnmantenimiento" Text="Exportar"
                    Width="90px" OnClick="Btn_Ventas_Click" />
                <asp:Label ID="Lbl_Ventas" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Compras:
            </th>
            <td>
                <asp:Button ID="Btn_Compras" runat="server" CssClass="btnmantenimiento" Text="Exportar"
                    Width="90px" OnClick="Btn_Compras_Click" />
                <asp:Label ID="Lbl_Compras" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Tip.Cambio:
            </th>
            <td>
                <asp:Button ID="Btn_Tipo_Cambio" runat="server" CssClass="btnmantenimiento" Text="Exportar"
                    Width="90px" OnClick="Btn_Tipo_Cambio_Click" />
                <asp:Label ID="Lbl_Tip_Cambio" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <th colspan="2">
                &nbsp;
            </th>
        </tr>
    </table>
    <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="validFileImport" Enabled="true" HeaderText="Validacion..." />
    <asp:Label ID="lblRespuesta1" runat="server" Text="" />
    <asp:Label ID="lblRespuesta2" runat="server" Text="" />
    <asp:Label ID="lblRespuesta3" runat="server" Text="" />
    <asp:Label ID="lblRespuesta4" runat="server" Text="" />
    <asp:Label ID="lblError" runat="server" Text="" />
</asp:Content>
