<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="AdministradorAPlicaciones.aspx.cs" Inherits="PAGAW.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src='<%=Page.ResolveUrl("~/Scripts/datatables.min.js") %>'></script>
<script src='<%=Page.ResolveUrl("~/Scripts/Dialogo.js") %>'></script>
     <script src='<%=Page.ResolveUrl("~/Scripts/bootstrap-dialog.js") %>'></script>
       <link href="Content/DataTables/datatables.min.css" rel="stylesheet" />
     <link href="css/bootstrap.css" rel="stylesheet" />
    <%-- Estilos con formato UCR  --%>
    <link href="css/Lanamme.css" rel="stylesheet" />  

    <!-- Font Awesome -->
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!--Dialogos de Mensaje ref:https://nakupanda.github.io/bootstrap3-dialog/#available-options -->
    <link href="css/bootstrap-dialog.css" rel="stylesheet" />
<div class="divRedondo">
        <div class="row">

            <%-- Aqui agregamos los valores del objeto para que sea reconocibles --%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
            <asp:Label ID="lblNombreInventarioConsolidado" runat="server" Font-Size="Large" ForeColor="Black"></asp:Label>
        </center>
            </div>

      <%# Eval("nombre") %>
    <input type="hidden" id="hdIdApp" runat="server" />
      <input type="hidden" id="hdIdActivo" runat="server" />


    <%-- Fila para la busqueda en el footer --%>
   <!--Tabla 1 -->
            <div class="col-md-12 col-xs-12 col-sm-12" style="text-align: center; overflow-y: auto;">
               <table id="tblaplicaciones" class="table table-bordered dt-responsive nowrap">

                    <thead>
                        <tr>
                            <th>Acciónes</th>
                            <th>Nombre</th>
                            <th>Descripción</th>
                            <th>Versión</th>

                            <th>Código Fuente</th>
                            <th>Paquete Instalación</th>
                            <th>Url</th>
                            <th>Imagen Url</th>
                            
                        </tr>
                    </thead>

                    <%# Eval("nombre") %>
                 
              <tr >
                        <td></td> 
                        <td><%# Eval("nombre") %></td>
                        <td><%-- Fila para la busqueda en el footer --%></td>
                        <td><%-- Aqui agregamos los valores del objeto para que sea reconocibles --%></td>
                        <td><%# Eval("descrp_larga") %></td>
                        <td><%-- Fila para la busqueda en el footer --%></td>
                        <td><%# Eval("version") %></td>
                        <td><%# Eval("codigo") %></td>
                       
                    </tr>
                

                    <%-- Fila para la busqueda en el footer --%>
                    <footertemplate>
                        <thead>
                            <tr id="filterrow">
                                 <td></td>
                                <th>Nombre</th>
                                <th>Descripción</th>

                                <th>Versión</th>
                                <th>Código Fuente</th>
                                <th>Pauqete Instalación</th>
                                <th>Url</th>
                                <th>Imagen Url</th>
                                
                            </tr>
                        </thead>
                      </footertemplate>
                </table>
            </div>
              </div>  </div>
            <!--Fin Tabla 1 -->

    <script type="text/javascript">

        $('#tblaplicaciones thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblaplicaciones thead th').eq($(this).index()).text();
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
        var table = $('#tblaplicaciones').DataTable({
            Processing: true,
            ServerSide: true,
            "sAjaxSource": 'Administracion/aplicaciones.asmx/getTodasAplicaciones',
            //se utilizar cuando se necesita meter parametros en el metodo del WS.
            "fnServerParams": function (aoData) {
                aoData.push({ "name": "hdIdApp", "value": idOculto });
            },

            sServerMethod: 'post',
            "sSearch": true,


            /*Setear columnas con datos*/
            "columns": [
                {
                    /*Asignamos que los botones tengan como valor el id del activo que trae el archivo json*/
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        var buttonID = full.idActivoCopia;
                        return '<a id="btnMod" class="glyphicon glyphicon-pencil" role="button" Onclick="Modificar(' + buttonID + ')"></a>';
                        //return '<button id="Button1" Onclick="prueba(' + buttonID + ')" class="glyphicon glyphicon-pencil"></button>';
                    }
                },
              
                { 'data': 'nombre' },
        { 'data': 'descrp_larga' },
        { 'data': 'version' },
                { 'data': 'url' },
        { 'data': 'paquete' },
        { 'data': 'servidor' },
        { 'data': 'imagenUrl' },
               

            ],
            "rowCallback": function (row, data, index) {

              


            },


            /*preferencias del table*/
            orderCellsTop: true,
            "pagingType": "full_numbers",
            "iDisplayLength": 10,
            "paging": true,
            "pageLength": 10,
            "colReorder": true,
            "select": false,
            "order": [[1, "asc"]],
            "stateSave": true,
            "dom": 'Bfrtip',
            "buttons": [
        {
            extend: 'pdfHtml5',
            exportOptions: {
                columns: [1, 2]
            }
        },

        {
            extend: 'excelHtml5',
            exportOptions: {
                columns: [1, 2]
            }
        },
        {
            extend: 'copyHtml5',
            exportOptions: {
                columns: [1, 2]
            }
        },
        {
            extend: 'print',
            exportOptions: {
                columns: [1, 2]
            }
        }
            ],
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
        $("#tblaplicaciones thead input").on('keyup change', function () {
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
         
        
           
        }

        function Eliminar(id) {
       

        }

        function seleccionar(idSeleccionado) {
      
                };
    </script>
    <!-- fin script tabla jquery -->
    <script src='<%=Page.ResolveUrl("~/Scripts/bootstrap-dialog.js") %>'></script>
        <script src='<%=Page.ResolveUrl("~/Scripts/bootstrap.js") %>'></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
