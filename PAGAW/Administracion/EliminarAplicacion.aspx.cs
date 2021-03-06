﻿using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAGAW.Administracion
{
    public partial class EliminarAplicacion : System.Web.UI.Page
    {
        #region variables globales
        AplicacionServicios appServicios = new AplicacionServicios();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Aplicacion appEliminar = (Aplicacion)Session["appEliminar"];
                txtnombreApp.Text = appEliminar.nombre_corto_aplicacion;
                txtServidor.Text = appEliminar.tipo_servidor;
                txtdes_corta.Text = appEliminar.descripcion_corta_app;
                txtPaquete.Text = appEliminar.paquete_instalacion;
                txtUrl.Text = appEliminar.url;
                txtCodigo.Text = appEliminar.codigo_aplicacion;
                txtVersion.Text = appEliminar.version_aplicacion;    
                txtdesc.Text = appEliminar.descripcion_larga_app;

            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Aplicacion appEliminar = (Aplicacion)Session["appEliminar"];
                appServicios.eliminarAplicacion(appEliminar);

                String url = Page.ResolveUrl("~/AdministradorAPlicaciones.aspx");
                Response.Redirect(url);
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 547:

                        string script = @"<script type='text/javascript'>
                            alert('Error, no pueden eliminar la aplicacion.');
                         </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Atención", script, false);




                        break;
                    default:
                        System.Diagnostics.Debug.WriteLine("Error default");
                        break;

                }


            }
        }

        /*
         * Lucrecia ZUñiga Saenz
         * 26/08/2016
         * Metodo que se activa cuando se le da click al boton de cancelar
         * redirecciona a la pantalla de Administracion de aplicaciones
         */
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/AdministradorAPlicaciones.aspx");
            Response.Redirect(url);
        }

    }
}
