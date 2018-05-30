<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="InsertarDatoBitacoraVersiones.aspx.cs" Inherits="PAGAW.Administracion.InsertarDatoBitacoraVersiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h3 class="panel-title">Insertar dato en bitácora de versiones</h3>
        </div>
        <div class="panel-body">
            <div class="divRedondo" >    
                <div class="form-group row" >
                    <label runat="server" class="col-sm-2 col-form-label">Nombre usuario</label>
                    <div class="col-sm-10" style="width:30%; " >
                        <asp:TextBox ID="txtNombreUsuario" class="form-control" placeholder="Nombre usuario" runat="server"></asp:TextBox>
                    </div>  
                </div>
                <div class="form-group row">
                    <label runat="server" class="col-sm-2 col-form-label">Fecha</label>
                    <div class="col-sm-10" style="width:30%;">
                        <asp:calendar ID="fecha" runat="server"></asp:calendar>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Descripcion" class="col-sm-2 col-form-label">Descripcion de la operación</label>
                    <div class="col-sm-10" style="width:30%;">
                        <asp:TextBox ID="txtDescripcion" class="form-control" runat="server" placeholder="Descripcion" cols="20" rows="3" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-10">
                        <asp:button ID="btnGuardar" class="btn btn-primary" runat="server" text="Guadar dato en bitácora" OnClick="btnGuardar_Click" />
                    </div>
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
