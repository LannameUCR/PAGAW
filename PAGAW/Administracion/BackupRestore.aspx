<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="BackupRestore.aspx.cs" Inherits="PAGAW.Administracion.BackupRestore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h1 class="panel-title"><strong>Instrucciones para respaldo y restauración del sistema</strong></h1>
        </div>
        <div class="panel-body">
            <div class="divRedondo container-fluid>">
                <div class="row">
                    <%-- titulo accion--%>
                    <div class="col-md-12 col-xs-12 col-sm-12">
                        <center>

                        <h1><asp:Label ID="lblBackup" runat="server" Text="Instrucciones de backup"></asp:Label></h1>

                        <br />

                        <p class="textAlign">Si presiona el botón backup, el sistema realizara un respaldo de la base de datos y de los 
                           archivos del sistema, dicho backup será almacenado en el disco C del servidor, en el cual 
                           encontrara una carpeta llamada FullBackupPAGAW, en la cual encontrará diferentes archivos 
                           comprimidos con la información.
                        </p>

                        <br />
                        <br />

                        <h1><asp:Label ID="lblRestore" runat="server" Text="Instrucciones de restore"></asp:Label></h1>

                        <br />

                        <p class="textAlign">Si presiona el botón restore, el sistema realizara una restauración de la base de datos y de los 
                           archivos del sistema, dicha restauración tomará los archivos de la carpeta FullBackupPAGAW almacenada en el disco C del servidor,
                           en la cual tomará los diferentes archivos comprimidos con la información y hará la respectiva restauración.
                        </p>
                        </center>
                    </div>
                    <%-- fin titulo accion --%>
                    <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                        <hr />
                    </div>

                    <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                        <h3><asp:Label ID="lblMenssage" runat="server" Text="Mensaje: "></asp:Label></h3>
                        <br />
                        <br />
                    </div>

                    <%-- campos a llenar --%>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group  col-lg-12">
                                    <asp:Button ID="btnBackup" runat="server" Text="Backup" CssClass="btn btn-primary" OnClick="btnBackup_Click" />
                                    <asp:Button ID="btnRestore" runat="server" Text="Restore" CssClass="btn btn-primary" OnClick="btnRestore_Click" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFormInsertarAplicacion" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentFormActualizarAplicacion" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
