<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tipo_Cambio.aspx.cs" Inherits="SummitPDB.WebSite.PDB.Tipo_Cambio" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style2
        {
            width: 9px;
        }
        .style3
        {
            height: 26px;
        }
        .tblmantenimiento
        {
            width: 301px;
            margin-left: 0px;
            height: 14px;
        }
        .style4
        {
            height: 26px;
            width: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Tipo de Cambio</h2>
    <Left>
        <p style="text-align: center;">
            <table class="tblmantenimiento">
                    <th class="style4">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Periodos Disponibles:
                    </th>
                    <th class="style3">
                        <asp:DropDownList ID="ddlPeriodos" runat="server" AutoPostBack="True" 
                            Height="19px" Width="123px" 
                            onselectedindexchanged="ddlPeriodos_SelectedIndexChanged" />
                    </th>
                </table>
        </p>
    </Left>
    <table>
        <tr>
            <td rowspan="4" valign="top" class="style2">
                &nbsp;</td>
            <td rowspan="4" valign="top">
                <div class="" style="width: 288px; height: 320px; overflow: auto;">
                    <asp:UpdatePanel ID="upRegistro" runat="server">
                <ContentTemplate>
                
                    <asp:GridView ID="gvHotels" runat="server" CssClass="grid" AutoGenerateColumns="False"
                         ShowHeaderWhenEmpty="True" 
                        AllowPaging="False" PageSize="12" Width="286px" >
                        <Columns>
                            <asp:BoundField HeaderText="Fecha" DataField="Fecha_TC">
                                <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                <ItemStyle HorizontalAlign="Left" CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Promedio Ponderado Compra" 
                                DataField="PromPonderado_Compra_TC">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Promedio Ponderado Venta" 
                                DataField="PromPonderado_Venta_TC">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
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
            <td valign="top" rowspan="4">
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btnmantenimiento"
                    Width="110px" onclick="btnSearch_Click" Visible="False"/>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        function ValidNum(e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return ((tecla > 47 && tecla < 58) || tecla == 46);
        }
    </script>
    
    
    <script type="text/javascript">
        function ValidText(e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return ((tecla > 64 && tecla < 123) || tecla == 46);
        }
    </script>

</asp:Content>
