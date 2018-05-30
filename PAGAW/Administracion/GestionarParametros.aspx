<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="GestionarParametros.aspx.cs" Inherits="PAGAW.Administracion.GestionarParametros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h3 class="panel-title">Gestionar Parámetros</h3>
        </div>
        <div class="panel-body">
            <div class="divRedondo">
                <div class="row" style="text-align: left; overflow-y: auto;">                     
                    <asp:Label runat="server"  ID="dangerAlert" class="alert alert-danger" Visible="false" Width="100%">
                        <strong><asp:Label runat="server" ID="alertDangerMessage"></asp:Label></strong>
                    </asp:Label>    
                    <br/><br/>
                    <div style="width: 30%;">
                        <asp:Label runat="server" Text="Restablecer parámetros" style="font-weight: bold;"/>
                        <asp:Button runat="server" Text="Restablecer" CssClass="btn btn-primary" OnClick="restablecerParametros_Click" style="float: right;"/>                 
                    </div>
                    <br/><br/>
                    <asp:Label runat="server" Text="Cantidad de registros a mostrar por tabla" style="font-weight: bold;"/>
                    <asp:TextBox ID="txtCantidadRegistros" min="1" runat="server" CssClass="form-control" TextMode="number" Width="30%" style="margin: 0 0;"/>   
                    <br/><br/>
                    <asp:Label runat="server" Text="Ruta de acceso pruebas" style="font-weight: bold;"/>
                    <asp:TextBox ID="txtRutaPruebas" runat="server" CssClass="form-control" Width="30%" style="margin: 0 0;" placeholder="Ingrese la dirección del servidor de pruebas"/>
                    <br/><br/>
                    <asp:Label runat="server" Text="Ruta de acceso producción" style="font-weight: bold;"/>
                    <asp:TextBox ID="txtRutaProduccion" runat="server" CssClass="form-control" style="margin: 0 0;" Width="30%" placeholder="Ingrese la dirección del servidor de producción"/>
                    <br/><br/>                 
                    <asp:Label runat="server" Text="Ruta de acceso archivos" style="font-weight: bold;"/>
                    <asp:TextBox ID="txtRutaArchivos" runat="server" CssClass="form-control" style="margin: 0 0;" Width="30%" placeholder="Ingrese la dirección del servidor de producción"/>
                    <br/><br/>
                    <asp:Button runat="server" Text="Modificar parámetros" CssClass="btn btn-primary" OnClick="modificarParametros_Click"/>
                    <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-default" OnClick="cancelarOperacion_Click" style="color: white; background-color:red;"/>
                    <br/><br/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFormInsertarAplicacion" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentFormActualizarAplicacion" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
