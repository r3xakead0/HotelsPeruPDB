<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarContrasena.aspx.cs" Inherits="SummitPDB.WebSite.Seguridad.CambiarContrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Cambio de Contrase&ntilde;a</h2>
    <table border="0" class="tblmantenimiento">
    <tr>
    <th>Usuario:</th>
    <td><asp:TextBox ID="txtUsuario" runat="server" ReadOnly="true"/></td>
    </tr>
    <tr>
    <th>Password:</th>
    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"/></td>
    </tr>
    <tr>
    <th>Repetir Password:</th>
    <td><asp:TextBox ID="txtRepPassword" runat="server" TextMode="Password"/></td>
    </tr>
    <tr>
    <th colspan="2">
        <%--<asp:Button ID="btnGrabar" runat="server" text="Grabar" CssClass="btnmantenimiento" OnClick="btnGrabar_Click" />--%>
        <input type="button" id="btnGrabar" value="Grabar" class="btnmantenimiento" onclick="UpdateInsertData();" />
        <asp:Button ID="btnCancelar" runat="server" text="Cancelar" CssClass="btnmantenimiento" OnClick="btnCancelar_Click" />
    </th>
    </tr>
    </table>
    <script type="text/javascript">
        function UpdateInsertData() {
            $.ajax({
                url: '../Seguridad/CambiarContrasena.aspx/UpdPassword',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "objBE":
                    {
                        "UserName": $('#<%=txtUsuario.ClientID %>').val(),
                        "UserPassword": $('#<%=txtPassword.ClientID %>').val(),
                        "UserPasswordRep": $('#<%=txtRepPassword.ClientID %>').val()
                    }
                }),
                success: function (data) {
                    if (data.d == "1") {
                        alert('Se cambio el password correctamente')
                    } else
                        alert('No e cambio el password');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        $(document).ready(function () {
            $("#btnSaveRegister").click(function () {
                UpdateInsertData();
                $(this).closest('.ui-dialog-content').dialog('close');
            });
        });    
    </script>
</asp:Content>
