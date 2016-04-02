<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="HostingProcess.aspx.cs" Inherits="SummitPDB.WebSite.PDB.HostingProcess"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Procesar Hospedaje</h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <table class="tblmantenimiento" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    Periodos:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPeriodos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodos_SelectedIndexChanged"
                                        Width="160px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Hotel:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLocales" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocales_SelectedIndexChanged"
                                        Width="160px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="10px" />
                    <td>
                        <div class="BordeRedondo">
                            <table class="tblmantenimiento" border="0" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoPrm" runat="server">
                                            <asp:ListItem Text="Nombre" Value="1" />
                                            <asp:ListItem Text="Apellido" Value="2" />
                                            <asp:ListItem Text="Ficha" Value="3" />
                                            <asp:ListItem Text="Serie" Value="4" />
                                            <asp:ListItem Text="Correlativo" Value="5" />
                                            <asp:ListItem Text="Linea" Value="6" />
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtPrmSearch" runat="server" Width="420px" />
                                    </td>
                                    <td>
                                        <asp:Button ClientIDMode="Static" ID="btnSearch" runat="server" Text="Buscar" CssClass="btnmantenimiento"
                                            OnClientClick="return IsReadySearch();" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        Tipo de Fecha
                                        <asp:DropDownList ID="ddlTipoFechaPrm" runat="server">
                                            <asp:ListItem Value="0" Text="-------" />
                                            <asp:ListItem Value="1" Text="Fec. Documento" />
                                            <asp:ListItem Value="2" Text="Fec. Ing. Pais" />
                                            <asp:ListItem Value="3" Text="Fec. Ing. Hotel" />
                                            <asp:ListItem Value="4" Text="Fec. Salida Hotel" />
                                        </asp:DropDownList>
                                        <%--</td>
                            <td>--%>
                                        Desde:<asp:TextBox ID="txtDesde" runat="server" Width="70px" />
                                        <%--</td>
                            <td>--%>
                                        Hasta:<asp:TextBox ID="txtHasta" runat="server" Width="70px" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table border="0">
        <tr>
            <td rowspan="8" valign="top">
                <div class="" style="width: 820px; height: 320px; overflow: auto;">
                    <asp:UpdatePanel ID="upRegistro" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvHotels" runat="server" CssClass="grid" AutoGenerateColumns="False"
                                OnRowDataBound="gvHotels_RowDataBound" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvHotels_PageIndexChanging"
                                AllowPaging="True" Width="2800px">
                                <Columns>
                                    <asp:BoundField HeaderText="Linea" DataField="idHospedaje">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Serie" DataField="serie">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Correlativo" DataField="correlativo">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ruc" DataField="ruc">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Agencia" DataField="agencia">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pasaporte" DataField="pasaporte">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nombre" DataField="nombre">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Segundo Nombre" DataField="segundoNombre">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Apellido Paterno" DataField="apellidoPaterno">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Apellido Materno" DataField="apellidoMaterno">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pais de Pasaporte" DataField="descPais_Pasap">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Fec. Ingreso Hotel" DataField="fechaIngresoHotel">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Fec. Salida  Hotel" DataField="fechaSalidaHotel">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nro. Ficha" DataField="nroFicha">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Unidad" DataField="unidad">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Fec. Ing. Pais" DataField="ingresoPais">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Fec. Documento" DataField="fechaDocumento">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cod. Local" DataField="codLocal" Visible="True">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cod. Periodo" DataField="codPeriodo" Visible="True">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pais Procedencia" DataField="descPais_Proc">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="84" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Valid" DataField="flagValidacion">
                                        <HeaderStyle Width="20px" CssClass="Hide" />
                                        <ItemStyle Width="20px" CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Residencia" DataField="nDiasResidencia">
                                        <HeaderStyle Width="20px" CssClass="" HorizontalAlign="Right" />
                                        <ItemStyle Width="20px" CssClass="" HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pais de Pasaporte" DataField="paisPasaporte">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="hide" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pais Procedencia" DataField="paisProcedencia">
                                        <HeaderStyle HorizontalAlign="Left"  CssClass="hide" />
                                        <ItemStyle HorizontalAlign="Left" Width="84" CssClass="hide"  />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="altrowstyle" />
                                <SelectedRowStyle CssClass="SelectedRow" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="ddlPeriodos" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlLocales" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td height="25px">
            </td>
        </tr>
        <tr>
            <td>
                <input type="button" id="btnMore" value="Agregar" class="btnmantenimiento" style="width: 90px;" />
            </td>
        </tr>
        <tr>
            <td>
                <input type="button" id="btnEdit" value="Editar" class="btnmantenimiento" style="width: 90px;" />
            </td>
        </tr>
        <tr>
            <td>
                <input type="button" id="btnMinus" value="Eliminar" class="btnmantenimiento" style="width: 90px;" />
            </td>
        </tr>
        <tr>
            <td>
                <input type="button" id="btnNota" value="Nota de credito" class="btnmantenimiento"
                    style="width: 100px;" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Button ClientIDMode="Static" ID="btnValid" runat="server" Text="Validar" CssClass="btnmantenimiento"
                    OnClick="btnValid_Click" Width="90px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ClientIDMode="Static" ID="btnApplyRules" runat="server" Text="Aplicar Reglas"
                    CssClass="btnmantenimiento" OnClick="btnApplyRules_Click" Width="90px" />
            </td>
        </tr>
        <tr>
            <td>
                <input type="button" id="btnDeleteGroup" value="Eliminar Grupo" class="btnmantenimiento"
                    style="width: 90px;" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <%--<input type="button" id="btnDuplicaGrupo" value="Duplica Grupo" class="btnmantenimiento"
                    style="width: 90px;" onclick="btnDuplicar_Click" />--%>
                <asp:Button ClientIDMode="Static" ID="btnDuplicaGrupo" runat="server" Text="Duplica"
                    CssClass="btnmantenimiento" Width="90px" OnClientClick="return frValidSelect();"
                    OnClick="btnDuplicar_Click" />
                <br />
                <asp:Button ClientIDMode="Static" ID="btnDocDistintos" runat="server" Text="Doc. Distintos"
                    CssClass="btnmantenimiento" Width="90px" OnClick="btnDocDistintos_Click" Style="margin-top: 4px;" />
            </td>
        </tr>
    </table>
    <div style="width: 820px; text-align: right;">
        <asp:UpdatePanel ID="updTotales" runat="server">
            <ContentTemplate>
                Base Imponible:<asp:TextBox ID="txtBaseImponible" runat="server" Width="100px" ReadOnly="True" /><br />
                Cant. Doc:<asp:TextBox ID="txtCantDoc" runat="server" Width="100px" ReadOnly="True" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--Lista Errores--%>
    <div id="dvListaErros" style="display: none;" title="Listado de errores">
        <asp:ListBox ID="lstErrorList" runat="server" Height="250px" Width="860px" Style="margin-top: -5px;" />
    </div>
    <%--Mantenimiento--%>
    <div id="popRegistro" class="bodyPopup" title="Registro" style="display: none;">
        <table class="tblmantenimiento">
            <tr>
                <th>
                    <label for="chkRegValido">
                        Validado:</label>
                    <input type="checkbox" id="chkRegValido" name="chkRegValido" />
                </th>
                <td>
                </td>
                <td width="10px" />
                <th>
                    Fecha Documento:
                </th>
                <td>
                    <asp:TextBox ID="txtFecDocumento" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                </td>
                <td />
                <th>
                </th>
                <td>
                </td>
            </tr>
            <tr>
                <th>
                    Serie:
                </th>
                <td>
                    <asp:TextBox ID="txtSerie" runat="server" CssClass="" OnTextChanged="txtSerie_TextChanged1" />
                </td>
                <td />
                <th>
                    Correlativo:
                </th>
                <td>
                    <asp:TextBox ID="txtCorrelativo" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Agencia:
                </th>
                <td>
                    <asp:TextBox ID="txtAgencia" runat="server" CssClass="" />
                </td>
                <td />
                <th>
                    RUC:
                </th>
                <td>
                    <asp:TextBox ID="txtRuc" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Pasaporte:
                </th>
                <td>
                    <asp:TextBox ID="txtPasaporte" runat="server" CssClass="" />
                </td>
                <td />
                <th>
                    Pais Pasaporte:
                </th>
                <td>
                    <asp:DropDownList ID="ddlPaisPasaporte" runat="server" Width="110px" />
                </td>
            </tr>
            <tr>
                <th>
                    Apellido Paterno:
                </th>
                <td>
                    <asp:TextBox ID="txtApePaterno" runat="server" CssClass="" />
                </td>
                <td />
                <th>
                    Ape. Materno:
                </th>
                <td>
                    <asp:TextBox ID="txtApeMaterno" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Nombre:
                </th>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="" />
                </td>
                <td />
                <th>
                    Segundo Nombre:
                </th>
                <td>
                    <asp:TextBox ID="txtNombre2" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Nro. Ficha:
                </th>
                <td>
                    <asp:TextBox ID="txtNroFicha" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Pais Procedencia:
                </th>
                <td>
                    <asp:DropDownList ID="ddlPaisProcedencia" runat="server" Width="110px" />
                </td>
            </tr>
            <tr>
                <th>
                    Unidad:
                </th>
                <td>
                    <asp:TextBox ID="txtUnidad" runat="server" CssClass="" />
                </td>
                <td />
                <th>
                    Fecha Ingreso Hotel:
                </th>
                <td>
                    <asp:TextBox ID="txtFecIngHotel" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Ingreso al Pais:
                </th>
                <td>
                    <asp:TextBox ID="txtIngPais" runat="server" CssClass="validation" xmsg_regular="Ingrese fecha válida"
                        regular="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$" />
                </td>
                <td />
                <th>
                    Fecha Salida Hotel:
                </th>
                <td>
                    <asp:TextBox ID="txtFecSalidaHotel" runat="server" CssClass="" />
                </td>
            </tr>
        </table>
        <center>
            <input type="button" id="btnSaveRegister" value="Guardar" class="btnmantenimiento"
                style="font-family: Arial; font-size: 11px;" />
            <input type="button" id="btnCancelRegister" value="Cancelar" class="btnmantenimiento"
                style="font-family: Arial; font-size: 11px;" />
        </center>
        <input type="hidden" id="hdIdHospedaje" value="0" />
    </div>
    <%--NotaCredito--%>
    <div id="popNota" class="bodyPopup" title="Notas de Credito" style="display: none;">
        <%-- >--%>
        <table class="grid-general">
            <tbody>
                <tr>
                    <td>
                        <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="10px" height="1px" />
                    </td>
                    <td>
                        <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="20px" height="1px" />
                    </td>
                    <td>
                        <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="80px" height="1px" />
                    </td>
                    <td>
                        <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="1px" height="1px" />
                    </td>
                    <td>
                        <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="25px" height="1px" />
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
                        <img src="<%= Page.ResolveClientUrl("~/img/pixel.gif") %>" width="10px" height="1px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="8">
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
                        &nbsp;
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
                    <td colspan="8">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="8">
                        <strong>Datos de factura</strong>
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
                        &nbsp;
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
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="center" colspan="8">
                        <input type="button" id="btnAceptarNota" value="Guardar" class="btnmantenimiento"
                            style="font-family: Arial; font-size: 11px;" />
                        &nbsp;<input id="reset" type="reset" value="Limpiar" class="btnmantenimiento" style="font-family: Arial;
                            font-size: 11px;" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="9">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <asp:ValidationSummary ID="vlsum" runat="server" ForeColor="Red" ValidationGroup="valNC" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <%--Duplicar--%>
    <asp:Button ClientIDMode="Static" ID="btnSaveDuplicados" runat="server" Text="duplicate"
        OnClick="btnSaveDuplicados_Click" Height="0px" Width="0px" ForeColor="White"
        BackColor="White" BorderColor="White" BorderStyle="None" />
    <div id="dvDuplicar" style="display: none;" title="Duplicar registros">
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="3">
                                Correlativo:<asp:Label ID="lblOldCorrelativo" runat="server" Text="" />
                                <%--Correlativo:<asp:Label ID="lblOldCorrelativo_Usar_Duplicar" runat="server"  Text="" Visible="false" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" valign="top">
                                <div class="" style="height: 358px; overflow: auto; border: 1px solid black;">
                                    <asp:GridView ID="gvDuplicarRegistros" runat="server" CssClass="grid" AutoGenerateColumns="False"
                                        ShowHeaderWhenEmpty="True" Width="400px">
                                        <Columns>
                                            <asp:TemplateField ControlStyle-CssClass="Hide" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="RowCheckBox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Linea" DataField="idHospedaje">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Serie" DataField="serie">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Correlativo" DataField="correlativo">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Ruc" DataField="ruc">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Agencia" DataField="agencia">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Pasaporte" DataField="pasaporte">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Apellido" DataField="apellidoPaterno">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="paisPasaporte" DataField="paisPasaporte">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="nombre" DataField="nombre">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fec. Ingreso" DataField="fechaIngresoHotel">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fec. Salida" DataField="fechaSalidaHotel">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Nro. Ficha" DataField="nroFicha">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unidad" DataField="unidad">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Ing. Pais" DataField="ingresoPais">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fec. Documento" DataField="fechaDocumento">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Cod. Local" DataField="codLocal">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Cod. Periodo" DataField="codPeriodo">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Segundo Nombre" DataField="segundoNombre">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Ape. Materno" DataField="apellidoMaterno">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Pais Procedencia" DataField="paisProcedencia">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                                <ItemStyle HorizontalAlign="Left" Width="140px" CssClass="Hide" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Valid" DataField="flagValidacion">
                                                <HeaderStyle Width="20px" CssClass="Hide" />
                                                <ItemStyle Width="20px" CssClass="Hide" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle CssClass="altrowstyle" />
                                        <SelectedRowStyle CssClass="SelectedRow" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:ImageButton ID="IbtnSaveDuplicados" runat="server" ImageUrl="~/img/Duplicar.png"
                        ToolTip="Duplicar" OnClientClick="" />
                </td>
                <td>
                    <table>
                        <tr>
                            <td colspan="3">
                                Correlativo:<asp:Label ID="lblNewCorrelativo" runat="server" Text="" />
                                <%--Correlativo:<asp:Label ID="lblNewCorrelativo_Usar_Duplicar" runat="server" Text="" Visible="false" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" valign="top">
                                <div class="" style="height: 358px; overflow: auto; border: 1px solid black;">
                                    <asp:GridView ID="gvViewRegistros" runat="server" CssClass="grid" AutoGenerateColumns="False"
                                        ShowHeaderWhenEmpty="True" AllowPaging="True" Width="300px">
                                        <Columns>
                                            <asp:BoundField HeaderText="Apellido" DataField="apellidoPaterno">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Nombre" DataField="nombre">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle CssClass="altrowstyle" />
                                        <SelectedRowStyle CssClass="SelectedRow" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <%--Duplicar--%>
    <div id="dvDocDistintos" style="display: none;" title="Documentos distintos">
        <asp:ListBox ID="lstDocDistintos" runat="server" Height="250px" Width="235px" Style="margin-top: -5px;" />
    </div>
    <%--JavaScript--%>
    <script type="text/javascript">
        function frValidFechaDoc() {
            var isValid = true;
            var ddlPeriodo = $.trim($('#MainContent_ddlPeriodos :selected').text()).split('-');
            var vmes = "00";
            var vanio = ddlPeriodo[1];
            if (ddlPeriodo[0] == "Enero")
                vmes = "01";
            else if (ddlPeriodo[0] == "Febrero")
                vmes = "02";
            else if (ddlPeriodo[0] == "Marzo")
                vmes = "03";
            else if (ddlPeriodo[0] == "Abril")
                vmes = "04";
            else if (ddlPeriodo[0] == "Mayo")
                vmes = "05";
            else if (ddlPeriodo[0] == "Junio")
                vmes = "06";
            else if (ddlPeriodo[0] == "Julio")
                vmes = "07";
            else if (ddlPeriodo[0] == "Agosto")
                vmes = "08";
            else if (ddlPeriodo[0] == "Septiembre")
                vmes = "09";
            else if (ddlPeriodo[0] == "Octubre")
                vmes = "10";
            else if (ddlPeriodo[0] == "Noviembre")
                vmes = "11";
            else if (ddlPeriodo[0] == "Diciembre")
                vmes = "12";

            if (vmes == "00") {
                alert('El nombre del mes no existe');
                return false;
            }

            if (ddlPeriodo[1] == $('#<%=txtFecDocumento.ClientID %>').val().substring(6)) {
                if (vmes == $('#<%=txtFecDocumento.ClientID %>').val().substring(3, 5)) {

                } else {
                    isValid = false;
                    alert('Fecha Documento Mes Invalido!');
                    $('#<%=txtFecDocumento.ClientID %>').select();
                }
            } else {
                isValid = false;
                alert('Fecha Documento Invalido!');
                $('#<%=txtFecDocumento.ClientID %>').select();
            }

            return isValid;
        }

        function frValidSelect() {
            var isvalid = true;
            if ($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[0]).text() != "")
                return isvalid;
            else {
                alert("Seleccione un registro");
                return false;
            }
        }

        function showPopup(id, width) {
            $('#' + id).dialog({
                autoOpen: true,
                modal: true,
                width: width,
                draggable: true,
                resizable: true
            });
        }
        function showValid() {
            $("#dvListaErros").dialog({
                autoOpen: true,
                modal: false,
                width: 860,
                draggable: true,
                resizable: true
            });
        }
        function IsReadySearch() {
            var IsReadySearch = true;
            if ($('#<%=ddlTipoFechaPrm.ClientID %>').val() != "0") {
                if ($('#<%=txtDesde.ClientID %>').val() == '') {
                    IsReadySearch = false;
                    alert('Ingrese Fecha Desde');
                    $('#<%=txtDesde.ClientID %>').select();
                    return IsReadySearch;
                }
                if ($('#<%=txtHasta.ClientID %>').val() == '') {
                    IsReadySearch = false;
                    alert('Ingrese Fecha Hasta');
                    $('#<%=txtHasta.ClientID %>').select();
                    return IsReadySearch;
                }
            }
            return IsReadySearch;
        }
        function ValidaVenta() {
            $.ajax({
                url: '../PDB/HostingProcess.aspx/ValidaVenta',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "correlativo": $('#<%=txtCorrelativo.ClientID %>').val()
                    }
                }),
                success: function (data) {
                    if (data.d == "1") {
                        if (frValidFechaDoc()) {
                            if (frValidPeriodo()) {
                                UpdateInsertData();
                                $('#popRegistro').closest('.ui-dialog-content').dialog('close');
                            }
                        }
                    } else
                        alert('No se puede guardar por que no existe el correlativo en venta');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        function UpdateInsertData() {
            $.ajax({
                url: '../PDB/HostingProcess.aspx/InsUpdHotels',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "idHospedaje": $('#hdIdHospedaje').val(),
                        "fechaDocumento": $('#<%=txtFecDocumento.ClientID %>').val(),
                        "serie": $('#<%=txtSerie.ClientID %>').val(),
                        "correlativo": $('#<%=txtCorrelativo.ClientID %>').val(),
                        "ruc": $.trim($('#<%=txtRuc.ClientID %>').val()),
                        "agencia": $('#<%=txtAgencia.ClientID %>').val(),
                        "pasaporte": $('#<%=txtPasaporte.ClientID %>').val(),
                        "paisPasaporte": $('#<%=ddlPaisPasaporte.ClientID %>').val(),
                        "apellidoPaterno": $('#<%=txtApePaterno.ClientID %>').val(),
                        "nombre": $('#<%=txtNombre.ClientID %>').val(),
                        "fechaIngresoHotel": $('#<%=txtFecIngHotel.ClientID %>').val(),
                        "fechaSalidaHotel": $('#<%=txtFecSalidaHotel.ClientID %>').val(),
                        "nroFicha": $('#<%=txtNroFicha.ClientID %>').val(),
                        "unidad": $('#<%=txtUnidad.ClientID %>').val(),
                        "ingresoPais": $('#<%=txtIngPais.ClientID %>').val(),
                        "segundoNombre": $('#<%=txtNombre2.ClientID %>').val(),
                        "apellidoMaterno": $('#<%=txtApeMaterno.ClientID %>').val(),
                        "codPeriodo": $('#<%=ddlPeriodos.ClientID %>').val(),
                        "codLocal": $('#<%=ddlLocales.ClientID %>').val(),
                        "paisProcedencia": $('#<%=ddlPaisProcedencia.ClientID %>').val(),
                        "flagValidacion": $('#chkRegValido').is(":checked") == true ? 1 : 0

                    }
                }),
                success: function (data) {
                    if (data.d.substring(0, 1) == "1") {
                        $('#<%=btnSearch.ClientID %>').click();
                        alert('Se ' + ($('#hdIdHospedaje').val() == '0' ? 'ingreso' : 'actualizo') + ' el registro correctamente')
                    } else
                        alert(data.d.substring(2, data.d.length - 2));
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        function DeleteData() {
            $.ajax({
                url: '../PDB/HostingProcess.aspx/DelHotels',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "idHospedaje": $($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[0]).text(),
                        "correlativo": $($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[2]).text()
                    }
                }),
                success: function (data) {
                    if (data.d == "1") {
                        $('#<%=btnSearch.ClientID %>').click();
                        alert('Se elimino el registro correctamente');
                    } else
                        alert('No se realiso la eliminacion del registro');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        function DeleteGroupData() {
            $.ajax({
                url: '../PDB/HostingProcess.aspx/DelGroupHotels',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "codLocal": $($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[17]).text(),
                        "codPeriodo": $($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[18]).text(),
                        "correlativo": $($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[2]).text()
                    }
                }),
                success: function (data) {
                    if (data.d == "1") {
                        $('#<%=btnSearch.ClientID %>').click();
                        alert('Se elimino el registros correctamente');
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        function UpdatePeriodoLocal() {
            $.ajax({
                url: '../PDB/HostingProcess.aspx/UpdPeriodoLocal',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "codPeriodo": $('#<%=ddlPeriodos.ClientID %>').val(),
                        "codLocal": $('#<%=ddlLocales.ClientID %>').val()
                    }
                }),
                success: function (data) {
                    if (data.d == "1") {
                        $('#<%=btnSearch.ClientID %>').click
                        $(".btnmantenimiento").attr("disabled", "disabled");
                        alert('Se ha realizado el precierre de forma satisfactoria');
                    } else {
                        alert('No ha realizado el precierre');
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        function ClearPopupNotas() {

            //llenar datos para borrar validacion
            $('#<%=txtNumSerieNC.ClientID %>').val('1');
            $('#<%=txtNumCorrNC.ClientID %>').val('1');
            $('#<%=txtNumSerieFactura.ClientID %>').val('1');
            $('#<%=txtNumCorrFactura.ClientID %>').val('1');
            $('#<%=txtfecDoc.ClientID %>').val('1');
            
            Page_ClientValidate('valNC');

            $('#<%=txtNumSerieNC.ClientID %>').val('');
            $('#<%=txtNumCorrNC.ClientID %>').val('');
            $('#<%=txtNumSerieFactura.ClientID %>').val('');
            $('#<%=txtNumCorrFactura.ClientID %>').val('');
            $('#<%=txtfecDoc.ClientID %>').val('');
        }
        function ClearPopupRegister() {
            $('#hdIdHospedaje').val('0');
            $('#<%=txtFecDocumento.ClientID %>').val('');
            $('#<%=txtSerie.ClientID %>').val('');
            $('#<%=txtCorrelativo.ClientID %>').val('');
            $('#<%=txtAgencia.ClientID %>').val('');
            $('#<%=txtRuc.ClientID %>').val('');
            $('#<%=txtPasaporte.ClientID %>').val('');
            //$('#<%=ddlPaisPasaporte.ClientID %>').val('1');
            $('#<%=txtApePaterno.ClientID %>').val('');
            $('#<%=txtNombre.ClientID %>').val('');
            $('#<%=txtFecIngHotel.ClientID %>').val('');
            $('#<%=txtFecSalidaHotel.ClientID %>').val('');
            $('#<%=txtNroFicha.ClientID %>').val('');
            $('#<%=txtNombre2.ClientID %>').val('');
            // $('#<%=txtUnidad.ClientID %>').val('');
            $('#<%=txtApeMaterno.ClientID %>').val('');
            $('#<%=txtIngPais.ClientID %>').val('');
            //$('#<%=ddlPaisProcedencia.ClientID %>').val('1');
            $('#chkRegValido').attr('checked', false);
            //Bloqueo_y_Carga();
        }
        function frValidPeriodo() {
            var isValid = true;
            if ($('#<%=txtFecDocumento.ClientID %>').val() == '') {
                isValid = false;
                alert('Ingresar el campo fecha documento!')
                $('#<%=txtFecDocumento.ClientID %>').select();
                return isValid;
            } else if (!validaFechaDDMMAAAA($('#<%=txtFecDocumento.ClientID %>').val())) {
                isValid = false;
                alert('Ingresar Una fecha valida!')
                $('#<%=txtFecDocumento.ClientID %>').select();
                return isValid;
            }
            if ($('#<%=txtPasaporte.ClientID %>').val() == '') {
                isValid = false;
                alert('Ingresar el campo pasaporte!')
                $('#<%=txtPasaporte.ClientID %>').select();
                return isValid;
            }
            if ($('#<%=txtNombre.ClientID %>').val() == '') {
                isValid = false;
                alert('Ingresar el campo nombre!')
                $('#<%=txtNombre.ClientID %>').select();
                return isValid;
            }
            if ($('#<%=txtIngPais.ClientID %>').val() == '') {
                isValid = false;
                alert('Ingresar el campo ingreso al pais!')
                $('#<%=txtIngPais.ClientID %>').select();
                return isValid;
            }
            else if (!validaFechaDDMMAAAA($('#<%=txtIngPais.ClientID %>').val())) {
                isValid = false;
                alert('Ingresar Una fecha valida!')
                $('#<%=txtIngPais.ClientID %>').select();
                return isValid;
            }

            if (parseInt($('#<%=txtNroFicha.ClientID %>').val()) == 0) {
                isValid = false;
                alert('Ingresar nro de ficha diferente de ceros');
                $('#<%=txtFecDocumento.ClientID %>').select();
                return isValid;
            }
            if (!!$('#<%=txtAgencia.ClientID %>').val()) {
                if (!$('#<%=txtRuc.ClientID %>').val()) {
                    isValid = false;
                    alert('Ingresar el nro. de RUC');
                    $('#<%=txtRuc.ClientID %>').select();
                    return isValid;
                }
            }
            if (!!$('#<%=txtRuc.ClientID %>').val()) {
                if (!$('#<%=txtAgencia.ClientID %>').val()) {
                    isValid = false;
                    alert('Ingresar el nombre de la Agencia');
                    $('#<%=txtAgencia.ClientID %>').select();
                    return isValid;
                }
            }
            if (!!$('#<%=txtIngPais.ClientID %>').val() && !!$('#<%=txtFecIngHotel.ClientID %>').val()) {
                if ($('#<%=txtIngPais.ClientID %>').datepicker("getDate") > $('#<%=txtFecIngHotel.ClientID %>').datepicker("getDate")) {
                    isValid = false;
                    alert('Fec. Ingreso a pais no puede ser mayor al ingreso de hotel');
                    $('#<%=txtIngPais.ClientID %>').select();
                    return isValid;
                }
            }
            if (!validaFechaDDMMAAAA($('#<%=txtFecIngHotel.ClientID %>').val())) {
                isValid = false;
                alert('Ingresar Una fecha valida!')
                $('#<%=txtFecIngHotel.ClientID %>').select();
                return isValid;
            }
            if (!!$('#<%=txtFecIngHotel.ClientID %>').val() && !!$('#<%=txtFecSalidaHotel.ClientID %>').val()) {
                if ($('#<%=txtFecIngHotel.ClientID %>').datepicker("getDate") > $('#<%=txtFecSalidaHotel.ClientID %>').datepicker("getDate")) {
                    isValid = false;
                    alert('Fec. Ingreso al hotel no puede ser mayor a la fecha de salida');
                    $('#<%=txtFecIngHotel.ClientID %>').select();
                    return isValid;
                }
            }
            if (!validaFechaDDMMAAAA($('#<%=txtFecSalidaHotel.ClientID %>').val())) {
                isValid = false;
                alert('Ingresar Una fecha valida!')
                $('#<%=txtFecSalidaHotel.ClientID %>').select();
                return isValid;
            }
            return isValid;
        }
        $(document).ready(function () {
            $('#<%=txtIngPais.ClientID %>,#<%=txtFecIngHotel.ClientID %>,#<%=txtFecSalidaHotel.ClientID %>,#<%=txtDesde.ClientID %>,#<%=txtfecDoc.ClientID %>,#<%=txtHasta.ClientID %>,#<%=txtFecDocumento.ClientID %>').datepicker({
                dateFormat: "dd/mm/yy"
            });
            //$('#<%=txtFecDocumento.ClientID %>').datepicker({ dateFormat: "yy/mm/dd" });
            $('#<%=IbtnSaveDuplicados.ClientID %>').click(function () {
                $('#<%=btnSaveDuplicados.ClientID %>').click();
            });

            $('#<%=ddlTipoFechaPrm.ClientID %>').change(function () {
                if ($('#<%=ddlTipoFechaPrm.ClientID %>').val() != "0") {
                    $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').attr('readonly', false);
                    $('#<%=txtDesde.ClientID %>').select();
                } else {
                    $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').attr('readonly', true);
                    $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').val('');
                }
            });
            $("#btnNota").click(function () {                
                ClearPopupNotas();
                $("#popNota").dialog({
                    autoOpen: true,
                    modal: true,
                    width: 350,
                    draggable: true,
                    resizable: true
                });
            });
            $("#btnMore,#btnEdit").click(function () {
                $('#hdIdHospedaje').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[0]).text());
                if ($(this).attr('id') == 'btnMore')
                    $('#hdIdHospedaje').val('0');
                if ($(this).attr('id') == 'btnEdit' & ($('#hdIdHospedaje').val() == '0' || !$('#hdIdHospedaje').val())) {
                    $('#hdIdHospedaje').val('0');
                    alert('Seleccione un registro!');
                    return false;
                }
                $("#popRegistro").dialog({
                    autoOpen: true,
                    modal: true,
                    width: 650,
                    draggable: true,
                    resizable: true
                });
                if ($(this).attr('id') == 'btnEdit') {
                    $("#popRegistro").prev().find('span').text('Editar Registro');
                    if ($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[18]).text() == "1")
                        $('#chkRegValido').attr('checked', true);
                    else
                        $('#chkRegValido').attr('checked', false);
                    $('#<%=txtFecDocumento.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[16]).text());
                    //var fecDoc = $($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[16]).text();
                    //$('#<%=txtFecDocumento.ClientID %>').val(fecDoc.substring(6, 8) + '/' + fecDoc.substring(4, 6) + '/' + fecDoc.substring(0, 4));
                    $('#<%=txtSerie.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[1]).text());
                    $('#<%=txtCorrelativo.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[2]).text());
                    $('#<%=txtAgencia.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[4]).text());
                    $('#<%=txtRuc.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[3]).text());
                    $('#<%=txtPasaporte.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[5]).text());
                    //$('#<%=ddlPaisPasaporte.ClientID %> :selected').text($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[10]).text()));
                    $('#<%=ddlPaisPasaporte.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[22]).text()));
                    $('#<%=txtApePaterno.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[8]).text());
                    $('#<%=txtNombre.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[6]).text());
                    $('#<%=txtFecIngHotel.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[11]).text());
                    $('#<%=txtFecSalidaHotel.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[12]).text());
                    $('#<%=txtNroFicha.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[13]).text());
                    $('#<%=txtUnidad.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[14]).text());
                    $('#<%=txtIngPais.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[15]).text());
                    $('#<%=txtNombre2.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[7]).text());
                    $('#<%=txtApeMaterno.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[9]).text());
                    //$('#<%=ddlPaisProcedencia.ClientID %> :selected').text($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[19]).text()));
                    $('#<%=ddlPaisProcedencia.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[23]).text()));
                } else {
                    $("#popRegistro").prev().find('span').text('Ingresar Registro');
                    ClearPopupRegister();
                    //Bloqueo_y_Carga();
                }
                $("#btnSaveRegister,#btnCancelRegister").css('font-family', 'Arial').css('font-size', '11px');
            });
            $("#btnSaveRegister").click(function () {
                ValidaVenta();
                //                if (frValidFechaDoc()) {
                //                    if (frValidPeriodo()) {
                //                        UpdateInsertData();
                //                        $(this).closest('.ui-dialog-content').dialog('close');
                //                    }
                //                }
            });
            $("#btnAceptarNota").click(function () {
                Page_ClientValidate('valNC');

                if (Page_IsValid && validaFechaDDMMAAAA($('#<%=txtfecDoc.ClientID %>').val())) {
                    $.ajax({
                        url: '../PDB/HostingProcess.aspx/IngresaNota',
                        type: 'POST',
                        dataType: 'json',
                        contentType: 'application/json',
                        data: JSON.stringify({
                            "obj":
                                {
                                    "SerieNC": $('#<%=txtNumSerieNC.ClientID %>').val(),
                                    "CorrNC": $('#<%=txtNumCorrNC.ClientID %>').val(),
                                    "SerieF": $('#<%=txtNumSerieFactura.ClientID %>').val(),
                                    "CorrF": $('#<%=txtNumCorrFactura.ClientID %>').val(),
                                    "fechaF": $('#<%=txtfecDoc.ClientID %>').val()
                                }
                        }),
                        success: function (data) {
                            if (data.d == "0")
                                alert('Hubo un error al insertar');
                            else {
                                alert(data.d);
                                $('#popNota').closest('.ui-dialog-content').dialog('close');
                                $('#<%=btnSearch.ClientID %>').click();
                            }

                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
            $("#btnMinus").click(function () {
                if (confirm('Esta seguro de eliminar el registro?')) {
                    DeleteData();
                }
            });
            $("#btnCancelRegister").click(function () {
                $('#popRegistro').closest('.ui-dialog-content').dialog('close');
            });
            $("#btnDeleteGroup").click(function () {
                if (confirm('Esta seguro de eliminar el registros?')) {
                    DeleteGroupData();
                }
            });
            $("#btnPreClose").click(function () {
                if (confirm('Esta seguro de hacer el pre-cierre?')) {
                    UpdatePeriodoLocal();
                }
            });
            if ($('#<%=ddlTipoFechaPrm.ClientID %>').val() != "0") {
                $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').attr('readonly', false);
                $('#<%=txtDesde.ClientID %>').select();
            } else {
                $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').attr('readonly', true);
                $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').val('');
            }
        });    
    </script>
</asp:Content>
