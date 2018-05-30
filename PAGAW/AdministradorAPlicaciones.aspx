<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="AdministradorAplicaciones.aspx.cs" Inherits="PAGAW.Administracion.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="cleartype" content="on" />
    <link href="Content/DataTables/datatables.min.css" rel="stylesheet" />


    <link href="css/Lanamme.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="Scripts/Table//responsive.bootstrap.min.css" rel="stylesheet" />


    <!-- Bootstrap -->
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap-dialog.css" rel="stylesheet" />

    <!--Dialogos de Mensaje ref:https://nakupanda.github.io/bootstrap3-dialog/#available-options -->
    <link href="css/bootstrap-dialog.css" rel="stylesheet" />


    <link href="Scripts/Table/bootstrap.min.css" rel="stylesheet" />
    <link href="Scripts/Table/datatables.min.css" rel="stylesheet" />

    <script src='<%=Page.ResolveUrl("~/Scripts/Table/dataTables.bootstrap.min.js") %>'></script>



    <%--

        <script src='<%=Page.ResolveUrl("~/Scripts/Table/jquery-1.12.4.js") %>'></script>
        <script src='<%=Page.ResolveUrl("~/Scripts/Table/jquery.dataTables.min.js") %>'></script>
        <script src='<%=Page.ResolveUrl("~/Scripts/Table/dataTables.bootstrap.min.js") %>'></script>
    
    <script src='<%=Page.ResolveUrl("~/Scripts/Table/dataTables.responsive.min.js") %>'></script>
    <script src='<%=Page.ResolveUrl("~/Scripts/Table/responsive.bootstrap.min.js") %>'></script>
    <link href="Scripts/Table/bootstrap.min.css" rel="stylesheet" />  
    <link href="Scripts/Table/responsive.bootstrap.min.css" rel="stylesheet" />
    --%>
    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h3 class="panel-title">Aplicaciones</h3>
        </div>
        <div class="panel-body">
            <div class="divRedondo">
                <div class="row">

                    <%-- Aqui agregamos los valores del objeto para que sea reconocibles --%>
                    <div class="col-md-12 col-xs-12 col-sm-12">
                        <center>
                            <asp:Label ID="lbl_Apps" runat="server" Font-Size="Large" ForeColor="Black"></asp:Label>
                        </center>
                    </div>
                    <%# Eval("nombre_largo_aplicacion") %>
                    <input type="hidden" id="hdIdApp" runat="server" />
                    <input type="hidden" id="hdIdActivo" runat="server" />                    
                    <input type="hidden" id="hdTipoServidor" runat="server" />
                    <%-- Fila para la busqueda en el footer --%>
                    <!--Tabla 1 -->
                    <div class="col-md-12 col-xs-12 col-sm-12" style="text-align: center; overflow-y: auto;">
                        <table id="tblaplicaciones" class="table table-bordered dt-responsive nowrap">

                            <thead style="background-color: #337ab7; color: white">
                                <tr>
                                    <th>Acciónes</th>
                                    <th>Nombre largo</th>
                                    <th>Nombre corto</th>
                                    <th>Descripción larga</th>
                                    <th>Descripción corta</th>
                                    <th>Versión</th>
                                    
                                    <th>Código Fuente</th>
                                    <th>Paquete Instalación</th>
                                    <th>Url</th>
                                    <th >Servidor</th>
                                    <th >Imagen Url</th> 

                                </tr>
                            </thead>
                            <td><%# Eval("nombre_largo_aplicacion") %></td>
                            <tr class='<%# Eval("nombre_largo_aplicacion")%>'>
                                <td><%# Eval("nombre_largo_aplicacion") %></td>
                                <td><%-- Fila para la busqueda en el footer --%></td>
                                <td><%-- Aqui agregamos los valores del objeto para que sea reconocibles --%></td>
                                <td><%# Eval("descripcion_larga_app") %></td>
                                <td><%# Eval("descripcion_corta_app") %></td>


                                <td><%-- Fila para la busqueda en el footer --%></td>
                                <td><%# Eval("version_aplicacion") %></td>

                            </tr>
                            <%-- Fila para la busqueda en el footer --%>
                            <tfoot>
                                <thead>
                                    <tr id="filterrow">
                                        <td></td>                              
                                        <th>Nombre largo</th>
                                        <th>Nombre corto</th>
                                        <th>Descripción larga</th>
                                        <th>Descripción corta</th>
                                        <th>Versión</th>                 
                                        <th>Código Fuente</th>
                                        <th>Paquete Instalación</th>
                                        <th>Url</th>
                                        <th >Servidor</th>
                                        <th >Imagen Url</th> 
                                    </tr>
                                </thead>
                            </tfoot>
                            <tr>
                                <td>
                                    <asp:Button ID="btnInsertar" runat="server" type="button" class="btn btn-primary" value=""  Text="Insertar" OnClick="btnInsertar_Click1"/>
                                </td>
                            </tr>
                        </table>
                        <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" CssClass="hidden"></asp:LinkButton>
                        <asp:LinkButton ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" CssClass="hidden"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Fin Tabla 1 -->
    <script type="text/javascript">

        $('#tblaplicaciones  tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblaplicaciones  th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });
        var idOculto = $("#<%= hdIdApp.ClientID %>").val();
        /*Aqui creamos la tabla con DataTables
          todas las propiedades del DataTable deben ser seteadas desde aqui y
          no desde el CodeBehind. 
          
          La caracteristica principal de esta table es que se hace server-side
          lo que agiliza la forma en que se pintan los datos en pantalla.
          Se usa ajax y json para manejar los objetos, se accesa un web service y carga los datos de un
          archivo json creador en la programacion del webService*/
        tipoServidor = $("#" + '<%= hdTipoServidor.ClientID %>').val();
        var table = $('#tblaplicaciones').DataTable({
            Processing: true,
            ServerSide: true,
            "sAjaxSource": 'Administracion/aplicaciones.asmx/getTodasAplicaciones(' + tipoServidor + ')',
            //se utilizar cuando se necesita meter parametros en el metodo del WS.
            "fnServerParams": function (aoData) {
                aoData.push({ "name": "hdIdApp", "value": idOculto });
            },

            sServerMethod: 'post',
            "sSearch": true,
            /*Setear columnas con datos*/
            "columns": [
                {
                    /*Asignamos que los botones tengan como valor el id de la app que trae el archivo json*/
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        var buttonID = full.id_aplicacion;
                        return '<a id="btnMod" class="glyphicon  glyphicon-ok" role="button" Onclick="Habilitar_Deshabilitar(' + buttonID + ')"></a><a id="btnMod" class="glyphicon glyphicon-pencil" role="button" Onclick="Modificar(' + buttonID + ')"></a><a id="btnDels" class="glyphicon glyphicon-trash" role="button" Onclick="Eliminar(' + buttonID + ')"></a>';


                    }
                },
        { 'data': 'nombre_largo_aplicacion' },
        { 'data': 'nombre_corto_aplicacion' },
        { 'data': 'descripcion_larga_app' },
        { 'data': 'descripcion_corta_app' },
        { 'data': 'version_aplicacion' },
       
        { 'data': 'codigo_aplicacion' },
        { 'data': 'paquete_instalacion' },
        { 'data': 'url' },
        { 'data': 'tipo_servidor' },
        { 'data': 'imagen' },


            ],
            "rowCallback": function (row, data, index) {




            },


            /*preferencias del table*/
            orderCellsTop: true,
            "paging": true,
            "pagingType": "full_numbers",
            "colReorder": true,

            "responsive": true,
            "scrollCollapse": true,


            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "decimal": ",",
                "thousands": ".",
                "sSelect": "1 fila seleccionada",
                "select": {
                    rows: {
                        _: "Ha seleccionado %d filas",
                        0: "Dele click a una fila para seleccionarla",
                        1: "1 fila seleccionada"
                    }
                },
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }



        });
        $("#tblaplicaciones  input").on('keyup change', function () {
            table
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });



        function stopPropagation(evt) {
            if (evt.stopPropagation !== undefined) {
                evt.stopPropagation();
            } else {
                evt.cancelBubble = true;
            }
        }

        /*
           Metodos accesados desde el data table , dan click a un boton hidden.              
         */
        function Modificar(id) {
            document.getElementById("<%=hdIdApp.ClientID%>").value = id;

            document.getElementById("<%= btnActualizar.ClientID%>").click();

        }

        function Eliminar(id) {

            document.getElementById("<%=hdIdApp.ClientID%>").value = id;
            document.getElementById("<%= btnEliminar.ClientID%>").click();
        }

        function seleccionar(idSeleccionado) {

        };
        function Habilitar_Deshabilitar(idSeleccionado) {

        };
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
