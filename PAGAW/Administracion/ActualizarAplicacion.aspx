﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="ActualizarAplicacion.aspx.cs" Inherits="PAGAW.Administracion.ActualizarAplicacion" %>
<asp:Content ID="ContentFormActualizarAplicacion" ContentPlaceHolderID="ContentFormActualizarAplicacion" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h3 class="panel-title">Modificar Aplicación</h3>
        </div>
        <div class="panel-body">
            <div class="divRedondo" >  
                <asp:TextBox ID="txtIdApp" class="form-control" placeholder="Nombre largo" runat="server" CssClass="hidden"></asp:TextBox>  
                <div class="form-group row" >
                    <label runat="server" class="col-sm-2 col-form-label">Nombre largo</label>
                    <div class="col-sm-10" style="width:30%; " >
                        <asp:TextBox ID="txtNombreLargo" class="form-control" placeholder="Nombre largo" runat="server"></asp:TextBox>
                    </div>  
                </div>
                <div class="form-group row">
                    <label runat="server" class="col-sm-2 col-form-label">Nombre corto</label>
                    <div class="col-sm-10" style="width:30%;">
                        <asp:TextBox ID="txtNombreCorto" runat="server" class="form-control" placeholder="Nombre corto"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Descripcion_larga" class="col-sm-2 col-form-label">Descripcion larga</label>
                    <div class="col-sm-10" style="width:30%;">
                        <asp:TextBox ID="txtDescripcion_larga" class="form-control" runat="server" placeholder="Descripcion larga" cols="20" rows="3" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Descripcion_corta" class="col-sm-2 col-form-label">Descripcion corta</label>
                    <div class="col-sm-10" style="width:30%;">
                        <asp:TextBox ID="txtDescripcion_corta" class="form-control" runat="server" placeholder="Descripcion corta" cols="20" rows="3" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Version_aplicacion" class="col-sm-2 col-form-label">Versión de la aplicación</label>
                    <div class="col-sm-10" style="width:30%;">
                        <asp:TextBox ID="txtVersion_aplicacion" CssClass="form-control" runat="server" placeholder="Versión de la aplicación"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CodZip" class="col-sm-2 col-form-label">Código ZIP</label>
                    <div class="col-sm-10">
                        <div class="custom-file" style="width:30%;">
                            <asp:FileUpload ID="fupCodigoZip" class="custom-file-input" runat="server" />
                            <label class="custom-file-label" for="customFile">Código ZIP</label>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CodFuente" class="col-sm-2 col-form-label">Código fuente</label>
                    <div class="col-sm-10">
                        <div class="custom-file" style="width:30%;">
                            <asp:FileUpload ID="fuCodigoFuente" class="custom-file-input"  runat="server" />
                            <label class="custom-file-label" for="customFile">Código fuente</label>
                        </div>
                    </div>
                </div>            
                <div class="form-group row">
                    <label for="Url_servidor" class="col-sm-2 col-form-label">Url servidor</label>
                    <div class="col-sm-10" style="width:30%;">
                        <asp:TextBox ID="txtUrlServidor" class="form-control" runat="server" placeholder="Url servidor"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Tipo_servidor" class="col-sm-2 col-form-label">Tipo servidor</label>
                    <div class="col-sm-10" style="width:30%;">
                        <asp:DropDownList ID="ddlTipoServidor" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Producción" Value="Producción" />
                            <asp:ListItem Text="Pruebas" Value="Pruebas" />
                        </asp:DropDownList>
                     </div>
                </div>
                <div class="form-group row">
                    <label for="imagen" class="col-sm-2 col-form-label">Imágen</label>
                    <div class="col-sm-10">
                        <div class="custom-file" style="width:30%;">
                            <asp:FileUpload ID="fuImagen" runat="server" />
                        </div>
                    </div>
                </div>           
                <div class="form-group row">
                    <div class="col-sm-10">
                        <asp:Button ID="btnActualizar" class="btn btn-primary"  runat="server" Text="Actualizar aplicación" OnClick="btnActualizar_Click" />
                        <asp:Button ID="btnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFormInsertarAplicacion" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
