<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantReglas.aspx.cs" Inherits="SummitPDB.WebSite.GestionarReglas.MantReglas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<input type="button" id="btnMore" value="Nuevo" class="btnmantenimiento" style="width: 90px; margin-left:210px;" />
<asp:Button ClientIDMode="Static" ID="btnSearch" runat="server" Text="Buscar" CssClass="Hide" OnClick="btnSearch_Click" />

<center>


<asp:UpdatePanel ID="updCaracter" runat="server" >
<ContentTemplate>
    <asp:GridView ID="gvCaracter" runat="server" CssClass="grid" AutoGenerateColumns="False" Width="500px"
        ShowHeaderWhenEmpty="true" ShowFooter="True"
        OnRowDataBound="gvCaracter_RowDataBound"
        OnRowCommand="gvCaracter_RowCommand" 
        OnRowDeleting="gvCaracter_RowDeleting" DataKeyNames="codCaracter,caracter">
        <Columns>
            <asp:BoundField HeaderText="cod" DataField="codRegla" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" FooterStyle-CssClass="Hide" />
            <asp:TemplateField HeaderText="Caracter" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblCaracter" runat="server" Text='<%# Eval("caracter") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlCaracter" runat="server" style="width:120px;" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reemplazar por" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="90px">
                <ItemTemplate>
                    <asp:Label ID="lblEquivalente" runat="server" Text='<%# Eval("equivalence") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtEquivalente" runat="server" Width="90px"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Eliminar" OnClientClick="return confirm('Seguro de eliminar el registro?')"></asp:LinkButton>
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
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
</center>

    <%--Mantenimiento--%>
    <div id="popRegistro" class="bodyPopup" title="Nuevo Registro" style="display: none;">
        <table class="tblmantenimiento">
            <tr>
                <th>
                    Caracter:
                </th>
                <td width="10px" />
                <th>
                    Reemplazar por:
                </th>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlMantCaracter" runat="server" style="width:120px;" />
                </td>
                <td/>
                <td>
                    <asp:TextBox ID="txtMantEquivalente" runat="server" Width="90px"/>
                </td>
            </tr>
        </table>
        <br />
        <center>
            <input type="button" id="btnSave" value="Guardar" class="btnmantenimiento" style="font-family:Arial;font-size:11px;" />
            <input type="button" id="btnCancelR" value="Cancelar" class="btnmantenimiento" style="font-family:Arial;font-size:11px;" />
        </center>
        <input type="hidden" id="hdId" value="0" />
    </div>

    <%--JavaScript--%>
<script type="text/javascript">
    function UpdateInsertData() {
            $.ajax({
                url: '../GestionarReglas/MantReglas.aspx/InsertRegla',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "obj":
                    {
                        "codCaracter": $('#<%=ddlMantCaracter.ClientID %>').val(),
                        "equivalence": $.trim($('#<%=txtMantEquivalente.ClientID %>').val()),
                        
                    }
                }),
                success: function (data) {
                    if (data.d == "1") {
                        $('#<%=btnSearch.ClientID %>').click();
                        $("#popRegistro").closest('.ui-dialog-content').dialog('close');
                        frShowHideButtonNew(0);
                    } else
                        alert('No se realiso la insercion del registro');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        function frShowHideButtonNew(isTrue){
            if (isTrue==1)
                $("#btnMore").css('display','block');
            else
                $("#btnMore").css('display','none');
        }
    $(document).ready(function () {
        if ($('#<%=gvCaracter.ClientID %> tr').length==1)
            $("#btnMore").css('display','block');
        else
            $("#btnMore").css('display','none');
        $("#btnMore").click(function () {
            $('#<%=txtMantEquivalente.ClientID %>').val('');
            $("#popRegistro").dialog({
                autoOpen: true,
                modal: true,
                width: 260,
                height: 125,
                draggable: true,
                resizable: true
            });
            $("#btnSave,#btnCancel").css('font-family', 'Arial').css('font-size', '11px');
        });
        $("#btnSave").click(function () {
            UpdateInsertData();
        });
        $("#btnCancel").click(function () {
            $('#popRegistro').closest('.ui-dialog-content').dialog('close');
        });
    });    
    </script>
</asp:Content>
