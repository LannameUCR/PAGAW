<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="AdministrarBitacoraVersiones.aspx.cs" Inherits="PAGAW.BitacoraVersiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<meta name="HandheldFriendly" content="True" />--%>
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
            <h3 class="panel-title">Bitácora versiones</h3>
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
                    <%# Eval("nombre_usuario") %>
                    <input type="hidden" id="hdIdDato" runat="server" />
                    <input type="hidden" id="hdIdActivo" runat="server" />
                    <%-- Fila para la busqueda en el footer --%>
                    <!--Tabla 1 -->
                    <div class="col-md-12 col-xs-12 col-sm-12" style="text-align: center; overflow-y: auto;">
                        <table id="tblBitacora" class="table table-bordered dt-responsive nowrap">

                            <thead style="background-color: #337ab7; color: white">
                                <tr>
                                    <th>Acciónes</th>
                                    <th>Nombre usuario</th>
                                    <th>Fecha de operacion</th>
                                    <th>Descripción</th>
                                </tr>
                            </thead>
                            <td><%# Eval("nombre_usuario") %></td>
                            <tr class='<%# Eval("nombre_usuario")%>'>
                                <td><%# Eval("nombre_usuario") %></td>
                                <td><%-- Fila para la busqueda en el footer --%></td>
                                <td><%-- Aqui agregamos los valores del objeto para que sea reconocibles --%></td>
                                <td><%# Eval("fecha_de_operacion") %></td>
                                <td><%# Eval("descripcion") %></td>

                            </tr>
                            <%-- Fila para la busqueda en el footer --%>
                            <tfoot>
                                <thead>
                                    
                                </thead>
                            </tfoot>
                            <tr>
                                <td>
                                    <asp:Button ID="btnInsertar" runat="server" type="button" class="btn btn-primary" value=""  OnClick="btnInsertar_Click"  Text="Insertar"/>
                                </td>
                            </tr>
                        </table>
                        <asp:LinkButton ID="btnActualizar" runat="server" OnClick="btnActualizar_Click"  CssClass="hidden"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Fin Tabla 1 -->
    <script type="text/javascript">

        var idOculto = $("#<%= hdIdDato.ClientID %>").val();
        /*Aqui creamos la tabla con DataTables
          todas las propiedades del DataTable deben ser seteadas desde aqui y
          no desde el CodeBehind. 
          
          La caracteristica principal de esta table es que se hace server-side
          lo que agiliza la forma en que se pintan los datos en pantalla.
          Se usa ajax y json para manejar los objetos, se accesa un web service y carga los datos de un
          archivo json creador en la programacion del webService*/
        var table = $('#tblBitacora').DataTable({
            Processing: true,
            ServerSide: true,
            "sAjaxSource": 'Administracion/aplicaciones.asmx/getDatosBitacora',
            //se utilizar cuando se necesita meter parametros en el metodo del WS.
            "fnServerParams": function (aoData) {
                aoData.push({ "name": "hdIdDato", "value": idOculto });
            },

            sServerMethod: 'post',
            "sSearch": true,
            /*Setear columnas con datos*/
            "columns": [
                {
                    /*Asignamos que los botones tengan como valor el id de la app que trae el archivo json*/
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        var buttonID = full.id_Bitacora;
                        //return '<a id="btnMod" class="glyphicon glyphicon-pencil" role="button" Onclick="Modificar(' + buttonID + ')"></a>';
                        return '</a><a id="btnMod" class="glyphicon glyphicon-pencil" role="button" Onclick="Modificar(' + buttonID + ')"></a>';
                    }
                },
        { 'data': 'nombre_usuario' },
        { 'data': 'fecha_de_operacion' },
        { 'data': 'descripcion' },

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
        $("#tblBitacora  input").on('keyup change', function () {
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
            document.getElementById("<%=hdIdDato.ClientID%>").value = id;

            document.getElementById("<%= btnActualizar.ClientID%>").click();
        }

        function seleccionar(idSeleccionado) {

        };
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
