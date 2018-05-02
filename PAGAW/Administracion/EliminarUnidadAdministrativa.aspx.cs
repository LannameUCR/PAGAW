using Entidades;
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
    public partial class EliminarUnidadAdministrativa : System.Web.UI.Page
    {
        UnidadAdministrativaServicios uaServicios = new UnidadAdministrativaServicios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnidadAdministrativa uaEliminar = (UnidadAdministrativa)Session["uaEliminar"];
                txtnombre.Text = uaEliminar.nombre_ua;    
                txtdes_corta.Text = uaEliminar.descripcion_corta;
                txtdesc.Text = uaEliminar.descripcion_larga;

            }
        }
        /*
        * Lucrecia ZUñiga Saenz
        * 26/08/2016
        * Metodo que se activa cuando se le da click al boton de cancelar
        * redirecciona a la pantalla de Administracion de aplicaciones
        */
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                UnidadAdministrativa uaEliminar = (UnidadAdministrativa)Session["uaEliminar"];
                uaServicios.eliminarUnidadAdministrativa(uaEliminar);
                String url = Page.ResolveUrl("~/AdministradorUnidadAdministrativa.aspx");
                Response.Redirect(url);
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 547:
                        string script = @"<script type='text/javascript'>
                            alert('Error, no pueden eliminar la Unidad Administrativa.');
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
            String url = Page.ResolveUrl("~/AdministradorUnidadAdministrativa.aspx");
            Response.Redirect(url);
        }
    }
}