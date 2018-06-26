<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="AdministradorUnidadAdministrativa.aspx.cs" Inherits="PAGAW.AdministradorUnidadAdministrativa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src='<%=Page.ResolveUrl("~/Scripts/datatables.min.js") %>'></script>
<script src='<%=Page.ResolveUrl("~/Scripts/Dialogo.js") %>'></script>
 
       <link href="Content/DataTables/datatables.min.css" rel="stylesheet" />
     <link href="css/bootstrap.css" rel="stylesheet" />
    <%-- Estilos con formato UCR  --%>
    <link href="css/Lanamme.css" rel="stylesheet" />  

    <meta name="HandheldFriendly" content="True" />
    <meta name="MobileOptimized" content="320" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="cleartype" content="on" />

  

    <link href="css/Lanamme.css" rel="stylesheet" />
     <!-- Font Awesome -->
     <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!--Dialogos de Mensaje ref:https://nakupanda.github.io/bootstrap3-dialog/#available-options -->
    <link href="css/bootstrap-dialog.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
   <link href="css/bootstrap-dialog.css" rel="stylesheet" />
 
      <!--Dialogos de Mensaje ref:https://nakupanda.github.io/bootstrap3-dialog/#available-options -->
    <link href="css/bootstrap-dialog.css" rel="stylesheet" />

    <link href="Scripts/Table/bootstrap.min.css" rel="stylesheet" />  
    <link href="Scripts/Table/responsive.bootstrap.min.css" rel="stylesheet" />
       
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
            <h3 class="panel-title">Unidades Administrativas</h3>
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
                    <%# Eval("nombre_ua") %>
                    <input type="hidden" id="hdIdUA" runat="server" />
                    <input type="hidden" id="hdCantidadRegistros" runat="server" />
                    <%-- Fila para la busqueda en el footer --%>
                    <!--Tabla 1 -->
                    <div class="col-md-12 col-xs-12 col-sm-12" style="text-align: center; overflow-y: auto;">
                        <table id="tblUA" class="table table-bordered dt-responsive nowrap">
                            <thead style="background-color: #337ab7; color: white">
                                <tr>
                                    <th>Acciones</th>
                                    <th>Nombre</th>
                                    <th>Descripcion Larga</th>
                                    <th>Descripcion Corta</th>
                                    <th>Activo</th>
                                </tr>
                            </thead>
                            <td><%# Eval("nombre_ua") %></td>
                            <tr class='<%# Eval("nombre_ua")%>'>
                                <td><%# Eval("nombre_ua") %></td>
                                <td><%-- Fila para la busqueda en el footer --%></td>
                                <td><%-- Aqui agregamos los valores del objeto para que sea reconocibles --%></td>
                                <td><%# Eval("descripcion_larga") %></td>
                                <td><%-- Fila para la busqueda en el footer --%></td>
                                <td><%# Eval("descripcion_corta") %></td>
                                <td><%# Eval("activo") %></td>
                            </tr>
                            <%-- Fila para la busqueda en el footer --%>
                           
                                <thead>
                            <tr>

                             <tfoot>
                                    <tr id="filterrow">
                                        <td></td>
                                        <th>Nombre</th>
                                        <th>Descripción Larga</th>
                                        <th>Descripción Corta</th>
                                        <th>activo</th>
                                    </tr>
                            </tfoot>
                            </tr>

                                </thead>

                            <tr>
                                <td>
                                    <asp:Button runat="server" type="button" class="btn btn-primary" value="" OnClick="btnInsertar_Click" Text="Insertar" />
                                </td>
                            </tr>
                        </table>
                        <asp:LinkButton ID="btnHabilitar_deshabilitar" runat="server" OnClick="btnHA_DEs_Click" CssClass="hidden"></asp:LinkButton>

                        <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" CssClass="hidden"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Fin Tabla 1 -->
    <script type="text/javascript">        
        $('#tblUA  tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblUA  th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });
        var idOculto = $("#<%= hdIdUA.ClientID %>").val();
        /*Aqui creamos la tabla con DataTables
          todas las propiedades del DataTable deben ser seteadas desde aqui y
          no desde el CodeBehind. 
          La caracteristica principal de esta table es que se hace server-side
          lo que agiliza la forma en que se pintan los datos en pantalla.
          Se usa ajax y json para manejar los objetos, se accesa un web service y carga los datos de un
          archivo json creador en la programacion del webService*/        
        var table = $('#tblUA').DataTable({
            Processing: true,
            ServerSide: true,
            "sAjaxSource": 'Administracion/aplicaciones.asmx/getTodasUnidadesAdministrativas',
            //se utilizar cuando se necesita meter parametros en el metodo del WS.
            "fnServerParams": function (aoData) {
                aoData.push({ "name": "hdIdUA", "value": idOculto });
            },
            sServerMethod: 'post',
            "sSearch": true,
            /*Setear columnas con datos*/
            "columns": [
                {
                    /*Asignamos que los botones tengan como valor el id de la app que trae el archivo json*/
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        var buttonID = full.id_ua;
                        return '<a ID="btnAH"  class="glyphicon  glyphicon-ok" role="button" Onclick="Habilitar_Deshabilitar(' + buttonID + ')"></a><a id="btnMod" class="glyphicon glyphicon-pencil" role="button" Onclick="Modificar(' + buttonID + ')"></a><a id="btnDels" class="glyphicon glyphicon-trash" role="button" Onclick="Eliminar(' + buttonID + ')"></a>';
                    }
                },            
        { 'data': 'nombre_ua' },
        { 'data': 'descripcion_larga' },
        { 'data': 'descripcion_corta' },
        { 'data': 'activo' },
  
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
        cantidadRegistrosTable = $("#" + '<%= hdCantidadRegistros.ClientID %>').val();
        if ($("select[name=tblUA_length] option[value=" + cantidadRegistrosTable + "]").length == 1) {
            $('select[name=tblUA_length]').val(cantidadRegistrosTable);
            //alert($('select[name=tblUA_length]').val());
        } else {
            $('select[name=tblUA_length]').append($('<option>', {
                value: cantidadRegistrosTable,
                text: cantidadRegistrosTable
            }));
            $('select[name=tblUA_length]').val(cantidadRegistrosTable);
            //alert($('select[name=tblUA_length]').val());
        }
        $("#tblUA  input").on('keyup change', function () {
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
            window.location = "ModificarUnidadAdministrativa.aspx?idUA=" + id;
        }
        function Eliminar(id) {
            document.getElementById("<%=hdIdUA.ClientID%>").value = id;
            document.getElementById("<%=btnEliminar.ClientID%>").click();
        }

        function seleccionar(idSeleccionado) {

        };

        function Habilitar_Deshabilitar(idSeleccionado) {
            document.getElementById("<%=hdIdUA.ClientID%>").value = id;
         

            document.getElementById("<%=btnHabilitar_deshabilitar.ClientID%>").click();

        }; 
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
