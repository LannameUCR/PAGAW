<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="InsertarAplicacion.aspx.cs" Inherits="PAGAW.Administracion.InsertarAplicacion" %>
<asp:Content ID="ContentFormInsertarAplicacion" ContentPlaceHolderID="ContentFormInsertarAplicacion" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h3 class="panel-title">Insertar nueva Aplicación</h3>
        </div>
        <div class="panel-body">
            <div class="divRedondo">
                <br />
                <div class="form-group row">
                    <label for="Descripcion_larga" class="col-sm-2 col-form-label">Nombre largo</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNombreLargo" class="form-control" placeholder="Nombre largo" Width="30%" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Descripcion_larga" class="col-sm-2 col-form-label">Nombre corto</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNombreCorto" runat="server" class="form-control" Width="30%" placeholder="Nombre corto"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Descripcion_larga" class="col-sm-2 col-form-label">Descripcion larga</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescripcion_larga" class="form-control" runat="server" Width="30%" placeholder="Descripcion larga" cols="20" rows="3" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Descripcion_corta" class="col-sm-2 col-form-label">Descripcion corta</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescripcion_corta" class="form-control" runat="server" Width="30%" placeholder="Descripcion corta" cols="20" rows="3" ></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group row">
                    <label for="Tipo_servidor" class="col-sm-2 col-form-label">Unidad Administrativa</label>
                    <div class="col-sm-10">
                       <asp:DropDownList  style="width:30%;" ID="dpUnidadAdministrativa" CssClass="form-control" runat="server" OnSelectedIndexChanged="dpUnidadAdministrativa_SelectedIndexChanged"></asp:DropDownList>
                </div>
                        
                </div>
                <div class="form-group row">
                    <label for="Version_aplicacion" class="col-sm-2 col-form-label">Versión de la aplicación</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtVersion_aplicacion" runat="server" class="form-control" Width="30%" placeholder="Versión de la aplicación"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row" >
                    <label for="CodZip" class="col-sm-2 col-form-label">Código ZIP</label>
                    <div class="col-sm-10">
                        <div class="custom-file" style="width:30%;">
                            <asp:FileUpload ID="fupCodigoZip" class="custom-file-input" runat="server"/>
                            <label class="custom-file-label" for="customFile">Código ZIP</label>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CodFuente" class="col-sm-2 col-form-label">Código fuente</label>
                    <div class="col-sm-10">
                        <div class="custom-file" style="width:30%;">
                            <asp:FileUpload ID="fuCodigoFuente" class="custom-file-input"  runat="server"/>
                            <label class="custom-file-label" for="customFile">Código fuente</label>
                        </div>
                    </div>
                </div>            
                <div class="form-group row">
                    <label for="Url_servidor" class="col-sm-2 col-form-label">Url servidor</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtUrlServidor" class="form-control" runat="server" placeholder="Url servidor" Width="30%"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="Tipo_servidor" class="col-sm-2 col-form-label">Tipo servidor</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlTipoServidor" runat="server" CssClass="form-control" Width="30%">
                            <asp:ListItem Text="Producción" Value="Produccion" />
                            <asp:ListItem Text="Pruebas" Value="Pruebas" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="CodFuente" class="col-sm-2 col-form-label">Imagen</label>
                    <div class="col-sm-10">
                        <div class="custom-file" style="width:30%;">
                            <asp:FileUpload ID="fuImagen" class="custom-file-input"  runat="server"/>
                            <label class="custom-file-label" for="customFile">Imagen</label>
                        </div>
                    </div>
                </div>                       
                <br />
                <!--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>-->
                <div class="form-group row">
                    <div class="col-sm-10">
                        <asp:Button ID="BtnInsertar" class="btn btn-primary" runat="server" Text="Insertar aplicación" OnClick="BtnInsertar_Click" />
                        <asp:Button ID="btnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    
    <script type="text/javascript">

        $(document).ready(function () {

            $.ajax({
                url: 'aplicaciones.asmx/getUnidadesAdministrativas',
                type: 'POST',
                dataType: 'text',
                //data: "{'eventt':'" + request.term + "'}",
                beforeSend: function () {

                }
            })
            .done(function (resp) {
                /*Se transforma los datos que se obtienen en un objeto json*/
                var unidadAdm = JSON.parse(resp);

                var totalRegistros = unidadAdm.iTotalDisplayRecords;
                var select = document.getElementById("selec_unidad_administrativa");
                var option = null;

                for (var i = 0; i < totalRegistros; i++) {
                    option = document.createElement("option");
                    option.text = unidadAdm.aaData[i].nombre_ua;
                    option.value = unidadAdm.aaData[i].id_ua;
                    select.add(option);
                }

            }).fail(function (error, textStatus, errorThrown) {
                console.log(error.status); //Check console for output
            });

            //alert(document.getElementById("selc_unidad_administrativa").value)
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
