<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="EliminarAplicacion.aspx.cs" Inherits="PAGAW.Administracion.EliminarAplicacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h3 class="panel-title">Eliminar Aplicacion</h3>
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
                                <div class="form-group">
                                    <asp:Label ID="lblnombreApp" runat="server" Text="Nombre: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtnombreApp" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lbllServidor" runat="server" Text="Servidor: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtServidor" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblVersion" runat="server" Text="Versión: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtVersion" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblCOdigo" runat="server" Text="Código Fuente: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtCodigo" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblPaquete" runat="server" Text="Paquete Instalación: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtPaquete" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblUrl" runat="server" Text="URL: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtUrl" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblDesCorta" runat="server" Text="Descripción corta: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtdes_corta" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lbldesc" runat="server" Text="Descripción larga: " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                                    <asp:TextBox class="form-control" ID="txtdesc" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group  col-lg-12">
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-success" OnClick="btnEliminar_Click" />
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
