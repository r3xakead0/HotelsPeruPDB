<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="SummitPDB.WebSite.PDB.Ventas" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <table>
        <tr>
            <td>
                <table class="tblmantenimiento" border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            Periodos:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPeriodos" runat="server" AutoPostBack="true" 
                                Width="160px" onselectedindexchanged="ddlPeriodos_SelectedIndexChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hotel:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocales" runat="server" AutoPostBack="true" onselectedindexchanged="ddlLocales_SelectedIndexChanged" Width="160px" />
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
                                    <asp:ListItem Text="Serie" Value="1" />
                                    <asp:ListItem Text="Correlativo" Value="2" />
                                    <asp:ListItem Text="Documento" Value="3" />
                                    <asp:ListItem Text="Nombres" Value="4" />
                                    <asp:ListItem Text="N° SAP" Value="5" />
                                    <asp:ListItem Text="ID" Value="6" />
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPrmSearch" runat="server" Width="420px" />
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btnmantenimiento" OnClientClick="return IsReadySearch();" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkRangeDate" runat="server" Text="Rango Fechas" Checked="false" />
                            </td>
                            <td>
                                Desde:<asp:TextBox ID="txtDesde" runat="server" Width="70px" />
                            </td>
                            <td>
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
                            <asp:BoundField HeaderText="N° SAP" DataField="Num_SAP">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Fecha de Contabilización" DataField="Fec_Contabilizacion">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Linea" DataField="idVentas">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Tipode Venta" DataField="tipoVenta">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Tipo de comprobante" DataField="tipo">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Fecha de Emisión" DataField="fechaEmision">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Serie" DataField="serie">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Num. Comprobante" DataField="numero">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Tipo de Persona" DataField="tipoPersona">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Tipo de Documento" DataField="tipoDocPersona">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Numero Documento" DataField="numDocumento">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Razon Social" DataField="razonSocialCliente">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Apellido Paterno" DataField="apePaterno">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Apellido Materno" DataField="apeMaterno">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Primer Nombre" DataField="nombre1">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Segundo Nombre" DataField="nombre2">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Tipo de Moneda" DataField="tipoMoneda">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Código Destino" DataField="codDestino">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Num. de Destino" DataField="numeroDestino">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Base Imponible" DataField="baseImponibleOperGravada">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="ISC" DataField="isc">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="IGV" DataField="igv">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Monto Otros" DataField="otros">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Indicador de Percepción" DataField="indicePercepcion">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Tipo Tasa Percepción" DataField="tasaPercepcion">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Serie Percepción" DataField="seriePercepcion">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Num Doc. Percepción" DataField="numDocPercepcion">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Tipo Comprobante Pago" DataField="tipoTabla10">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Serie Doc. Original" DataField="serieDocOriginal">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Num Doc. Original" DataField="numDocOriginal">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Fecha. Doc. Original" DataField="fechaDocOriginal">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Base Imponible Gravada" DataField="baseImponibleOperGravadaNC">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="IGVNC" DataField="IGVNC">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="codLocal" DataField="codLocal">
                                <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                <ItemStyle HorizontalAlign="Left" Width="140px" CssClass="Hide" />
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="btnValid" runat="server" Text="Validar" CssClass="btnmantenimiento"
                    OnClick="btnValid_Click" Width="90px" />

                    
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnApplyRules" runat="server" Text="Aplicar Reglas" CssClass="btnmantenimiento"
                    OnClick="btnApplyRules_Click" Width="90px" />
            </td>
        </tr>
        <tr>
            <td>
                <%--<input type="button" id="btnDeleteGroup" value="Eliminar Grupo" class="btnmantenimiento"
                    style="width: 90px;" />--%>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <%--<input type="button" id="btnDuplicaGrupo" value="Duplica Grupo" class="btnmantenimiento"
                    style="width: 90px;" onclick="btnDuplicar_Click" />
                <asp:Button ID="btnDuplicaGrupo" runat="server" Text="Duplica" CssClass="btnmantenimiento"
                    Width="90px" OnClientClick="return frValidSelect();" OnClick="btnDuplicar_Click" />--%>
            </td>
        </tr>
    </table>
    <div style="width: 820px; text-align: right;">
        <asp:UpdatePanel ID="updTotales" runat="server">
            <ContentTemplate>
                Base Imponible:<asp:TextBox ID="txtBaseImponible" runat="server" Width="100px" /><br />
                Cant. Doc:<asp:TextBox ID="txtCantDoc" runat="server" Width="100px" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--Lista Errores--%>
    <div id="dvListaErros" style="display: none;" title="Listado de errores">
        <asp:ListBox ID="lstErrorList" runat="server" Height="225px" Width="625px" Style="margin-top: -5px;" />
    </div>

    <%--Mantenimiento--%>
    <div id="popRegistro" class="bodyPopup" title="Registro" style="display: none;">
        <table class="tblmantenimiento">
            <tr>
                <th>
                    <label for="chkRegValido">Validado:</label>
                    <input type="checkbox" id="chkRegValido" name="chkRegValido" />
                </th>
                <td>
                    
                </td>
                <td width="10px" />
                <th>
                    Fecha Emision:
                </th>
                <td>
                    <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>TipoVenta
                </th>
                <td>
                <asp:DropDownList ID="ddlTipoVenta" runat="server" CssClass="" >
                <asp:ListItem Value="01" Text="Venta Interna" />
                <asp:ListItem Value="02" Text="Venta Externa" />
                </asp:DropDownList>
                </td>
                <td />
                <th>Tipo Comp.
                </th>
                <td>
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Serie:
                </th>
                <td>
                    <asp:TextBox ID="txtSerie" runat="server" CssClass="" MaxLength="20" />
                </td>
                <td />
                <th>
                    Numero:
                </th>
                <td>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Tipo Persona:
                </th>
                <td>
                    <asp:DropDownList ID="ddlTipoPersona" runat="server" CssClass="">
                        <asp:ListItem Value="01" Text="Persona Natural" />
                        <asp:ListItem Value="02" Text="Persona Jur&iacute;dica" />
                        <asp:ListItem Value="03" Text="Sujetos no domiciliarios" />
                    </asp:DropDownList>
                </td>
                <td />
                <th>
                    Tipo Doc Persona:
                </th>
                <td>
                    <asp:DropDownList ID="ddlTipoDocPersona" runat="server" CssClass="">
                        <asp:ListItem Value="-" Text="Sin documento" />
                        <asp:ListItem Value="1" Text="Libreta electoral - DNI" />
                        <asp:ListItem Value="2" Text="Carnet de fuerzas policiales" />
                        <asp:ListItem Value="3" Text="Carnet de fuerzas armadas" />
                        <asp:ListItem Value="4" Text="Carnet de extranjeria" />
                        <asp:ListItem Value="5" Text="RUC" />
                        <asp:ListItem Value="6" Text="Pasaporte" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    Num Documento:
                </th>
                <td>
                    <asp:TextBox ID="txtNumDocumento" runat="server" CssClass="" />
                </td>
                <td />
                <th>
                    Razon Social Clientee:
                </th>
                <td>
                    <asp:TextBox ID="txtRazonSocialCliente" runat="server" CssClass="" />
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
                    ApeMaterno:
                </th>
                <td>
                    <asp:TextBox ID="txtApeMaterno" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Nombre1:
                </th>
                <td>
                    <asp:TextBox ID="txtNombre1" runat="server" CssClass="" />
                </td>
                <td />
                <th>
                    Nombre2:
                </th>
                <td>
                    <asp:TextBox ID="txtNombre2" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Tipo Moneda:
                </th>
                <td>
                    <asp:DropDownList ID="ddlTipoMoneda" runat="server" CssClass="">
                    <asp:ListItem Value="1" Text="Nuevos Soles" />
                    <asp:ListItem Value="2" Text="D&oacute;lares Americanos" />
                    <asp:ListItem Value="3" Text="Otra moneda" />
                    </asp:DropDownList>
                </td>
                <td width="10px" />
                <th>
                    Cod. Destino:
                </th>
                <td>
                    <asp:DropDownList ID="ddlCodDestino" runat="server" CssClass="">
                    <asp:ListItem Value="1" Text="Ope. Grabada c/n IGV" />
                    <asp:ListItem Value="2" Text="Ope. No Grabada c/n IGV" />
                    <asp:ListItem Value="3" Text="Mixto" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    Numero Destino:
                </th>
                <td>
                    <asp:TextBox ID="txtNumeroDestino" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Base Imponible Oper Gravada:
                </th>
                <td>
                    <asp:TextBox ID="txtBaseImponibleOperGravada" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Isc:
                </th>
                <td>
                    <asp:TextBox ID="txtIsc" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Igv:
                </th>
                <td>
                    <asp:TextBox ID="txtIgv" runat="server" CssClass="" />
                </td>
            </tr>



            <tr>
                <th>
                    Otros:
                </th>
                <td>
                    <asp:TextBox ID="txtOtros" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Indice Percepcion:
                </th>
                <td>
                    <asp:DropDownList ID="ddlIndicePercepcion" runat="server" CssClass="">
                    <asp:ListItem Value="1" Text="Sujeto a percep." />
                    <asp:ListItem Value="0" Text="No sujeto a percep." />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    Tasa Percepcion:
                </th>
                <td>
                    <asp:DropDownList ID="ddlTasaPercepcion" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Serie Percepcion:
                </th>
                <td>
                    <asp:TextBox ID="txtSeriePercepcion" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Num Doc Percepcion:
                </th>
                <td>
                    <asp:TextBox ID="txtNumDocPercepcion" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Tipo Tabla10:
                </th>
                <td>
                    <asp:TextBox ID="txtTipoTabla10" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Serie Doc Original:
                </th>
                <td>
                    <asp:TextBox ID="txtSerieDocOriginal" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Num Doc Original:
                </th>
                <td>
                    <asp:TextBox ID="txtNumDocOriginal" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Fecha Doc Original:
                </th>
                <td>
                    <asp:TextBox ID="txtFechaDocOriginal" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Base Imponible Oper GravadaNC:
                </th>
                <td>
                    <asp:TextBox ID="txtBaseImponibleOperGravadaNC" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    IGVNC:
                </th>
                <td>
                    <asp:TextBox ID="txtIGVNC" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    
                </th>
                <td>
                </td>
            </tr>
        </table>
        <center>
            <input type="button" id="btnSaveRegister" value="Guardar" class="btnmantenimiento" style="font-family:Arial;font-size:11px;" />
            <input type="button" id="btnCancelRegister" value="Cancelar" class="btnmantenimiento" style="font-family:Arial;font-size:11px;" />
        </center>
        <input type="hidden" id="hdIdHospedaje" value="0" />
    </div>
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

            if (ddlPeriodo[1] == $('#<%=txtFechaEmision.ClientID %>').val().substring(6)) {
                if (vmes == $('#<%=txtFechaEmision.ClientID %>').val().substring(3, 5)) {

                } else {
                    isValid = false;
                    alert('Fecha Emision Mes Invalido!');
                    $('#<%=txtFechaEmision.ClientID %>').select();
                }
            } else {
                isValid = false;
                alert('Fecha Emision Invalido!');
                $('#<%=txtFechaEmision.ClientID %>').select();
            }

            return isValid;
        }
        function IsReadySearch() {
            var IsReadySearch = true;
            if ($('#<%=chkRangeDate.ClientID %>').is(":checked")) {
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
        function showValid() {
            $("#dvListaErros").dialog({
                autoOpen: true,
                modal: false,
                width: 650,
                draggable: true,
                resizable: true
            });
        }
        function UpdateInsertData() {
            $.ajax({
                url: '../PDB/Ventas.aspx/InsUpdVentas',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "idVentas": $('#hdIdHospedaje').val(),
                        "tipoVenta": $('#<%=ddlTipoVenta.ClientID %>').val(),
                        "tipo": $('#<%=ddlTipo.ClientID %>').val(),
                        "fechaEmision": $('#<%=txtFechaEmision.ClientID %>').val(),
                        "serie": $('#<%=txtSerie.ClientID %>').val(),
                        "numero": $('#<%=txtNumero.ClientID %>').val(),
                        "tipoPersona": $('#<%=ddlTipoPersona.ClientID %>').val(),
                        "tipoDocPersona": $('#<%=ddlTipoDocPersona.ClientID %>').val(),
                        "numDocumento": $('#<%=txtNumDocumento.ClientID %>').val(),
                        "razonSocialCliente": $('#<%=txtRazonSocialCliente.ClientID %>').val(),
                        "apePaterno": $('#<%=txtApePaterno.ClientID %>').val(),
                        "apeMaterno": $('#<%=txtApeMaterno.ClientID %>').val(),
                        "nombre1": $('#<%=txtNombre1.ClientID %>').val(),
                        "nombre2": $('#<%=txtNombre2.ClientID %>').val(),
                        "tipoMoneda": $('#<%=ddlTipoMoneda.ClientID %>').val(),
                        "codDestino": $('#<%=ddlCodDestino.ClientID %>').val(),
                        "numeroDestino": $('#<%=txtNumeroDestino.ClientID %>').val(),
                        "baseImponibleOperGravada": $('#<%=txtBaseImponibleOperGravada.ClientID %>').val(),
                        "isc": $('#<%=txtIsc.ClientID %>').val(),
                        "igv": $('#<%=txtIgv.ClientID %>').val(),
                        "otros": $('#<%=txtOtros.ClientID %>').val(),
                        "indicePercepcion": $('#<%=ddlIndicePercepcion.ClientID %>').val(),
                        "tasaPercepcion": $('#<%=ddlTasaPercepcion.ClientID %>').val(),
                        "seriePercepcion": $('#<%=txtSeriePercepcion.ClientID %>').val(),
                        "numDocPercepcion": $('#<%=txtNumDocPercepcion.ClientID %>').val(),
                        "tipoTabla10": $('#<%=txtTipoTabla10.ClientID %>').val(),
                        "serieDocOriginal": $('#<%=txtSerieDocOriginal.ClientID %>').val(),
                        "numDocOriginal": $('#<%=txtNumDocOriginal.ClientID %>').val(),
                        "fechaDocOriginal": $('#<%=txtFechaDocOriginal.ClientID %>').val(),
                        "baseImponibleOperGravadaNC": $('#<%=txtBaseImponibleOperGravadaNC.ClientID %>').val(),
                        "IGVNC": $('#<%=txtIGVNC.ClientID %>').val(),
                        "codLocal": $('#<%=ddlLocales.ClientID %>').val()
                    }
                }),
                success: function (data) {
                    if (data.d == "1") {
                        $('#<%=btnSearch.ClientID %>').click();
                        alert('Se ' + ($('#hdIdHospedaje').val() == '0' ? 'ingreso' : 'actualizo') + ' el registro correctamente')
                    } else
                        alert('No se realiso la insercion del registro');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        function DeleteData() {
            $.ajax({
                url: '../PDB/Ventas.aspx/DelVentas',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "idVentas": $($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[2]).text(),
                        "numero": $($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[7]).text()
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
        function ClearPopupRegister() {
            $('#hdIdHospedaje').val('0');
            $('#<%=ddlTipoVenta.ClientID %>').val('01');
            $('#<%=ddlTipo.ClientID %>').val('');
            $('#<%=txtFechaEmision.ClientID %>').val('');
            $('#<%=txtSerie.ClientID %>').val('');
            $('#<%=txtNumero.ClientID %>').val('');
            $('#<%=ddlTipoPersona.ClientID %>').val('');
            $('#<%=ddlTipoDocPersona.ClientID %>').val('');
            $('#<%=txtNumDocumento.ClientID %>').val('');
            $('#<%=txtRazonSocialCliente.ClientID %>').val('');
            $('#<%=txtApePaterno.ClientID %>').val('');
            $('#<%=txtApeMaterno.ClientID %>').val('');
            $('#<%=txtNombre1.ClientID %>').val('');
            $('#<%=txtNombre2.ClientID %>').val('');
            $('#<%=ddlTipoMoneda.ClientID %>').val('');
            $('#<%=ddlCodDestino.ClientID %>').val('');
            $('#<%=txtNumeroDestino.ClientID %>').val('');
            $('#<%=txtBaseImponibleOperGravada.ClientID %>').val('');
            $('#<%=txtIsc.ClientID %>').val('');
            $('#<%=txtIgv.ClientID %>').val('');
            $('#<%=txtOtros.ClientID %>').val('');
            $('#<%=ddlIndicePercepcion.ClientID %>').val('');
            $('#<%=ddlTasaPercepcion.ClientID %>').val('');
            $('#<%=txtSeriePercepcion.ClientID %>').val('');
            $('#<%=txtNumDocPercepcion.ClientID %>').val('');
            $('#<%=txtTipoTabla10.ClientID %>').val('');
            $('#<%=txtSerieDocOriginal.ClientID %>').val('');
            $('#<%=txtNumDocOriginal.ClientID %>').val('');
            $('#<%=txtFechaDocOriginal.ClientID %>').val('');
            $('#<%=txtBaseImponibleOperGravadaNC.ClientID %>').val('');
            $('#<%=txtIGVNC.ClientID %>').val('');
            /*codLocal*/
        }
        function frValidPeriodo() {
            var isValid = true;
            if ($('#<%=txtFechaEmision.ClientID %>').val() == '') {
                isValid = false;
                alert('Ingresar el campo fecha emision!')
                $('#<%=txtFechaEmision.ClientID %>').focus();
                return isValid;
            }
            if ($('#<%=txtNumDocumento.ClientID %>').val() == '') {
                isValid = false;
                alert('Ingresar nor documento!')
                $('#<%=txtNumDocumento.ClientID %>').focus();
                return isValid;
            }
            if ($('#<%=ddlTipoPersona.ClientID %>').val() != '01' & $('#<%=txtRazonSocialCliente.ClientID %>').val() == '') {
                isValid = false;
                alert('Ingresar razon social!')
                $('#<%=txtRazonSocialCliente.ClientID %>').focus();
                return isValid;
            }
            if ($('#<%=ddlTipoPersona.ClientID %>').val() == '01') {
                if (!$('#<%=txtApePaterno.ClientID %>').val()) {
                    isValid = false;
                    alert('Ingresar ape. paterno!')
                    $('#<%=txtApePaterno.ClientID %>').focus();
                    return isValid;
                }
                if (!$('#<%=txtApeMaterno.ClientID %>').val()) {
                    isValid = false;
                    alert('Ingresar ape. materno!')
                    $('#<%=txtApeMaterno.ClientID %>').focus();
                    return isValid;
                }
                if (!$('#<%=txtNombre1.ClientID %>').val()) {
                    isValid = false;
                    alert('Ingresar nombre1!')
                    $('#<%=txtNombre1.ClientID %>').focus();
                    return isValid;
                }
                if (!$('#<%=txtNombre2.ClientID %>').val()) {
                    isValid = false;
                    alert('Ingresar nombre2!')
                    $('#<%=txtNombre2.ClientID %>').focus();
                    return isValid;
                }
            }
            if ($('#<%=ddlIndicePercepcion.ClientID %>').val() == '1') {
                if ($('#<%=txtSeriePercepcion.ClientID %>').val() == '') {
                    isValid = false;
                    alert('Ingresar nro serie del doc. perc.!')
                    $('#<%=txtSeriePercepcion.ClientID %>').focus();
                    return isValid;
                }
                if ($('#<%=txtNumDocPercepcion.ClientID %>').val() == '') {
                    isValid = false;
                    alert('Ingresar nro del doc. perc.!')
                    $('#<%=txtNumDocPercepcion.ClientID %>').focus();
                    return isValid;
                }
            }
            return isValid;
        }
        $(document).ready(function () {
            $('#<%=txtBaseImponibleOperGravada.ClientID %>').focusout(function () {
                var str = $.trim($('#<%=txtBaseImponibleOperGravada.ClientID %>').val());
                var n = str.indexOf(".");
                var val = new Number(str.substring(0, n + 3));
                val = val.toFixed(2);
                if (val > 9999999999.99)
                    val = 9999999999.99;
                $('#<%=txtBaseImponibleOperGravada.ClientID %>').val(val);
            });
            $('#<%=txtIsc.ClientID %>').focusout(function () {
                if ($('#<%=txtIsc.ClientID %>').val() != '2') {
                    var str = $.trim($('#<%=txtIsc.ClientID %>').val());
                    var n = str.indexOf(".");
                    var val = new Number(str.substring(0, n + 3));
                    val = val.toFixed(2);
                    if (val > 9999999999.99)
                        val = 9999999999.99;
                    $('#<%=txtIsc.ClientID %>').val(val);
                } else
                    $('#<%=txtIsc.ClientID %>').val('');
            });
            $('#<%=txtIgv.ClientID %>').focusout(function () {
                var str = $.trim($('#<%=txtIgv.ClientID %>').val());
                var n = str.indexOf(".");
                var val = new Number(str.substring(0, n + 3));
                val = val.toFixed(2);
                if (val > 9999999999.99)
                    val = 9999999999.99;
                $('#<%=txtIgv.ClientID %>').val(val);
            });
            $('#<%=txtFechaEmision.ClientID %>,#<%=txtFechaDocOriginal.ClientID %>').datepicker({
                dateFormat: "dd/mm/yy"
            });
            $('#<%=chkRangeDate.ClientID %>').click(function () {
                if ($(this).is(":checked")) {
                    $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').attr('readonly', false);
                    $('#<%=txtDesde.ClientID %>').select();
                } else {
                    $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').attr('readonly', true);
                    $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').val('');
                }
            });
            $("#btnMore,#btnEdit").click(function () {
                $('#hdIdHospedaje').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[2]).text());
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
                    width: 767,
                    draggable: true,
                    resizable: true
                });
                if ($(this).attr('id') == 'btnEdit') {
                    $("#popRegistro").prev().find('span').text('Editar Registro');
                    $('#<%=ddlTipoVenta.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[3]).text());
                    $('#<%=ddlTipo.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[4]).text());
                    $('#<%=txtFechaEmision.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[5]).text()));
                    $('#<%=txtSerie.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[6]).text()));
                    $('#<%=txtNumero.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[7]).text()));
                    $('#<%=ddlTipoPersona.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[8]).text());
                    $('#<%=ddlTipoDocPersona.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[9]).text());
                    $('#<%=txtNumDocumento.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[10]).text()));
                    $('#<%=txtRazonSocialCliente.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[11]).text()));
                    $('#<%=txtApePaterno.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[12]).text()));
                    $('#<%=txtApeMaterno.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[13]).text()));
                    $('#<%=txtNombre1.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[14]).text()));
                    $('#<%=txtNombre2.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[15]).text()));
                    $('#<%=ddlTipoMoneda.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[16]).text());
                    $('#<%=ddlCodDestino.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[17]).text());
                    $('#<%=txtNumeroDestino.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[18]).text()));
                    $('#<%=txtBaseImponibleOperGravada.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[19]).text()));
                    $('#<%=txtIsc.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[20]).text()));
                    $('#<%=txtIgv.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[21]).text()));
                    $('#<%=txtOtros.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[22]).text()));
                    $('#<%=ddlIndicePercepcion.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[23]).text());
                    $('#<%=ddlTasaPercepcion.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[24]).text()));
                    $('#<%=txtSeriePercepcion.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[25]).text()));
                    $('#<%=txtNumDocPercepcion.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[26]).text()));
                    $('#<%=txtTipoTabla10.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[27]).text()));
                    $('#<%=txtSerieDocOriginal.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[28]).text()));
                    $('#<%=txtNumDocOriginal.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[29]).text()));
                    $('#<%=txtFechaDocOriginal.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[30]).text()));
                    $('#<%=txtBaseImponibleOperGravadaNC.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[31]).text()));
                    $('#<%=txtIGVNC.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[32]).text()));
                } else {
                    $("#popRegistro").prev().find('span').text('Ingresar Registro');
                    ClearPopupRegister();
                }
            });
            $("#btnSaveRegister").click(function () {
                if (frValidFechaDoc()) {
                    if (frValidPeriodo()) {
                        UpdateInsertData();
                        $(this).closest('.ui-dialog-content').dialog('close');
                    }
                }
            });
            $("#btnMinus").click(function () {
                if (confirm('Esta seguro de eliminar el registro?')) {
                    DeleteData();
                }
            });
            $("#btnCancelRegister").click(function () {
                $(this).closest('.ui-dialog-content').dialog('close');
            });
            $('#<%=ddlTipoVenta.ClientID %>').change(function () {
                $('#<%=ddlTipo.ClientID %>').empty();
                if ($('#<%=ddlTipoVenta.ClientID %>').val() == '01') {
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('01').html('01'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('03').html('03'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('05').html('05'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('06').html('06'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('07').html('07'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('08').html('08'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('12').html('12'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('15').html('15'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('16').html('16'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('23').html('23'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('25').html('25'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('34').html('34'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('35').html('35'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('36').html('36'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('37').html('37'));
                } else {
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('01').html('01'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('03').html('03'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('07').html('07'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('08').html('08'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('12').html('12'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('34').html('34'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('35').html('35'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('36').html('36'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('37').html('37'));
                }
            });
            $('#<%=ddlTipo.ClientID %>').change(function () {
                if ($('#<%=ddlTipo.ClientID %>').val() == '01' || $('#<%=ddlTipo.ClientID %>').val() == '03' || $('#<%=ddlTipo.ClientID %>').val() == '07' || $('#<%=ddlTipo.ClientID %>').val() == '08' || $('#<%=ddlTipo.ClientID %>').val() == '34' || $('#<%=ddlTipo.ClientID %>').val() == '35' || $('#<%=ddlTipo.ClientID %>').val() == '36' || $('#<%=ddlTipo.ClientID %>').val() == '37') {
                    $('#<%=txtSerie.ClientID %>').attr('maxlength', '4');
                    $('#<%=txtNumero.ClientID %>').removeAttr('onkeypress');
                    $('#<%=txtNumero.ClientID %>').attr('onkeypress', 'javascript:return ValidNum(event);')
                }
                else if ($('#<%=ddlTipo.ClientID %>').val() == '12') {
                    $('#<%=txtSerie.ClientID %>').attr('maxlength', '20');
                    $('#<%=txtNumero.ClientID %>').removeAttr('onkeypress');
                }
                else {
                    $('#<%=txtSerie.ClientID %>').attr('maxlength', '10');
                    $('#<%=txtNumero.ClientID %>').removeAttr('onkeypress');
                    $('#<%=txtNumero.ClientID %>').attr('onkeypress', 'javascript:return ValidNum(event);')
                }
            });
            $('#<%=ddlIndicePercepcion.ClientID %>').change(function () {
                $('#<%=ddlTasaPercepcion.ClientID %>').empty();
                if ($('#<%=ddlIndicePercepcion.ClientID %>').val() == '1') {
                    $('#<%=ddlTasaPercepcion.ClientID %>').append($('<option></option>').val('01').html('Combustibles / 1%'));
                    $('#<%=ddlTasaPercepcion.ClientID %>').append($('<option></option>').val('02').html('Importaciones art 4° lit.a) / 10%'));
                    $('#<%=ddlTasaPercepcion.ClientID %>').append($('<option></option>').val('03').html('Importaciones art 4° lit.b) / 5%'));
                    $('#<%=ddlTasaPercepcion.ClientID %>').append($('<option></option>').val('04').html('Importaciones art 4° lit.c) / 3.5%'));
                    $('#<%=ddlTasaPercepcion.ClientID %>').append($('<option></option>').val('05').html('Vtas Internas - art 5° lit a) / 10%'));
                    $('#<%=ddlTasaPercepcion.ClientID %>').append($('<option></option>').val('06').html('Vtas Internas - art 5° lit b) / 2%'));
                    $('#<%=ddlTasaPercepcion.ClientID %>').append($('<option></option>').val('07').html('Vtas Internas - art 5° lit c) / 0.5%'));
                } else {
                    $('#<%=ddlTasaPercepcion.ClientID %>').append($('<option></option>').val(' ').html(' '));
                }
            });
        });    
    </script>
</asp:Content>
