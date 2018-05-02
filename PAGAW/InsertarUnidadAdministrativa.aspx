<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="InsertarUnidadAdministrativa.aspx.cs" Inherits="PAGAW.InsertarUnidadAdministrativa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h3 class="panel-title">Agregar una nueva Unidad Administrativa</h3>
        </div>
        <div class="panel-body">
            <div class="divRedondo">
                <div class="row" style="text-align: center; overflow-y: auto;">                          
                    <asp:Label runat="server"  ID="dangerAlert" class="alert alert-danger" Visible="false" Width="100%">
                        <strong><asp:Label runat="server" ID="alertDangerMessage"></asp:Label></strong>
                    </asp:Label>                            
                    <asp:Label runat="server" Text="Nombre" style="font-weight: bold;"/>
                    <asp:TextBox ID="uaNombre" runat="server" CssClass="form-control" Width="30%" style="margin: 0 auto;" placeholder="Nombre unidad administrativa"/>   
                    <br/><br/>
                    <asp:Label runat="server" Text="Descripción corta" style="font-weight: bold;"/>
                    <asp:TextBox ID="uaDescCorta" runat="server" CssClass="form-control" Width="30%" style="margin: 0 auto;" placeholder="Descripción corta"/>
                    <br/><br/>
                    <asp:Label runat="server" Text="Descripción larga" style="font-weight: bold;"/>
                    <asp:TextBox ID="uaDescLarga" runat="server" TextMode="MultiLine" Rows="5" style="margin: 0 auto;" CssClass="form-control" Width="30%" placeholder="Descripción larga"/>
                    <br/><br/>
                    <asp:Button runat="server" Text="Agregar unidad" CssClass="btn btn-primary" OnClick="agregarUnidad_Click"/>
                    <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-default" OnClick="cancelarOperacion_Click" style="color: white; background-color:red;"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
