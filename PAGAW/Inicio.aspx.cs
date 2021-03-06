﻿using Bootstrap.Pagination;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAGAW
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        UnidadAdministrativaServicios unidadServicios = new UnidadAdministrativaServicios();
 
        AplicacionServicios appService = new AplicacionServicios();
        List<Aplicacion> listaApps = new List<Aplicacion>();
        cantidadDeRegistros numeroPaginas = new cantidadDeRegistros();
        ParametrosServicios parametrosServicios = new ParametrosServicios();
        string selectedRegister;
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string tipoServidor = Request.QueryString("servidor");                
                parametrosServicios.obtenerParametros();
                _pageSize = Parametros.getInstance().CantidadRegistros;
                Session["numeroPaginas"] = numeroPaginas.numero = _pageSize;
                List<Aplicacion> listaAplicaciones = appService.getAppsTipoServidor(tipoServidor);
                List<Aplicacion> listaAplicacionesUAs = new List<Aplicacion>();
                List<UnidadAdministrativa> unidades = unidadServicios.getUAs();

                foreach (Aplicacion app in listaAplicaciones)
                {
                    foreach (UnidadAdministrativa ua in unidades)
                    {
                        if (app.unidad.id_ua.Equals(ua.id_ua))
                        {
                            app.unidad.nombre_ua = ua.nombre_ua;
                            listaAplicacionesUAs.Add(app);
                        }
                    }
                }
                //Session["listaapps"] = appService.getApps();
                Session["listaapps"] = listaAplicacionesUAs;

                BindRepeater();
                this.BindDataIntoRepeater();                
            }
        }

        private void BindRepeater()
        {
            listaApps = appService.getApps();
            List<cantidadDeRegistros> registros = new List<cantidadDeRegistros>();
            int cuenta = 0;
            bool existeOption = false;
            cantidadDeRegistros numeroParametro = new cantidadDeRegistros();
            foreach (Aplicacion item in listaApps)
            {
                cuenta++;

                if (cuenta % 3 == 0) {
                    if (cuenta == _pageSize)
                    {
                        existeOption = true;
                        numeroParametro.numero = _pageSize;
                        numeroParametro.Numero_String = _pageSize.ToString();
                        registros.Add(numeroParametro);
                        continue;
                    }
                    cantidadDeRegistros numero = new cantidadDeRegistros();
                    numero.numero = cuenta;
                    numero.Numero_String = cuenta.ToString();
                    registros.Add(numero);
                }
            }
            if (!existeOption)
            {            
                numeroParametro.numero = _pageSize;
                numeroParametro.Numero_String = _pageSize.ToString();
                registros.Add(numeroParametro);
            }

            repeter_length.SelectedIndex = registros.IndexOf(numeroParametro);

            repeter_length.DataSource = registros;
            
            repeter_length.DataTextField = "Numero_String";

            repeter_length.DataValueField = "numero";
            repeter_length.DataBind();            

            List<UnidadAdministrativa> listaUnidades = unidadServicios.getUAs();

            selec_unidad_administrativa.DataSource = listaUnidades;
            selec_unidad_administrativa.DataTextField = "nombre_ua";
            selec_unidad_administrativa.DataValueField = "id_ua";
            selec_unidad_administrativa.DataBind();
        }

        protected void selec_unidad_administrativa_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnidadAdministrativa unidad = new UnidadAdministrativa();
            unidad.id_ua = Int32.Parse(selec_unidad_administrativa.SelectedValue);


            listaApps = appService.getAplicacionPorUnidadAdministrativa(unidad.id_ua);
            List<Aplicacion> listaAplicacionesUAs = new List<Aplicacion>();
            List<UnidadAdministrativa> unidades = unidadServicios.getUAs();

            foreach (Aplicacion app in listaApps)
            {
                foreach (UnidadAdministrativa ua in unidades)
                {
                    if (app.unidad.id_ua.Equals(ua.id_ua))
                    {
                        app.unidad.nombre_ua = ua.nombre_ua;
                        listaAplicacionesUAs.Add(app);
                    }
                }
            }
            Session["listaapps"] = listaAplicacionesUAs;
            CurrentPage = 0;
          this.BindDataIntoRepeater();

        }




        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }



        // Bind PagedDataSource into Repeater
        private void BindDataIntoRepeater()
        {
            var dt =(List<Aplicacion>) Session["listaapps"];
            _pgsource.DataSource = dt;
            _pgsource.AllowPaging = true;
            // Number of items to be displayed in the Repeater
            _pgsource.PageSize =(int) Session["numeroPaginas"];
            _pgsource.CurrentPageIndex = CurrentPage;
            // Keep the Total pages in View State
            ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            lblpage.Text = "Página " + (CurrentPage + 1) + " de " + _pgsource.PageCount;
            lbPrevious.CssClass = "page-link";
            lbNext.CssClass = "page-link";
            sFirst.CssClass = "page-link";
            lbLast.CssClass = "page-link";

            // Enable First, Last, Previous, Next buttons]
            lbPrevious.Enabled = !_pgsource.IsFirstPage;
            lbNext.Enabled = !_pgsource.IsLastPage;

            sFirst.Enabled = !_pgsource.IsFirstPage;

            lbLast.Enabled = !_pgsource.IsLastPage;


            // Bind data into repeater
            repiterApps.DataSource = _pgsource;
            repiterApps.DataBind();

            // Call the function to do paging
            HandlePaging();
        }

      

        private void HandlePaging()
        {
            var dt = new DataTable();
            dt.Columns.Add("PageIndex"); //Start from 0
            dt.Columns.Add("PageText"); //Start from 1

            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            // Now creating page number based on above first and last page index
            for (var i = _firstIndex; i < _lastIndex; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);

            }

            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }

        protected void lbFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BindDataIntoRepeater();
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BindDataIntoRepeater();
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindDataIntoRepeater();
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindDataIntoRepeater();
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BindDataIntoRepeater();
        }

        protected void repeter_length_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRegister = repeter_length.SelectedValue;
            Session["numeroPaginas"]=numeroPaginas.numero = Convert.ToInt32(repeter_length.SelectedValue);
            CurrentPage = 0;
            this.BindDataIntoRepeater();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Aplicacion> registros = new List<Aplicacion>();

            var applicationList = (List<Aplicacion>)Session["listaapps"];

            foreach (Aplicacion application in applicationList)
            {
                string applicationName = application.nombre_corto_aplicacion;

                if (application.nombre_corto_aplicacion.Contains(txtApp_search.Text) || application.nombre_largo_aplicacion.Contains(txtApp_search.Text))
                {
                    registros.Add(new Aplicacion(application.id_aplicacion, application.nombre_largo_aplicacion, application.nombre_corto_aplicacion,
                    application.descripcion_larga_app, application.descripcion_corta_app, application.version_aplicacion, application.habilitado_aplicacion,
                    application.codigo_aplicacion, application.paquete_instalacion, application.url, application.tipo_servidor, application.unidad, application.imagen));
                }
            }

            BindRepeaterSearch(registros);
        }

        private void BindRepeaterSearch(List<Aplicacion> registros)
        {
            this.repiterApps.DataSource = registros;
            this.repiterApps.DataBind();
        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            lnkPage.CssClass = "page-link paginationCOlor2";

            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;

            lnkPage.CssClass = "paginationCOlor";


        }

    }
}