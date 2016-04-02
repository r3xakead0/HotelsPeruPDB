<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SummitPDB.WebSite.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="height: 200px">
    </div>
    <div align="center">
        <asp:Panel ID="Seguridad" runat="server">
            <h2 style="color:White;">Bienvenido al Sistema de Gestion de PDB</h2>
            <table style="color:White;">
                <tr>
                    <td style="text-align: right; width: 70px">
                    Usuario:
                    </td>
                    <td style="text-align: left; width: 150px;">
                        <asp:TextBox ID="txtIdUsuario" runat="server" Width="200px" TabIndex="15" Style="border: 1px solid #3366CC;
                            height: 20px;" Text="" />
                        <asp:RequiredFieldValidator ID="rfvClave" runat="server" Display="None" ControlToValidate="txtClave"
                            ErrorMessage="Ingrese contraseña"></asp:RequiredFieldValidator>
                        <%--<cc1:ValidatorCalloutExtender ID="rfvClave_ValidatorCalloutExtender" 
                        runat="server" Enabled="True" TargetControlID="rfvClave">
                        </cc1:ValidatorCalloutExtender>--%>
                    </td>
                </tr>
                <tr>
                    <td style="height: 2px">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                    Contraseña:
                    </td>
                    <td style="text-align: left; width: 150px;">
                        <asp:TextBox ID="txtClave" runat="server" Width="200px" TabIndex="16" TextMode="Password"
                            Style="border: 1px solid #3366CC; height: 20px" Text="hollamundillo" />
                        <asp:RequiredFieldValidator ID="rfvIdUsuario" runat="server" ControlToValidate="txtIdUsuario"
                            ErrorMessage="Ingrese usuario" Display="None"></asp:RequiredFieldValidator>
                        <%--<cc1:ValidatorCalloutExtender ID="rfvIdUsuario_ValidatorCalloutExtender" 
                        runat="server" Enabled="True" TargetControlID="rfvIdUsuario">
                        </cc1:ValidatorCalloutExtender>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnLogin" runat="server" text="Aceptar" 
                            CssClass="btnmantenimiento" onclick="btnLogin_Click" />
                        <%--<a href="Default.aspx"><input type="button" id="btnLogin" value="Aceptar" class="btnmantenimiento" /></a>--%>
                        <asp:Button ID="btnCancelar" runat="server" text="Cancelar" CssClass="btnmantenimiento" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
