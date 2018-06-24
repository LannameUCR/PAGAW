<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="Ayuda.aspx.cs" Inherits="PAGAW.Ayuda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="divRedondo">
        <div class="row">
            <div class="panel-body">
                <label for="lblUsuario">Usuario: </label>
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                    <asp:TextBox ID="txtUsuario"  runat="server" CssClass="form-control chat-input"></asp:TextBox>

                </div>

                <br />
                <label for="lblAsunto">Asunto </label>
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                    <asp:TextBox ID="txtAsunto"  runat="server" CssClass="form-control chat-input"></asp:TextBox>

                </div>

                    <br />
                    <label for="lblMensaje">Mensaje </label>
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-comment"></i></span>
                    <asp:TextBox ID="txtMensaje" runat="server" CssClass=" form-control chat-input" TextMode="MultiLine"></asp:TextBox>
                               
                </div>
                <br />
                <div style="text-align: center;">

                    <asp:Button ID="btnEnviarCorreo" runat="server" Text="Contactar Administrador" CssClass="btn btn-primary btn-md" OnClick="btnEnviarCorreo_Click" />
                                    
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
