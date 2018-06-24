<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="ActualizarBitacora.aspx.cs" Inherits="PAGAW.Administracion.ModificarBitacora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h3 class="panel-title">Actualizar Bitácora</h3>
        </div>
        <div class="panel-body">
            <div class="divRedondo container-fluid>">
                <div class="row">
                    <%-- titulo accion--%>
                    <div class="col-md-12 col-xs-12 col-sm-12">
                        <center>
                        <asp:Label ID="lblEliminar" runat="server" Text="Datos" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
                    </div>
                    <%-- fin titulo accion --%>
                    <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                        <hr />
                    </div>
                    <%-- campos a llenar --%>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtId" hidden runat="server"></asp:TextBox>
                                <div class="form-group">
                                    <asp:Label ID="lbllUsuario" runat="server" Text="Usuario: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtNombreUsuario" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblFechaOperacion" runat="server" Text="Fecha operación: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtFechaOperacion" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblDescripción" runat="server" Text="Descripción: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtDescripción" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>

                                <div class="form-group  col-lg-12">
                                    <asp:Button ID="btnEliminar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- fin campos a llenar --%>

                    <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                        <hr />
                    </div>

                    <%-- botones --%>
                    <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    </div>
                    <%-- fin botones --%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>