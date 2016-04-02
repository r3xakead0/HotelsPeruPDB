<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenimiento_Pre_Cierre_Periodos.aspx.cs" Inherits="SummitPDB.WebSite.GestionarPeriodos.Mantenimiento_Pre_Cierre_Periodos" %>
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
        .style5
        {
            width: 12px;
            height: 35px;
        }
        .style7
        {
            width: 268435456px;
        }
        .style9
        {
            width: 285px;
        }
        .style10
        {
            width: 12px;
        }
        .style11
        {
            width: 68px;
        }
        .style12
        {
            width: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Mantenimiento pre-Cierre Periodos</h2>
    <table border="0" class="tblmantenimiento">
    <tr>
    <th class="style10">&nbsp;</th>
    <th>&nbsp;</th>
    <th>Año:</th>
    <th class="style2">
        <asp:DropDownList ID="Cmb_Ano" runat="server"  Width="87px" AutoPostBack="True" 
            onselectedindexchanged="Cmb_Ano_SelectedIndexChanged">
        </asp:DropDownList>
        </th>
    <th class="style3">
        <asp:Button ID="Btn_Año" runat="server" CssClass="btnmantenimiento" 
            Text="Buscar" onclick="Btn_Año_Click" Visible="False" />
        </th>
    <td class="style9">
        Sucursal:<asp:Label ID="Lbl_Sucursal" runat="server" Text="Label"></asp:Label>
        </td>
    <td class="style12">
        </td>
    <td class="style11">
        &nbsp;</td>
    <td>
                &nbsp;</td>
    </tr>
    <tr>
    <th class="style10">&nbsp;</th>
    <th rowspan="3">
        &nbsp;</th>
    <th colspan="4" rowspan="3">
        <asp:GridView ID="Grilla_Periodos" runat="server"
         AutoGenerateColumns="False"  AutoGenerateSelectButton="False"
            Width="325px"  
          onrowdatabound="Grilla_Periodos_RowDataBound" >
            <Columns>
                <asp:BoundField DataField="codPeriodo" HeaderText="Codigo" Visible="False" />
                <asp:BoundField DataField="anioProces" HeaderText="Año" Visible="False" />
                <asp:BoundField DataField="descPeriodo" HeaderText="Descripcion" />
                <asp:BoundField DataField="codEstado" HeaderText="Cod_Estado" Visible="False" />
                <asp:BoundField DataField="mes" HeaderText="Mes" Visible="False" />
                <asp:BoundField DataField="descripcion" HeaderText="Estado" />
              <asp:TemplateField HeaderText="Cambiar Estado a"><ItemTemplate>
              <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("codEstado") %>' Visible = "False" />
              <asp:Label ID="lblCodPeriodo" runat="server" Text='<%# Eval("codPeriodo") %>' Visible = "True" />
              
            <asp:DropDownList ID="ddlCountries" runat="server" >
                </asp:DropDownList>
                
</ItemTemplate>
</asp:TemplateField>
            </Columns>
             <Columns>                

        </Columns>
            <SelectedRowStyle BorderStyle="Solid" />
        </asp:GridView>
        </th>
    <th colspan="3" rowspan="3">
        
        &nbsp;</th>
    </tr>
    <tr>
    <th class="style10">&nbsp;</th>
    </tr>
    <tr>
    <th class="style5"></th>
    </tr>
    <tr>
    <th class="style10">
        &nbsp;</th>
    <th>
        &nbsp;</th>
        <td>
        <asp:Button ID="Btn_Guardar" runat="server" Text="Guardar"  
            CssClass="btnmantenimiento" onclick="Btn_Guardar_Click" 
/>
                </td>
        <td class="style2">
                <asp:Label ID="Lbl_Mensaje" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
    <th colspan="5">
        &nbsp;</th>
    <th class="style7">
        &nbsp;</th>
    </tr>
    </table>
    
</asp:Content>
