<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PAGAW.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" rel="stylesheet" type="text/css" />


    <link href="http://cdn.kendostatic.com/2014.1.318/styles/kendo.common.min.css" rel="stylesheet" />
    <link href="http://cdn.kendostatic.com/2014.1.318/styles/kendo.bootstrap.min.css" rel="stylesheet" />
    <link href="http://protostrap.com/Assets/gv/css/gv.bootstrap-form.css" rel="stylesheet" type="text/css" />

    <link href="css/pagination.min.css" rel="stylesheet" />
    <script src='<%=Page.ResolveUrl("~/Scripts/jquery-1.9.1.js") %>'></script>
    <div class="container_filtros">
        <div class="row">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" class="control-label control-label-left col-sm-2" for="selc_unidad_administrativa">Unidad Administrativa</asp:Label>
                                <div class="controls col-sm-9">
                                    <asp:DropDownList ID="selec_unidad_administrativa"  AutoPostBack="true" class="form-control" runat="server" OnSelectedIndexChanged="selec_unidad_administrativa_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label control-label-left col-sm-2" for="app_search">Aplicación</label>
                                <div class="controls col-sm-9">
                                    <div id="field2" class="input-group">

                                        <asp:TextBox ID="txtApp_search" class="form-control" data-role="lookup" placeholder="CBI" name="app_search" runat="server"></asp:TextBox>
                                  
                                        <!--<span class="input-group-addon"><span class="glyphicon glyphicon-search"></span></span> -->
                                    </div>
                                    
                                </div>
                                  <asp:LinkButton ID="LinkButton1" type="button" Style="" AutoPostBack="true" runat="server"  class="btn btn-default" OnClick="btnSearch_Click" >
                                             <span class="glyphicon glyphicon-search"></span>
                                      </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default apps">
        <div class="panel-heading">
            <h3 class="panel-title">Aplicaciones</h3>
        </div>
        <div class="panel-body">
            <label>
                Mostrar 
 <asp:DropDownList runat="server" name="repeter_length" id="repeter_length" aria-controls="tblUA" class="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="repeter_length_SelectedIndexChanged">
 </asp:DropDownList>
                registros</label>
            <asp:Repeater ID="repiterApps" runat="server">
                <HeaderTemplate>
                    <div class="container">
                        <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    <%# (Container.ItemIndex + 1) % 4 == 0 ? "<HeaderTemplate> <div class='container'><div class='row'></HeaderTemplate>  <FooterTemplate> </div> </div> </FooterTemplate>" : string.Empty %>
                    <div class="col-sm-4 ">
                        <div class="panel panel-primary selector" style="border-color: #88b312;">
                            <div class="panel-heading" style="background-color: #88b312;">
                                <asp:Label ID="ldl_unidad_app" runat="server"><%# Eval("unidad.nombre_ua")%></asp:Label>
                            </div>
                            <div class="panel-body">
                                <div class="hovereffect">


                                    <asp:Image runat="server" ID="Image_app" ImageUrl='<%# Eval("imagen") %>' class="img-responsive" Style="width: 100%" alt="Image" />
                                    <div class="overlay">
                                        <a class="info" href='http://<%# Eval("url")%>'>Ejecutar</a>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-footer " id="des">
                                <div>
                                    <p style="text-align: center; font-weight: bold;">Descripción</p>
                                </div>

                                <asp:Label ID="lsb_descripcion" runat="server" Style="text-align: justify;"><%# Eval("descripcion_corta_app") %></asp:Label>
                                <p>
                                </p>
                                <a style="cursor: pointer;" data-toggle="modal" data-target="#showDescripcion" data-url="<%# Eval("url") %>" data-name="<%# Eval("nombre_largo_aplicacion") %>" data-whatever="<%# Eval("descripcion_larga_app") %>" title="Ver más">Ver más</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </div>
            </div>
                </FooterTemplate>
            </asp:Repeater>
            <div id="externo" aria-label="Page navigation">
                <div id="contentPag">

                    <ul class="pagination">

                        <li class="page-item">
                            <asp:LinkButton ID="sFirst" class="page-link" runat="server" OnClick="lbFirst_Click">Primero</asp:LinkButton></li>
                        <li class="page-item">
                            <asp:LinkButton ID="lbPrevious" class="page-link" runat="server" OnClick="lbPrevious_Click">Anterior</asp:LinkButton></li>
                        <asp:DataList ID="rptPaging" runat="server"
                            OnItemCommand="rptPaging_ItemCommand"
                            OnItemDataBound="rptPaging_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <li class="page-item">
                                    <asp:LinkButton class="page-link" ID="lbPaging" runat="server"
                                        CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage"
                                        Text='<%# Eval("PageText") %> ' Width="20px"></asp:LinkButton></li>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:LinkButton ID="lbNext" class="page-link" runat="server" OnClick="lbNext_Click">Siguiente</asp:LinkButton>
                        <asp:LinkButton ID="lbLast" class="page-link" runat="server" OnClick="lbLast_Click">Ultimo</asp:LinkButton>
                    </ul>
                </div>
            </div>
            <div id="contentPag2">
                <asp:Label ID="lblpage" runat="server" Text=""></asp:Label>
            </div>
            <div style="border-color: #88b312;" class="modal fade" id="showDescripcion" tabindex="-1" role="dialog" aria-labelledby="labelshowDescripcion">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div style="background-color: #88b312" class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 style="color: white;" class="modal-title" id="labelshowDescripcion">Descripción Larga</h4>
                        </div>
                        <div class="modal-body">
                            <textarea readonly="readonly" id="subjdes" class="form-control" style="min-width: 100%" name="subjdes"></textarea>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Salir</button>
                            <a id="subjEje" class="btn btn-primary">Ejecutar</a>
                        </div>
                    </div>
                </div>
            </div>
            <script>
                $(document).ready(function () {
                    $('#showDescripcion').on('show.bs.modal', function (event) {
                        var button = $(event.relatedTarget);
                        var subjdes = button.data('whatever');
                        var subjname = button.data('name');
                        $('#subjdes').val(subjdes);

                        $("h4.modal-title").text(subjname);
                    })
                })

                function buscarAplicaciones() {
                    
                }

    $(document).ready(function(){
        $('#showDescripcion').on('show.bs.modal', function (event) {
          var button = $(event.relatedTarget);
          var subjdes = button.data('whatever');
          var subjname = button.data('name');



          $('#subjdes').val(subjdes);

          $("h4.modal-title").text(subjname);
    


        })
    })
</script>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>