<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SummitPDB.WebSite.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bienvenido al Sistema de Gestion de PDB</title>
    <link rel="stylesheet" type="text/css" href="Styles/login/reset.css">
    <link rel="stylesheet" type="text/css" href="Styles/login/structure.css">
</head>
<body>

    <form class="box login" id="form1" runat="server">
	    <fieldset class="boxBody">
	        <label>Usuario</label>
            <asp:TextBox ID="txtIdUsuario" runat="server" TabIndex="1" />
            <asp:RequiredFieldValidator ID="rfvIdUsuario" runat="server" ControlToValidate="txtIdUsuario"
                            ErrorMessage="Ingrese usuario" Display="None"></asp:RequiredFieldValidator>
	        <label><a href="#" class="rLink" tabindex="5">¿Olvido su contraseña?</a>Contraseña</label>
            <asp:TextBox ID="txtClave" runat="server" TabIndex="2" TextMode="Password" />
            <asp:RequiredFieldValidator ID="rfvClave" runat="server" Display="None" ControlToValidate="txtClave"
                            ErrorMessage="Ingrese contraseña"></asp:RequiredFieldValidator>
	    </fieldset>
	    <footer>
	        <label><input type="checkbox" tabindex="3">Mantenerse conectado</label>
	        <asp:Button ID="btnLogin" class="btnLogin" runat="server" TabIndex="4" text="Ingresar" onclick="btnLogin_Click" />
	    </footer>
    </form>

</body>
</html>
