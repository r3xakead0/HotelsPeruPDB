<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="wfrm_IngresarNotas.aspx.cs" Inherits="SummitPDB.WebSite.NotasCredito.wfrm_IngresarNotas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $('#<%=txtfecDoc.ClientID %>').datepicker({
                dateFormat: "dd/mm/yy"
            });
        });
    </script>
    <h2>
        Notas de Credito</h2>
    <br />
    <table class="grid-general">
        <tbody>
            <tr>
                <td>
                    <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="100px" height="1px" />
                </td>
                <td>
                    <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="20px" height="1px" />
                </td>
                <td>
                    <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="80px" height="1px" />
                </td>
                <td>
                    <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="5px" height="1px" />
                </td>
                <td>
                    <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="50px" height="1px" />
                </td>
                <td>
                    <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="80px" height="1px" />
                </td>
                <td>
                    <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="5px" height="1px" />
                </td>
                <td>
                    <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="100px" height="1px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="7">
                    <strong>Datos de Nota de credito</strong>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    Serie:
                </td>
                <td>
                    <asp:TextBox ID="txtNumSerieNC" runat="server" Width="80px" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSerieNC" runat="server" ControlToValidate="txtNumSerieNC"
                        ErrorMessage="Ingrese el número de serie de la nota de credito" ForeColor="Red"
                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="valNC">•</asp:RequiredFieldValidator>
                </td>
                <td>
                    Correlativo:
                </td>
                <td>
                    <asp:TextBox ID="txtNumCorrNC" runat="server" Width="80px" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvCorrNC" runat="server" ControlToValidate="txtNumCorrNC"
                        ErrorMessage="Ingrese el número de Correlativo de la nota de credito" ForeColor="Red"
                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="valNC">•</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="7">
                    <strong>Datos de factura:</strong>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    Serie:
                </td>
                <td>
                    <asp:TextBox ID="txtNumSerieFactura" runat="server" Width="80px" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSerieFact" runat="server" ControlToValidate="txtNumSerieFactura"
                        ErrorMessage="Ingrese el número de serie de la nota de credito de la factura a cambiar"
                        ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="valNC">•</asp:RequiredFieldValidator>
                </td>
                <td>
                    Correlativo:
                </td>
                <td>
                    <asp:TextBox ID="txtNumCorrFactura" runat="server" Width="80px" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvCorrFactura" runat="server" ControlToValidate="txtNumCorrFactura"
                        ErrorMessage="Ingrese el número de Correlativo de la factura a cambiar" ForeColor="Red"
                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="valNC">•</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    Fecha:
                </td>
                <td>
                    <asp:TextBox ID="txtfecDoc" runat="server" Width="80px" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvfec" runat="server" ControlToValidate="txtfecDoc"
                        ErrorMessage="Ingrese La fecha" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"
                        ValidationGroup="valNC">•</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center" colspan="7">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btnmantenimiento"
                        ValidationGroup="valNC" Style="width: 90px;" OnClick="btnAceptar_Click" />
                    &nbsp;<input id="reset" type="reset" value="Limpiar" class="btnmantenimiento" />
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="left" colspan="7">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    <asp:ValidationSummary ID="vlsum" runat="server" ForeColor="Red"
                        ValidationGroup="valNC" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
