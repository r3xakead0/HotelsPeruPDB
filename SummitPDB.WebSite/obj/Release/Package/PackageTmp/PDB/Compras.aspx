<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Compras.aspx.cs" Inherits="SummitPDB.WebSite.PDB.Compras" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.validate.wrapper.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Compras</h2>
    <table>
        <tr>
            <td>
                <table class="tblmantenimiento" border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td>
                            Periodos:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPeriodos" runat="server" AutoPostBack="true" Width="160px"
                                OnSelectedIndexChanged="ddlPeriodos_SelectedIndexChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hotel:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocales" runat="server" AutoPostBack="true" Width="160px"
                                OnSelectedIndexChanged="ddlLocales_SelectedIndexChanged" />
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
                                    <asp:ListItem Text="serie" Value="1" />
                                    <asp:ListItem Text="numero" Value="2" />
                                    <asp:ListItem Text="Documento" Value="3" />
                                    <asp:ListItem Text="Nombres" Value="4" />
                                    <asp:ListItem Text="Correlativo" Value="5" />
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPrmSearch" runat="server" Width="420px" />
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btnmantenimiento"
                                    OnClientClick="return IsReadySearch();" OnClick="btnSearch_Click" />
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
                                AllowPaging="True" Width="3800px">
                                <Columns>
                                    <asp:BoundField DataField="Fec_Contabilizacion" HeaderText="Fec. Contabilizacion">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Uni_Negocio" HeaderText="Uni Negocio">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="idCompras" DataField="idCompras">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Num_Correlativo" HeaderText="SAP Correlativo">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tipode Compra" DataField="tipoVenta">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tipo de Comprante" DataField="tipo">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Fecha de Emision" DataField="fechaEmision">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Serie Comprobante" DataField="serie">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nro Comprobante" DataField="numero">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tipo de Persona" DataField="tipoPersona">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tipo de Doc. Persona" DataField="tipoDocPersona">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nro Doc. Persona" DataField="numDocumento">
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
                                    <asp:BoundField HeaderText="Numero destino" DataField="numeroDestino">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Base Imponible" DataField="baseImponibleOperGravada">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Monto ISC" DataField="isc">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Monto IGV" DataField="igv">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Monto Otros" DataField="otros">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Indice Detracción" DataField="indicePercepcion">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tasa Detracción" DataField="tasaPercepcion">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Num Doc. Detracción" DataField="seriePercepcion">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Indic Retenciones" DataField="numDocPercepcion">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Tipo. Comprobante Pago" DataField="tipoTabla10">
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
                                    <asp:BoundField HeaderText="IGV" DataField="IGVNC">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="codLocal" DataField="codLocal">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="altrowstyle" />
                                <SelectedRowStyle CssClass="SelectedRow" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td height="25px">
                &nbsp;
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
        <td valign="top" rowspan="4">
        </td>
        <tr>
            <td>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <div style="width: 820px; text-align: right;">
        <asp:UpdatePanel ID="updTotales" runat="server">
            <ContentTemplate>
                Base Imponible:<asp:TextBox ID="txtBaseImponible" runat="server" Width="100px" ReadOnly="True" /><br />
                Cant. Doc:<asp:TextBox ID="txtCantDoc" runat="server" Width="100px" ReadOnly="True" /><br />
                IGV:<asp:TextBox ID="txtIGVTot" runat="server" Width="100px" ReadOnly="True" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--Mantenimiento--%>
    <div id="popRegistro" class="bodyPopup" title="Registro" style="display: none;">
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="false" ShowSummary="true"
            HeaderText="Ingresar los siguientes campos:" EnableClientScript="true" ValidationGroup="mant"
            ForeColor="red" Font-Name="tahoma" Font-Size="8pt" runat="server" />
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
                    Fecha Emision/Pago:
                </th>
                <td>
                    <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Tipo Compra:
                </th>
                <td>
                    <asp:DropDownList ID="ddlTipoCompra" runat="server" CssClass="">
                        <asp:ListItem Value="01" Text="Compra Interna" />
                        <asp:ListItem Value="02" Text="Compra Externa" />
                    </asp:DropDownList>
                </td>
                <td />
                <th>
                    Tipo Comprobante:
                </th>
                <td>
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="" Style="width: 160px;">
                        <asp:ListItem Value="01" Text="FACTURA" />
                        <asp:ListItem Value="03" Text="BOLETA DE VENTA" />
                        <asp:ListItem Value="04" Text="LIQUIDACION DE COMPRA" />
                        <asp:ListItem Value="05" Text="BOLETO DE COMPANIAS DE AVIACION" />
                        <asp:ListItem Value="06" Text="CARTA DE PORTE AEREO" />
                        <asp:ListItem Value="07" Text="NOTA DE CREDITO" />
                        <asp:ListItem Value="08" Text="NOTA DE DEBITO" />
                        <asp:ListItem Value="10" Text="RECIBO POR ARRENDAMIENTO" />
                        <asp:ListItem Value="11" Text="POLIZA DE LA BOLSA DE VALORES" />
                        <asp:ListItem Value="12" Text="TICKET DE MAQUINA REGISTRADORA" />
                        <asp:ListItem Value="13" Text="DOCUMENTOS BANCA Y SEGUROS" />
                        <asp:ListItem Value="14" Text="RECIBOS POR SERVICIOS PUBLICOS" />
                        <asp:ListItem Value="15" Text="BOLETO EMITIDO POR EL TRANSPORTE URBANO" />
                        <asp:ListItem Value="16" Text="BOLETO DE VIAJE-TRANSPORTE INTERPROVINCIAL" />
                        <asp:ListItem Value="17" Text="DOCUMENTOS EMITIDOS POR LA IGLESIA" />
                        <asp:ListItem Value="18" Text="DOCUMENTOS EMITIDOS POR LAS AFP Y EPS" />
                        <asp:ListItem Value="21" Text="CONOCIMIENTO DE EMBARQUE" />
                        <asp:ListItem Value="22" Text="COMPROBANTE POR OPERACIONES NO HABITUALES" />
                        <asp:ListItem Value="23" Text="POLIZA DE ADJUDICACION POR REMATE DE BIENES" />
                        <asp:ListItem Value="24" Text="CERTIFICADO DE PAGO REGALIAS-PERUPETRO S.A." />
                        <asp:ListItem Value="25" Text="DOCUMENTO DE ATRIBUCION" />
                        <asp:ListItem Value="26" Text="RECIBO POR EL PAGO DE TARIFA POR USO DE AGUA SUPERFICIAL" />
                        <asp:ListItem Value="27" Text="SEGURO COMPLEMENTARIO DE TRABAJO DE RIESGO" />
                        <asp:ListItem Value="28" Text="TARIFA UNIFICADA DE USO DE AEROPUERTO" />
                        <asp:ListItem Value="29" Text="DOCUMENTOS EMITIDOS POR LA COFOPRI" />
                        <asp:ListItem Value="30" Text="DOC. EMIT. EMPRESAS ADQ. EN LOS SIST. DE PAGO MED. TARJETAS DE CRÉDITO O DÉBITO" />
                        <asp:ListItem Value="32" Text="DOC. EMIT. EMP. RECAUDADORAS (GARANTIA DE RED PRINCIPAL)" />
                        <asp:ListItem Value="34" Text="DOCUMENTO DEL OPERADOR" />
                        <asp:ListItem Value="35" Text="DOCUMENTO DEL PARTICIPE" />
                        <asp:ListItem Value="36" Text="RECIBO DE DISTRIBUCION DE GAS NATURAL" />
                        <asp:ListItem Value="37" Text="DOC. CONCESIONARIOS DEL SERVICIO REVISIONES TECNICAS VEHICULARES" />
                        <asp:ListItem Value="55" Text="BOLETO DE VIAJE EMITIDO POR MEDIOS ELECTRÓNICOS PARA TRANSPORTE FERROVIARIO DE PASAJEROS (BVME)" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    Serie de Comprobante:
                </th>
                <td>
                    <asp:TextBox ID="txtSerie" runat="server" CssClass="" MaxLength="4" />
                </td>
                <td />
                <th>
                    N&uacute;mero de comprobante:
                </th>
                <td>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <th>
                    Tipo de Persona:
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
                    Tipo de Doc. Persona:
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
                    Nro. Documento:
                </th>
                <td>
                    <asp:TextBox ID="txtNumDocumento" runat="server" CssClass="" MaxLength="12" />
                </td>
                <td />
                <th>
                    Razon Social Cliente:
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
                    Apellido Materno:
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
                    Tipo de Moneda:
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
                    C&oacute;digo de Destino:
                </th>
                <td>
                    <asp:DropDownList ID="ddlCodDestino" runat="server" CssClass="" Style="width: 160px;">
                        <asp:ListItem Value="1" Text="Adqui. gravadas dest. a Ope. gravadas y/o exp." />
                        <asp:ListItem Value="2" Text="Adqui. gravadas dest. conjuntamente a Ope. gravada y no gravada" />
                        <asp:ListItem Value="3" Text="Adqui. gravadas dest. a Ope. no gravadas" />
                        <asp:ListItem Value="4" Text="Adqui. no gravadas" />
                        <asp:ListItem Value="5" Text="Adqui. con m&aacute;s de un destino" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    Nro Destino:
                </th>
                <td>
                    <asp:TextBox ID="txtNumeroDestino" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Base Imponible:
                </th>
                <td>
                    <asp:TextBox ID="txtBaseImponibleOperGravada" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Monto ISC:
                </th>
                <td>
                    <asp:TextBox ID="txtIsc" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Mont IGV:
                </th>
                <td>
                    <asp:TextBox ID="txtIgv" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Monto Otros:
                </th>
                <td>
                    <asp:TextBox ID="txtOtros" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Indice Detracci&oacute;n:
                </th>
                <td>
                    <asp:DropDownList ID="ddlIndiceDetraccion" runat="server" CssClass="">
                        <asp:ListItem Value="1" Text="Sujeto a detrac." />
                        <asp:ListItem Value="0" Text="No sujeto a detrac." />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    Tasa Detracci&oacute;n:
                </th>
                <td>
                    <asp:DropDownList ID="ddlTasaDetraccion" runat="server" CssClass="" Style="width: 160px;">
                        <asp:ListItem Value="" Text="Ninguno" />
                        <asp:ListItem Value="00101" Text="Azucar                                                             / 10%" />
                        <asp:ListItem Value="00201" Text="Arroz                                                              / 10%" />
                        <asp:ListItem Value="00301" Text="Alcohol Etilico                                                    / 10%" />
                        <asp:ListItem Value="00401" Text="Recursos Hidrobiologicos                                           / 09%" />
                        <asp:ListItem Value="00402" Text="Recursos Hidrobiologicos                                           / 15%" />
                        <asp:ListItem Value="00501" Text="Maiz Amarillo Duro                                                 / 07%" />
                        <asp:ListItem Value="00502" Text="Maiz Amarillo Duro                                                 / 10%" />
                        <asp:ListItem Value="00601" Text="Algodon                                                            / 10%" />
                        <asp:ListItem Value="00602" Text="Algodon                                                            / 11%" />
                        <asp:ListItem Value="00603" Text="Algodon                                                            / 15%" />
                        <asp:ListItem Value="00701" Text="Caña de Azucar                                                     / 10%" />
                        <asp:ListItem Value="00702" Text="Caña de Azucar                                                     / 12%" />
                        <asp:ListItem Value="00801" Text="Madera                                                             / 09%" />
                        <asp:ListItem Value="00901" Text="Arena y Piedra                                                     / 10%" />
                        <asp:ListItem Value="00902" Text="Arena y Piedra                                                     / 12%" />
                        <asp:ListItem Value="01001" Text="Residuos-subproductos-desechos-recortes y desperdicios             / 10%" />
                        <asp:ListItem Value="01002" Text="Residuos-subproductos-desechos-recortes y desperdicios             / 14%" />
                        <asp:ListItem Value="01101" Text="Bienes con renuncia a exoneración de IGV                           / 10%" />
                        <asp:ListItem Value="01201" Text="Servicios de Intermediación Laboral Grav con el IGV y Terceriz.    / 12%" />
                        <asp:ListItem Value="01202" Text="Servicios de Intermediación Laboral Grav con el IGV y Terceriz.    / 14%" />
                        <asp:ListItem Value="01301" Text="Animales Vivos                                                     / 04%" />
                        <asp:ListItem Value="01302" Text="Animales Vivos                                                     / 10%" />
                        <asp:ListItem Value="01401" Text="Carnes y despojos comestibles                                      / 04%" />
                        <asp:ListItem Value="01402" Text="Carnes y despojos comestibles                                      / 10%" />
                        <asp:ListItem Value="01501" Text="Abonos-cueros y pieles de origen animal                            / 04%" />
                        <asp:ListItem Value="01502" Text="Abonos-cueros y pieles de origen animal                            / 10%" />
                        <asp:ListItem Value="01601" Text="Aceite de pescado                                                  / 09%" />
                        <asp:ListItem Value="01701" Text="Harina - polvo y pellets de pescado - crust. Molus y demas inv. Ac./ 09%" />
                        <asp:ListItem Value="01801" Text="Embarcaciones Pesqueras                                            / 09%" />
                        <asp:ListItem Value="01901" Text="Arrendamiento de bienes Muebles                                    / 09%" />
                        <asp:ListItem Value="01902" Text="Arrendamiento de bienes Muebles                                    / 12%" />
                        <asp:ListItem Value="02001" Text="Mantenimiento y Reparación de Bienes Muebles                       / 09%" />
                        <asp:ListItem Value="02101" Text="Movimiento de carga                                                / 12%" />
                        <asp:ListItem Value="02102" Text="Movimiento de carga                                                / 14%" />
                        <asp:ListItem Value="02201" Text="Otros servicios empresariales                                      / 12%" />
                        <asp:ListItem Value="02202" Text="Otros servicios empresariales                                      / 14%" />
                        <asp:ListItem Value="02301" Text="Leche                                                              / 04%" />
                        <asp:ListItem Value="02401" Text="Comisión Mercantil                                                 / 12%" />
                        <asp:ListItem Value="02501" Text="Fabricacion de bienes por encargo                                  / 12%" />
                        <asp:ListItem Value="02601" Text="Servicio de Transporte de Personas                                 / 12%" />
                        <asp:ListItem Value="02701" Text="Servicio de transportes de bienes                                  / 08%" />
                        <asp:ListItem Value="02702" Text="Servicio de transportes de bienes                                  / 04%" />
                        <asp:ListItem Value="03001" Text="Contratos de construccion                                          / 05%" />
                        <asp:ListItem Value="03101" Text="Oro gravado con el IGV                                             / 12%" />
                        <asp:ListItem Value="03201" Text="Paprika                                                            / 12%" />
                        <asp:ListItem Value="03301" Text="Esparragos                                                         / 12%" />
                        <asp:ListItem Value="03401" Text="Minerales Metalicos no Auriferos                                   / 12%" />
                        <asp:ListItem Value="03501" Text="Bienes exonerados del IGV                                          / 15%" />
                        <asp:ListItem Value="03601" Text="Oro y minerales metálicos exonerados IGV                           / 05%" />
                        <asp:ListItem Value="03701" Text="Demás servicios gravados con el IGV                                / 09%" />
                        <asp:ListItem Value="03801" Text="Espectáculos públicos no deportivos                                / 09%" />
                        <asp:ListItem Value="03901" Text="Minerales No Metálicos                                             / 06%" />
                    </asp:DropDownList>
                </td>
                <td width="10px" />
                <th>
                    Nro Doc. Detrac:
                </th>
                <td>
                    <asp:TextBox ID="txtNumDocPercepcion" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Ind. Retencion:
                </th>
                <td>
                    <asp:TextBox ID="txtSeriePercepcion" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Tipo Comprobante/Pago:
                </th>
                <td>
                    <asp:TextBox ID="txtTipoTabla10" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Serie Doc. Original:
                </th>
                <td>
                    <asp:TextBox ID="txtSerieDocOriginal" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Nro Doc. Original:
                </th>
                <td>
                    <asp:TextBox ID="txtNumDocOriginal" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    Fecha Doc. Original:
                </th>
                <td>
                    <asp:TextBox ID="txtFechaDocOriginal" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                <th>
                    Base Imponible:
                </th>
                <td>
                    <asp:TextBox ID="txtBaseImponibleOperGravadaNC" runat="server" CssClass="" />
                </td>
            </tr>
            <tr>
                <th>
                    IGV:
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
            <tr id="trNew">
                <th>
                    Num. Correlativo:
                </th>
                <td>
                    <asp:TextBox ID="txtNum_Correlativo" runat="server" CssClass="" />
                </td>
                <td width="10px" />
                &nbsp;<th>
                    Fecha contabilización:
                </th>
                <td>
                    <asp:TextBox ID="txtFechaContabilizacion" runat="server" CssClass="" />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="Button1" Text="Guardar" runat="server" ValidationGroup="mant" CssClass="btnmantenimiento"
                Style="font-family: Arial; font-size: 11px;" />
            <%--<input type="button" id="btnSaveRegister" value="Guardar" class="btnmantenimiento" style="font-family:Arial;font-size:11px;" />--%>
            <input type="button" id="btnCancelRegister" value="Cancelar" class="btnmantenimiento"
                style="font-family: Arial; font-size: 11px;" />
        </center>
        <input type="hidden" id="hdIdHospedaje" value="0" />
    </div>
    <%--Validaciones--%>
    <div style="display: none;">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaEmision"
            ErrorMessage="Ingrese Fecha Emision" Text="*" Display="Static" ValidationGroup="mant" />
        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="ddlIndiceDetraccion"
            ClientValidationFunction="frNumDocPercepcion" ErrorMessage="Ingrese Nro Doc. Detrac.!"
            Text="*" Display="Static" ValidationGroup="mant" />
        <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="ddlIndiceDetraccion"
            ClientValidationFunction="frSeriePercepcion" ErrorMessage="Ingrese Serie Doc. Percep.!"
            Text="*" Display="Static" ValidationGroup="mant" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBaseImponibleOperGravada"
            ErrorMessage="Ingrese Base Imponible." Text="*" Display="Static" ValidationGroup="mant"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="ddlTipoPersona"
            ClientValidationFunction="frApePaterno" ErrorMessage="Ingrese Ape. Paterno!"
            Text="*" Display="Static" ValidationGroup="mant" />
        <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="ddlTipoPersona"
            ClientValidationFunction="frNombre1" ErrorMessage="Ingrese Nombre1!" Text="*"
            Display="Static" ValidationGroup="mant" />

        <asp:CustomValidator ID="CustomValidator6" runat="server" ControlToValidate="ddlTipoPersona"
            ClientValidationFunction="frRazonSocial" ErrorMessage="Ingrese Razon Social!"
            Text="*" Display="Static" ValidationGroup="mant" />               
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ClientValidationFunction="Validaserie1662" ErrorMessage="Ingrese Nro Documento!"
            Text="*" Display="Static" ValidationGroup="mant" />
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSerie"
            ErrorMessage="Ingrese Serie." Text="*" Display="Static" ValidationGroup="mant" />
    </div>
    <script type="text/javascript">

        function Validaserie1662(source, arguments) {
            var serie = $('#<%=txtSerie.ClientID %>').val();
            var Numdoc = $('#<%=txtNumDocumento.ClientID %>').val();

            if (Numdoc == '')
                if (serie == '1662') arguments.IsValid = true;
                else arguments.IsValid = false;            
        }
        function frRazonSocial(source, arguments) {
            if (!$('#<%=txtRazonSocialCliente.ClientID %>').val() & (arguments.Value == '02' || arguments.Value == '03')) {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        }
        function frApePaterno(source, arguments) {
            if (!$('#<%=txtApePaterno.ClientID %>').val() & arguments.Value == '01') {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        }
        function frNombre1(source, arguments) {
            if (!$('#<%=txtNombre1.ClientID %>').val() & arguments.Value == '01') {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        }
        function frNumDocPercepcion(source, arguments) {
            if (!$('#<%=txtNumDocPercepcion.ClientID %>').val() && arguments.Value == 1) {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        }
        function frSeriePercepcion(source, arguments) {
            if (!$('#<%=txtSeriePercepcion.ClientID %>').val() && arguments.Value == 1) {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        }
    </script>
    <%--Script Mantenimiento--%>
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
                url: '../PDB/Compras.aspx/InsUpdCompras',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "idCompras": $('#hdIdHospedaje').val(),
                        "tipoVenta": $('#<%=ddlTipoCompra.ClientID %>').val(),
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
                        "indicePercepcion": $('#<%=ddlIndiceDetraccion.ClientID %>').val(),
                        "tasaPercepcion": $('#<%=ddlTasaDetraccion.ClientID %>').val(),
                        "seriePercepcion": $('#<%=txtSeriePercepcion.ClientID %>').val(),
                        "numDocPercepcion": $('#<%=txtNumDocPercepcion.ClientID %>').val(),
                        "tipoTabla10": $('#<%=txtTipoTabla10.ClientID %>').val(),
                        "serieDocOriginal": $('#<%=txtSerieDocOriginal.ClientID %>').val(),
                        "numDocOriginal": $('#<%=txtNumDocOriginal.ClientID %>').val(),
                        "fechaDocOriginal": $('#<%=txtFechaDocOriginal.ClientID %>').val(),
                        "baseImponibleOperGravadaNC": $('#<%=txtBaseImponibleOperGravadaNC.ClientID %>').val(),
                        "IGVNC": $('#<%=txtIGVNC.ClientID %>').val(),
                        "codLocal": $('#<%=ddlLocales.ClientID %>').val(),

                        "Num_Correlativo": $('#<%=txtNum_Correlativo.ClientID %>').val(),
                        "Fec_Contabilizacion": $('#<%=txtFechaContabilizacion.ClientID %>').val(),
                        "Uni_Negocio": $('#<%=ddlLocales.ClientID %>').text().trim()
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
                url: '../PDB/Compras.aspx/DelCompras',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "idCompras": $($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[2]).text()
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
            $('#<%=ddlTipoCompra.ClientID %>').val('');
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
            $('#<%=ddlIndiceDetraccion.ClientID %>').val('');
            $('#<%=ddlTasaDetraccion.ClientID %>').val('');
            $('#<%=txtSeriePercepcion.ClientID %>').val('');
            $('#<%=txtNumDocPercepcion.ClientID %>').val('');
            $('#<%=txtTipoTabla10.ClientID %>').val('');
            $('#<%=txtSerieDocOriginal.ClientID %>').val('');
            $('#<%=txtNumDocOriginal.ClientID %>').val('');
            $('#<%=txtFechaDocOriginal.ClientID %>').val('');
            $('#<%=txtBaseImponibleOperGravadaNC.ClientID %>').val('');
            $('#<%=txtIGVNC.ClientID %>').val('');

            $('#<%=txtFechaContabilizacion.ClientID %>').val('');
            $('#<%=txtNum_Correlativo.ClientID %>').val('');
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
            return isValid;
        }
        $(document).ready(function () {
            $('#<%=txtBaseImponibleOperGravada.ClientID %>').focusout(function () {
                var str = $.trim($('#<%=txtBaseImponibleOperGravada.ClientID %>').val());
                var n = str.indexOf(".");
                var val;
                if (n > 0)
                    val = new Number(str.substring(0, n + 3));
                else
                    val = new Number(str);
                val = val.toFixed(2);
                if (val > 9999999999.99)
                    val = 9999999999.99;
                $('#<%=txtBaseImponibleOperGravada.ClientID %>').val(val);
            });
            $('#<%=txtIsc.ClientID %>').focusout(function () {
                if ($('#<%=ddlCodDestino.ClientID %>').val() != '2') {
                    var str = $.trim($('#<%=txtIsc.ClientID %>').val());
                    var n = str.indexOf(".");
                    var val;
                    if (n > 0)
                        val = new Number(str.substring(0, n + 3));
                    else
                        val = new Number(str);
                    val = val.toFixed(2);
                    if (val > 9999999999.99)
                        val = 9999999999.99;
                    $('#<%=txtIsc.ClientID %>').val(val);
                } else
                    $('#<%=txtIsc.ClientID %>').val('');
            });
            $('#<%=txtIgv.ClientID %>').focusout(function () {
                if ($('#<%=ddlCodDestino.ClientID %>').val() != '2') {
                    var str = $.trim($('#<%=txtIgv.ClientID %>').val());
                    var n = str.indexOf(".");
                    var val;
                    if (n > 0)
                        val = new Number(str.substring(0, n + 3));
                    else
                        val = new Number(str);
                    val = val.toFixed(2);
                    if (val > 9999999999.99)
                        val = 9999999999.99;
                    $('#<%=txtIgv.ClientID %>').val(val);
                } else
                    $('#<%=txtIgv.ClientID %>').val('');
            });
            $('#<%=txtOtros.ClientID %>').focusout(function () {
                if ($('#<%=ddlCodDestino.ClientID %>').val() != '2') {
                    var str = $.trim($('#<%=txtOtros.ClientID %>').val());
                    var n = str.indexOf(".");
                    var val;
                    if (n > 0)
                        val = new Number(str.substring(0, n + 3));
                    else
                        val = new Number(str);
                    val = val.toFixed(2);
                    if (val > 9999999999.99)
                        val = 9999999999.99;
                    $('#<%=txtOtros.ClientID %>').val(val);
                } else
                    $('#<%=txtOtros.ClientID %>').val('');
            });
            $('#<%=txtFechaEmision.ClientID %>,#<%=txtFechaContabilizacion.ClientID %>,#<%=txtFechaDocOriginal.ClientID %>,#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').datepicker({
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
                    width: 710,
                    draggable: true,
                    resizable: true
                });
                if ($(this).attr('id') == 'btnEdit') {
                    $("#popRegistro").prev().find('span').text('Editar Registro');
                    $('#<%=ddlTipoCompra.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[4]).text());
                    $('#<%=ddlTipo.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[5]).text());
                    $('#<%=txtFechaEmision.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[6]).text()));
                    $('#<%=txtSerie.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[7]).text()));
                    $('#<%=txtNumero.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[8]).text()));
                    $('#<%=ddlTipoPersona.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[9]).text());
                    $('#<%=ddlTipoDocPersona.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[10]).text());
                    $('#<%=txtNumDocumento.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[11]).text()));
                    $('#<%=txtRazonSocialCliente.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[12]).text()));
                    $('#<%=txtApePaterno.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[13]).text()));
                    $('#<%=txtApeMaterno.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[14]).text()));
                    $('#<%=txtNombre1.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[15]).text()));
                    $('#<%=txtNombre2.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[16]).text()));
                    $('#<%=ddlTipoMoneda.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[17]).text());
                    $('#<%=ddlCodDestino.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[18]).text());
                    $('#<%=txtNumeroDestino.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[19]).text()));
                    $('#<%=txtBaseImponibleOperGravada.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[20]).text()));
                    $('#<%=txtIsc.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[21]).text()));
                    $('#<%=txtIgv.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[22]).text()));
                    $('#<%=txtOtros.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[23]).text()));
                    $('#<%=ddlIndiceDetraccion.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[24]).text());
                    $('#<%=ddlTasaDetraccion.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[25]).text());
                    $('#<%=txtSeriePercepcion.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[26]).text()));
                    $('#<%=txtNumDocPercepcion.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[27]).text()));
                    $('#<%=txtTipoTabla10.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[28]).text()));
                    $('#<%=txtSerieDocOriginal.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[29]).text()));
                    $('#<%=txtNumDocOriginal.ClientID %>').val($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[30]).text());
                    $('#<%=txtFechaDocOriginal.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[31]).text()));
                    $('#<%=txtBaseImponibleOperGravadaNC.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[32]).text()));
                    $('#<%=txtIGVNC.ClientID %>').val($.trim($($('#<%=gvHotels.ClientID %>').find('.SelectedRow td')[33]).text()));

                    $('#trNew').hide();
                    //                $('#<%=txtFechaContabilizacion.ClientID %>').val('');
                    //                $('#<%=txtNum_Correlativo.ClientID %>').val('');
                } else {
                    $('#trNew').show();
                    $("#popRegistro").prev().find('span').text('Ingresar Registro');
                    ClearPopupRegister();
                }
            });
            $('#<%=Button1.ClientID %>').click(function () {
                if ($('#<%=ValidationSummary1.ClientID %>').css('display') == 'none') {
                    //                if (frValidFechaDoc()) {
                    UpdateInsertData();
                    $(this).closest('.ui-dialog-content').dialog('close');
                    //                }
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
            /*excel*/
            $('#<%=ddlTipoCompra.ClientID %>').change(function () {
                $('#<%=ddlTipo.ClientID %>').empty();
                if ($('#<%=ddlTipoCompra.ClientID %>').val() == '01') {
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('01').html('FACTURA'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('03').html('BOLETA DE VENTA'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('04').html('LIQUIDACION DE COMPRA'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('05').html('BOLETO DE COMPANIAS DE AVIACION'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('06').html('CARTA DE PORTE AEREO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('07').html('NOTA DE CREDITO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('08').html('NOTA DE DEBITO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('10').html('RECIBO POR ARRENDAMIENTO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('11').html('POLIZA DE LA BOLSA DE VALORES'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('12').html('TICKET DE MAQUINA REGISTRADORA'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('13').html('DOCUMENTOS BANCA Y SEGUROS'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('14').html('RECIBOS POR SERVICIOS PUBLICOS'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('15').html('BOLETO EMITIDO POR EL TRANSPORTE URBANO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('16').html('BOLETO DE VIAJE-TRANSPORTE INTERPROVINCIAL'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('17').html('DOCUMENTOS EMITIDOS POR LA IGLESIA'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('18').html('DOCUMENTOS EMITIDOS POR LAS AFP Y EPS'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('21').html('CONOCIMIENTO DE EMBARQUE'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('22').html('COMPROBANTE POR OPERACIONES NO HABITUALES'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('23').html('POLIZA DE ADJUDICACION POR REMATE DE BIENES'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('24').html('CERTIFICADO DE PAGO REGALIAS-PERUPETRO S.A.'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('25').html('DOCUMENTO DE ATRIBUCION'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('26').html('RECIBO POR EL PAGO DE TARIFA POR USO DE AGUA SUPERFICIAL'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('27').html('SEGURO COMPLEMENTARIO DE TRABAJO DE RIESGO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('28').html('TARIFA UNIFICADA DE USO DE AEROPUERTO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('29').html('DOCUMENTOS EMITIDOS POR LA COFOPRI'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('30').html('DOC. EMIT. EMPRESAS ADQ. EN LOS SIST. DE PAGO MED. TARJETAS DE CRÉDITO O DÉBITO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('32').html('DOC. EMIT. EMP. RECAUDADORAS (GARANTIA DE RED PRINCIPAL)'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('34').html('DOCUMENTO DEL OPERADOR'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('35').html('DOCUMENTO DEL PARTICIPE'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('36').html('RECIBO DE DISTRIBUCION DE GAS NATURAL'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('37').html('DOC. CONCESIONARIOS DEL SERVICIO REVISIONES TECNICAS VEHICULARES'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('55').html('BOLETO DE VIAJE EMITIDO POR MEDIOS ELECTRÓNICOS PARA TRANSPORTE FERROVIARIO DE PASAJEROS (BVME)'));
                } else {
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('50').html('DECLARACION UNICA DE ADUANAS - IMPORTACION DEFINITIVA'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('52').html('DESPACHO SIMPLIFICADO - IMPORTACION SIMPLIFICADA'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('53').html('DECLARACION DE MENSAJERIA O COURIER'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('54').html('LIQUIDACION DE COBRANZA'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('91').html('COMPROBANTE DE NO DOMICILIADO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('97').html('NOTA DE CREDITO - NO DOMICILIADO'));
                    $('#<%=ddlTipo.ClientID %>').append($('<option></option>').val('98').html('NOTA DE DEBITO - NO DOMICILIADO'));
                }
            });
            $('#<%=ddlIndiceDetraccion.ClientID %>').change(function () {
                $('#<%=ddlTasaDetraccion.ClientID %>').empty();
                if ($('#<%=ddlIndiceDetraccion.ClientID %>').val() == '1') {
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('').html(''));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00101').html('Azucar                                                             / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00201').html('Arroz                                                              / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00301').html('Alcohol Etilico                                                    / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00401').html('Recursos Hidrobiologicos                                           / 09%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00402').html('Recursos Hidrobiologicos                                           / 15%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00501').html('Maiz Amarillo Duro                                                 / 07%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00502').html('Maiz Amarillo Duro                                                 / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00601').html('Algodon                                                            / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00602').html('Algodon                                                            / 11%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00603').html('Algodon                                                            / 15%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00701').html('Caña de Azucar                                                     / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00702').html('Caña de Azucar                                                     / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00801').html('Madera                                                             / 09%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00901').html('Arena y Piedra                                                     / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('00902').html('Arena y Piedra                                                     / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01001').html('Residuos-subproductos-desechos-recortes y desperdicios             / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01002').html('Residuos-subproductos-desechos-recortes y desperdicios             / 14%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01101').html('Bienes con renuncia a exoneración de IGV                           / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01201').html('Servicios de Intermediación Laboral Grav con el IGV y Terceriz.    / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01202').html('Servicios de Intermediación Laboral Grav con el IGV y Terceriz.    / 14%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01301').html('Animales Vivos                                                     / 04%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01302').html('Animales Vivos                                                     / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01401').html('Carnes y despojos comestibles                                      / 04%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01402').html('Carnes y despojos comestibles                                      / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01501').html('Abonos-cueros y pieles de origen animal                            / 04%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01502').html('Abonos-cueros y pieles de origen animal                            / 10%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01601').html('Aceite de pescado                                                  / 09%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01701').html('Harina - polvo y pellets de pescado - crust. Molus y demas inv. Ac./ 09%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01801').html('Embarcaciones Pesqueras                                            / 09%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01901').html('Arrendamiento de bienes Muebles                                    / 09%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('01902').html('Arrendamiento de bienes Muebles                                    / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02001').html('Mantenimiento y Reparación de Bienes Muebles                       / 09%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02101').html('Movimiento de carga                                                / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02102').html('Movimiento de carga                                                / 14%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02201').html('Otros servicios empresariales                                      / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02202').html('Otros servicios empresariales                                      / 14%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02301').html('Leche                                                              / 04%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02401').html('Comisión Mercantil                                                 / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02501').html('Fabricacion de bienes por encargo                                  / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02601').html('Servicio de Transporte de Personas                                 / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02701').html('Servicio de transportes de bienes                                  / 08%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('02702').html('Servicio de transportes de bienes                                  / 04%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03001').html('Contratos de construccion                                          / 05%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03101').html('Oro gravado con el IGV                                             / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03201').html('Paprika                                                            / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03301').html('Esparragos                                                         / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03401').html('Minerales Metalicos no Auriferos                                   / 12%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03501').html('Bienes exonerados del IGV                                          / 15%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03601').html('Oro y minerales metálicos exonerados IGV                           / 05%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03701').html('Demás servicios gravados con el IGV                                / 09%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03801').html('Espectáculos públicos no deportivos                                / 09%'));
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val('03901').html('Minerales No Metálicos                                             / 06%'));
                } else {
                    $('#<%=ddlTasaDetraccion.ClientID %>').append($('<option></option>').val(' ').html(' '));
                }
            });
            $('#<%=ddlTipoPersona.ClientID %>').change(function () {
                if ($('#<%=ddlTipoPersona.ClientID %>').val() != '01') {
                    $('#<%=txtApePaterno.ClientID %>,#<%=txtApeMaterno.ClientID %>,#<%=txtNombre1.ClientID %>,#<%=txtNombre2.ClientID %>').val('').attr('maxlength', '0');
                    $('#<%=txtRazonSocialCliente.ClientID %>').removeAttr('maxlength');
                } else {
                    $('#<%=txtApePaterno.ClientID %>,#<%=txtApeMaterno.ClientID %>,#<%=txtNombre1.ClientID %>,#<%=txtNombre2.ClientID %>').removeAttr('maxlength');
                    $('#<%=txtRazonSocialCliente.ClientID %>').val('').attr('maxlength', '0');
                }
            });
            if ($('#<%=chkRangeDate.ClientID %>').is(":checked")) {
                $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').attr('readonly', false);
                $('#<%=txtDesde.ClientID %>').select();
            } else {
                $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').attr('readonly', true);
                $('#<%=txtDesde.ClientID %>,#<%=txtHasta.ClientID %>').val('');
            }
        });    
    </script>
</asp:Content>
