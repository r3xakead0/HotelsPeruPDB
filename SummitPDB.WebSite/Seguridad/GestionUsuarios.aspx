<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="SummitPDB.WebSite.Seguridad.GestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Gestion de Usuarios
    </h2>
    <table>
        <tr>
            <th>
                Usuario:
            </th>
            <td>
                <asp:TextBox ID="txtUsuarioBuscado" runat="server" />
            </td>
            <td>
                <asp:Button ID="btnBuscarUsuario" runat="server" Text="Buscar" CssClass="btnmantenimiento"
                    OnClick="btnBuscarUsuario_Click" />
            </td>
            <td>
                <input type="button" id="btnNuevo" value="Nuevo" class="btnmantenimiento" />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="updGvUsers" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                OnRowDataBound="gvUsers_RowDataBound" CssClass="grid">
                <Columns>
                    <asp:BoundField HeaderText="UserCod" DataField="UserCod" HeaderStyle-CssClass="Hide"
                        ItemStyle-CssClass="Hide" />
                    <asp:BoundField HeaderText="Nombre" DataField="fullName">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="400px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <span style="cursor: pointer; color: Blue; padding-left: 10px; padding-right: 10px;">
                                Editar</span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <span style="cursor: pointer; color: Blue; padding-left: 10px; padding-right: 10px;">
                                Eliminar</span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="" DataField="firstName">
                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="" DataField="lastName">
                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="" DataField="lastName2">
                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="" DataField="codLocal">
                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="" DataField="codRol">
                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Hide" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="" DataField="UserName">
                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                        <ItemStyle HorizontalAlign="Left" CssClass="Hide" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="" DataField="UserPassword">
                        <HeaderStyle HorizontalAlign="Left" CssClass="Hide" />
                        <ItemStyle HorizontalAlign="Left" CssClass="Hide" />
                    </asp:BoundField>
                </Columns>
                <RowStyle CssClass="altrowstyle" />
                <SelectedRowStyle CssClass="SelectedRow" />
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscarUsuario" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="popRegistro" title="Ingresar Usuario" style="display: none;">
        <table id="popupEdit" border="0" class="tblmantenimiento">
            <tr>
                <th>
                    Nombres:
                </th>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    Ape. Paterno:
                </th>
                <td>
                    <asp:TextBox ID="txtApePaterno" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    Ape. Materno:
                </th>
                <td>
                    <asp:TextBox ID="txtApeMaterno" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    Local:
                </th>
                <td>
                    <asp:DropDownList ID="ddlLocales" runat="server" AutoPostBack="false" />
                </td>
            </tr>
            <tr>
                <th>
                    Usuario:
                </th>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    Constrase&ntilde;a:
                </th>
                <td>
                    <asp:TextBox ID="txtClave" runat="server" />
                </td>
            </tr>
            <tr>
                <th colspan="2">
                    <input type="radio" id="rdoUsuario" name="codRol" value="1">
                    <label for="rdoUsuario">
                        Usuario</label>
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <input type="radio" id="rdoAdmLocal" name="codRol" value="2">
                    <label for="rdoAdmLocal">
                        Administrador Local</label>
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <input type="radio" id="rdoAdmCorporativo" name="codRol" value="3">
                    <label for="rdoAdmCorporativo">
                        Administrador Coorporativo</label>
                </th>
            </tr>
        </table>
        <center>
            <input type="button" id="btnSaveRegister" value="Guardar" class="btnmantenimiento" />
            <input type="button" id="btnCancelRegister" value="Cancelar" class="btnmantenimiento" />
        </center>
        <input type="hidden" id="hId" value="0" />
    </div>
    <script type="text/javascript">
        function UpdateInsertData() {
            $.ajax({
                url: '../Seguridad/GestionUsuarios.aspx/InsUpd',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: JSON.stringify({
                    "objBE":
                    {
                        "codUser": $('#hId').val(),
                        "firstName": $('#<%=txtNombre.ClientID %>').val(),
                        "lastName": $('#<%=txtApePaterno.ClientID %>').val(),
                        "lastName2": $('#<%=txtApeMaterno.ClientID %>').val(),
                        "codLocal": $('#<%=ddlLocales.ClientID %>').val(),
                        "UserName": $('#<%=txtUsuario.ClientID %>').val(),
                        "UserPassword": $('#<%=txtClave.ClientID %>').val(),
                        "codRol": $("input:radio[name='codRol']:checked").val()
                    }
                }),
                success: function (data) {
                    if (data.d == "1") {
                        $('#<%=btnBuscarUsuario.ClientID %>').click();
                        alert('Se ' + ($('#hId').val() == '0' ? 'ingreso' : 'actualizo') + ' el registro correctamente')
                    } else
                        alert('No se realiso la insercion del registro');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        }
        function DeleteData() {
            $('#hId').val($($('#<%=gvUsers.ClientID %>').find('.SelectedRow td')[0]).text());
            if (confirm('Esta seguro de eliminar el registro?')) {
                $.ajax({
                    url: '../Seguridad/GestionUsuarios.aspx/Del',
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    data: JSON.stringify({
                        "objBE":
                    {
                        "codUser": $('#hId').val()
                    }
                    }),
                    success: function (data) {
                        if (data.d == "1") {
                            $('#<%=btnBuscarUsuario.ClientID %>').click();
                            alert('Se elimino el registro correctamente');
                        } else
                            alert('No se realiso la eliminacion del registro');
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            } else
                $('#hId').val('0');
        }
        function ClearPopupRegister() {
            $('#hId').val('0');
            $('#<%=txtNombre.ClientID %>').val('');
            $('#<%=txtApePaterno.ClientID %>').val('');
            $('#<%=txtApeMaterno.ClientID %>').val('');
            $('#<%=ddlLocales.ClientID %>').val('');
            $('#<%=txtUsuario.ClientID %>').val('');
            $('#<%=txtClave.ClientID %>').val('');
            $('#rdoAdmLocal').attr('checked', false);
            $('#rdoAdmCorporativo').attr('checked', false);
            $('#rdoUsuario').attr('checked', true);
        }
        function frEditRow() {
            $("#popRegistro").dialog({
                autoOpen: true,
                modal: true,
                width: 460,
                draggable: true,
                resizable: true
            });
            $("#popRegistro").prev().find('span').text('Editar Registro');
            $('#hId').val($($('#<%=gvUsers.ClientID %>').find('.SelectedRow td')[0]).text());
            $('#<%=txtNombre.ClientID %>').val($($('#<%=gvUsers.ClientID %>').find('.SelectedRow td')[4]).text());
            $('#<%=txtApePaterno.ClientID %>').val($($('#<%=gvUsers.ClientID %>').find('.SelectedRow td')[5]).text());
            $('#<%=txtApeMaterno.ClientID %>').val($($('#<%=gvUsers.ClientID %>').find('.SelectedRow td')[6]).text());
            $('#<%=ddlLocales.ClientID %>').val($($('#<%=gvUsers.ClientID %>').find('.SelectedRow td')[7]).text());
            $('input:radio[name="codRol"]').filter('[value="' + $($('#<%=gvUsers.ClientID %>').find('.SelectedRow td')[8]).text() + '"]').attr('checked', true);
            $('#<%=txtUsuario.ClientID %>').val($($('#<%=gvUsers.ClientID %>').find('.SelectedRow td')[9]).text());
            $('#<%=txtClave.ClientID %>').val($($('#<%=gvUsers.ClientID %>').find('.SelectedRow td')[10]).text());
        }
        $(document).ready(function () {
            $("#btnNuevo").click(function () {
                $("#popRegistro").dialog({
                    autoOpen: true,
                    modal: true,
                    width: 460,
                    draggable: true,
                    resizable: true
                });
                $("#popRegistro").prev().find('span').text('Ingresar Usuario');
                ClearPopupRegister();
            });
            $("#btnSaveRegister").click(function () {
                UpdateInsertData();
                $(this).closest('.ui-dialog-content').dialog('close');
            });
            $("#btnCancelRegister").click(function () {
                $(this).closest('.ui-dialog-content').dialog('close');
            });
        });    
    </script>
</asp:Content>
