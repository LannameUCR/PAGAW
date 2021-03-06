﻿using Bootstrap.Pagination;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PAGAW.Administracion
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        #region variables globales
        AplicacionServicios appServicios = new AplicacionServicios();
        #endregion
        #region Cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            //int[] rolesPermitidos = { 2 };
            //Utilidades.escogerMenu(Page, rolesPermitidos);
            if (!Page.IsPostBack)
            {
                string tipoServidor = Request.QueryString("servidor");                
                hdTipoServidor.Value = tipoServidor;
                //Session["listaAplicaciones"] = null;
                hdIdApp.Value = "";
                List<Aplicacion> listaApps = appServicios.getAppsTipoServidor(tipoServidor);
                Session["listaAplicaciones"] = listaApps;

            }
        }
        #endregion
        #region acciones de botones
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idApp = Convert.ToInt32(hdIdApp.Value);
            List<Aplicacion> listaApps = (List<Aplicacion>)Session["listaAplicaciones"];
            Aplicacion appElimimar = new Aplicacion();
            foreach (Aplicacion appTemporal in listaApps)
            {
                if (appTemporal.id_aplicacion == idApp)
                {
                    //activo_copia a editar
                    appElimimar = appTemporal;
                    break;
                }
            }
            Session["appEliminar"] = appElimimar;

            String url = Page.ResolveUrl("~/Administracion/EliminarAplicacion.aspx");
            Response.Redirect(url);
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administracion/InsertarAplicacion.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            int idApp = Convert.ToInt32(hdIdApp.Value);
            List<Aplicacion> listaApps = (List<Aplicacion>)Session["listaAplicaciones"];
            Aplicacion appActualizar = new Aplicacion();

            foreach (Aplicacion appTemporal in listaApps)
            {
                if (appTemporal.id_aplicacion == idApp)
                {
                    //activo_copia a editar
                    appActualizar = appTemporal;
                    break;
                }
            }

            Session["appActualizar"] = appActualizar;

            String url = Page.ResolveUrl("~/Administracion/ActualizarAplicacion.aspx");
            Response.Redirect(url);


            //Response.Redirect("Administracion/ActualizarAplicacion.aspx?id=" + idApp + "");
        }
        #endregion

    }
}   