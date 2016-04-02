<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Mantenimiento_Periodos.aspx.cs" Inherits="SummitPDB.WebSite.GestionarPeriodos.Mantenimiento_Periodos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 8px;
        }
        #Select1
        {
            width: 127px;
        }
        .style3
        {
            width: 31px;
        }
        .style7
        {
            width: 268435456px;
            height: 21px;
        }
        .style9
        {
            width: 117px;
        }
        .style12
        {
        }
        .style15
        {
            height: 21px;
        }
        .style16
        {
            height: 21px;
        }
        .style17
        {
            width: 268435456px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Mantenimiento Periodos</h2>
    <table border="0" class="tblmantenimiento">
        <tr>
            <th>
                &nbsp;
            </th>
            <th>
                Año:
            </th>
            <th class="style2">
                <asp:DropDownList ID="Cmb_Ano" runat="server" Width="87px" AutoPostBack="True" OnSelectedIndexChanged="Cmb_Ano_SelectedIndexChanged">
                </asp:DropDownList>
            </th>
            <th class="style3">
                <asp:Button ID="Btn_Año" runat="server" CssClass="btnmantenimiento" Text="Buscar"
                    OnClick="Btn_Año_Click" Visible="False" />
            </th>
            <td class="style9">
                <asp:Button ID="Btn_Proceso" runat="server" Text="Crear Periodos" CssClass="btnmantenimiento"
                    OnClick="Btn_Proceso_Click" Width="99px" Height="19px" />
            </td>
            <td class="style12" colspan="3">
                Mes:
                <asp:DropDownList ID="Cmb_Meses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Cmb_Meses_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style17">
                <asp:Button ID="Btn_Buscar" CssClass="btnmantenimiento" runat="server" Text="Buscar"
                    Width="96px" OnClick="Btn_Buscar_Click" Visible="False" />
            </td>
        </tr>
        <tr>
            <th rowspan="2">
                &nbsp;
            </th>
            <th colspan="4" rowspan="2">
                <asp:GridView ID="Grilla_Periodos" runat="server" AutoGenerateColumns="False" Width="325px"
                    OnSelectedIndexChanging="Grilla_Periodos_SelectedIndexChanging" OnRowDataBound="Grilla_Periodos_RowDataBound"
                    Style="margin-top: 0px">
                    <Columns>
                        <asp:BoundField DataField="codPeriodo" HeaderText="Codigo" ControlStyle-BorderWidth="0"
                            Visible="False">
                            <ControlStyle BorderWidth="0px"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="anioProces" HeaderText="Año" Visible="False" />
                        <asp:BoundField DataField="descPeriodo" HeaderText="Descripcion" />
                        <asp:BoundField DataField="codEstado" HeaderText="Cod_Estado" Visible="False" />
                        <asp:BoundField DataField="mes" HeaderText="Mes" Visible="False" />
                        <asp:BoundField DataField="descripcion" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Edicion Estado">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("codEstado") %>' Visible="False" />
                                <asp:Label ID="lblCodPeriodo" runat="server" Text='<%# Eval("codPeriodo") %>' Visible="False" />
                                <asp:DropDownList ID="ddlCountries" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BorderStyle="Solid" />
                </asp:GridView>
            </th>
            <th colspan="4">
                <asp:GridView ID="Grid_Detalle" runat="server" AutoGenerateColumns="False" Height="26px"
                    Width="215px" OnRowDataBound="Grilla_Periodos_Hotel_RowDataBound" OnSelectedIndexChanged="Grid_Detalle_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Hotel" DataField="Hotel" />
                        <asp:BoundField HeaderText="Estado" DataField="descPeriodo" />
                        <asp:TemplateField HeaderText="Edicion Estado">
                            <ItemTemplate>
                                <asp:Label ID="lblCountry_Hotel" runat="server" Text='<%# Eval("codEstado") %>' Visible="false" />
                                <asp:Label ID="lblCodLocal_Hotel" runat="server" Text='<%# Eval("codLocal") %>' Visible="false" />
                                <asp:DropDownList ID="ddlCountries_Hotel" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="Btn_Guardar_Hotel" runat="server" CssClass="btnmantenimiento" Style="margin-top: 6px;"
                    Text="Guardar" OnClick="Btn_Guardar_Hotel_Click" />
            </th>
        </tr>
        <tr>
            <th colspan="2">
            </th>
            <th colspan="2">
            </th>
        </tr>
        <tr>
            <th class="style15">
            </th>
            <td class="style15">
                <asp:Button ID="Btn_Guardar" CssClass="btnmantenimiento" runat="server" Text="Guardar"
                    OnClick="Btn_Guardar_Click" />
            </td>
            <td class="style16" colspan="4">
                <asp:Label ID="Lbl_Mensaje_Proceso" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <th colspan="3" class="style15">
                &nbsp;
            </th>
            <td class="style15">
            </td>
            <th class="style7">
            </th>
        </tr>
    </table>
</asp:Content>
