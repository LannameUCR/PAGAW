<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PAGAW.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="http://wenzhixin.net.cn/p/bootstrap-table/src/bootstrap-table.css" rel="stylesheet" type="text/css" />
    <link href="http://cdn.kendostatic.com/2014.1.318/styles/kendo.common.min.css" rel="stylesheet" />
    <link href="http://cdn.kendostatic.com/2014.1.318/styles/kendo.bootstrap.min.css" rel="stylesheet" />
    <link href="http://protostrap.com/Assets/gv/css/gv.bootstrap-form.css" rel="stylesheet" type="text/css" />

    <div class="container_filtros">
        <div class="row">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" class="control-label control-label-left col-sm-3" for="selc_unidad_administrativa">Unidad Administrativa</asp:Label>
                                <div class="controls col-sm-9">

                                    <select id="selc_unidad_administrativa" class="form-control" data-role="select">
                                        <option value="">UTI</option>
                                        <option value="Option 1">Option 1</option>
                                        <option value="Option 2">Option 2</option>
                                        <option value="Option 3">Option 3</option>
                                        <option value="Option 4">Option 4</option>
                                    </select><span id="errId1" class="error"></span>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label control-label-left col-sm-3" for="app_search">Aplicación</label>
                                <div class="controls col-sm-9">
                                    <div id="field2" class="input-group">
                                        <input type="text" class="form-control" data-role="lookup" placeholder="CBI" name="app_search" id="app_search">
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-search"></span></span>
                                    </div>
                                </div>
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
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Repeater ID="repiterApps" runat="server">
                <HeaderTemplate>
                    <div class="container">

                        <div class="row">
                </HeaderTemplate>
                <ItemTemplate>

                    <%# (Container.ItemIndex +1) % 4 == 0 ? "<HeaderTemplate> <div class='container'><div class='row'></HeaderTemplate>  <FooterTemplate> </div> </div> </FooterTemplate>" : string.Empty %>

                    <div class="col-sm-4 ">
                        <div class="panel panel-primary selector" style="border-color: #88b312;">
                            <div class="panel-heading" style="background-color: #88b312;">
                                <asp:Label ID="ldl_unidad_app" runat="server">UTI</asp:Label>
                            </div>
                            <div class="panel-body">
                                <div class="hovereffect">
                                    <asp:Image runat="server" ID="Image_app" ImageUrl="/Imagenes/item1.png" class="img-responsive" Style="width: 100%" alt="Image" />

                                    <div class="overlay">

                                        <a class="info" href="#"><%# Eval("descrp_larga") %></a>                                    </div>
                                </div>
                            </div>
                            <div class="panel-footer " id="des">
                                <div>
                                    <p style="text-align: center; font-weight: bold;">Descripción</p>
                                </div>
                                The example below centers a paragraph inside a block that has a certain given height. A separate example shows a paragraph that is centered vertically in the browser window, because it is inside a block that is absolutely positioned and as tall as the window.d
                            <asp:Label ID="lsb_descripcion" runat="server" Text="Label" Style="text-align: justify;"><%# Eval("descrp_larga") %></asp:Label>
                                <p>
                                </p>
                                <a>Ver más</a>

                            </div>
                        </div>
                    </div>
                </ItemTemplate>

                <FooterTemplate>
                    </div>

            </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
