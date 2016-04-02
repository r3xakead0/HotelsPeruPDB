<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaracteresAceptados.aspx.cs" Inherits="SummitPDB.WebSite.GestionarReglas.CaracteresAceptados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<center>
<%--<asp:Button ID="btnGuardar" runat="server" text="Grabar" CssClass="btnmantenimiento" style="padding:5px;" />--%>
<asp:UpdatePanel ID="updCaracter" runat="server" >
<ContentTemplate>
    <asp:GridView ID="gvCaracter" runat="server" CssClass="grid" AutoGenerateColumns="False" Width="500px"
        ShowHeaderWhenEmpty="true" ShowFooter="True"
        OnRowDataBound="gvCaracter_RowDataBound"
        OnRowCommand="gvCaracter_RowCommand" 
        OnRowDeleting="gvCaracter_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="cod" DataField="codCaracter" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" FooterStyle-CssClass="Hide" />
            <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="90px">
                <ItemTemplate>
                    <asp:Label ID="lblCaracter" runat="server" Text='<%# Eval("caracter") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtCaracter" runat="server" Width="90px"/>
                    <%--<asp:RequiredFieldValidator ID="rfvCaracter" ValidationGroup="Insert" runat="server" ControlToValidate="txtCaracter" ErrorMessage="Please Enter Name" ToolTip="Please Enter Name" SetFocusOnError="true" ForeColor="Red" Text="*"/>--%>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Caracter" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblTipo" runat="server" Text='<%# Eval("tipo") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlTipoCaracter" runat="server" style="width:120px;">
                        <asp:ListItem Text="Alfabetico" Value="Alfabetico" />
                        <asp:ListItem Text="Númerico" Value="Numerico" />
                        <asp:ListItem Text="Especial" Value="Especial" />
                    </asp:DropDownList>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Eliminar" OnClientClick="return confirm('Seguro de eliminar registro?')"></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert"
                        ValidationGroup="Insert" Text="Insertar"/>
                    <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="Insert" Enabled="true" HeaderText="Validation..." />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        
    </asp:GridView>
</ContentTemplate>
<%--<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
</Triggers>--%>
</asp:UpdatePanel>
</center>
<script type="text/javascript">
//    $(document).ready(function () {
//        $('#<%=gvCaracter.ClientID %>').Scrollable();
//    });
</script>
</asp:Content>
