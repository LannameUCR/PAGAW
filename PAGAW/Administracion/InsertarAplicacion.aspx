<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="InsertarAplicacion.aspx.cs" Inherits="PAGAW.Administracion.InsertarAplicacion" %>
<asp:Content ID="ContentFormInsertarAplicacion" ContentPlaceHolderID="ContentFormInsertarAplicacion" runat="server">
    <div class="divRedondo col-sm-6">
    
            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-2 col-form-label" for="Nombre Largo">Nombre largo</asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNombreLargo" class="form-control" placeholder="Nombre largo" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label runat="server" class="col-sm-2 col-form-label" for="selec_unidad_administrativa">Nombre corto</asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNombreCorto" runat="server" class="form-control" placeholder="Nombre corto"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="Descripcion_larga" class="col-sm-2 col-form-label">Descripcion larga</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDescripcion_larga" class="form-control" runat="server" placeholder="Descripcion larga" cols="20" rows="3" ></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="Descripcion_corta" class="col-sm-2 col-form-label">Descripcion corta</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDescripcion_corta" class="form-control" runat="server" placeholder="Descripcion corta" cols="20" rows="3" ></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="Version_aplicacion" class="col-sm-2 col-form-label">Versión de la aplicación</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtVersion_aplicacion" runat="server" placeholder="Versión de la aplicación"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="CodZip" class="col-sm-2 col-form-label">Código ZIP</label>
                <div class="col-sm-10">
                    <div class="custom-file">
                        <asp:FileUpload ID="fupCodigoZip" class="custom-file-input" runat="server" />
                        <label class="custom-file-label" for="customFile">Código ZIP</label>
                    </div>
                </div>
            </div>

            <div class="form-group row">
                <label for="CodFuente" class="col-sm-2 col-form-label">Código fuente</label>
                <div class="col-sm-10">
                    <div class="custom-file">
                        <asp:FileUpload ID="fuCodigoFuente" class="custom-file-input"  runat="server" />
                        <label class="custom-file-label" for="customFile">Código fuente</label>
                    </div>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="Url_servidor" class="col-sm-2 col-form-label">Url servidor</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUrlServidor" class="form-control" runat="server" placeholder="Url servidor"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="Tipo_servidor" class="col-sm-2 col-form-label">Tipo servidor</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlTipoServidor" runat="server">
                        <asp:ListItem Text="Producción" Value="Producción" />
                        <asp:ListItem Text="Pruebas" Value="Pruebas" />
                    </asp:DropDownList>

                </div>
            </div>

            <div class="form-group row">
                <label for="imagen" class="col-sm-2 col-form-label">Imágen</label>
                <div class="col-sm-10">
                    <div class="custom-file">
                        <asp:FileUpload ID="fuImagen" runat="server" />
                    </div>
                </div>
            </div>           

            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Button ID="BtnInsertar" class="btn btn-primary" runat="server" Text="Insertar aplicación" OnClick="BtnInsertar_Click" />
                    <asp:Button ID="btnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
