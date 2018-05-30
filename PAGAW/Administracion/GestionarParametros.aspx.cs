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
    public partial class GestionarParametros : System.Web.UI.Page
    {
        private ParametrosServicios parametrosServicios = new ParametrosServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtCantidadRegistros.Text = Parametros.getInstance().CantidadRegistros + "";
                txtRutaPruebas.Text = Parametros.getInstance().RutaPruebas;
                txtRutaProduccion.Text = Parametros.getInstance().RutaProduccion;
                txtRutaArchivos.Text = Parametros.getInstance().RutaArchivos;
            }
        }

        protected void modificarParametros_Click(object sender, EventArgs e)
        {
            Parametros.getInstance().CantidadRegistros = Convert.ToInt32(txtCantidadRegistros.Text);
            Parametros.getInstance().RutaPruebas = txtRutaPruebas.Text;
            Parametros.getInstance().RutaProduccion = txtRutaProduccion.Text;
            Parametros.getInstance().RutaArchivos = txtRutaArchivos.Text;

            bool respuestaServicio = parametrosServicios.modificarParametros();
            if (respuestaServicio)
            {
                Response.Redirect("~/Inicio.aspx");
            }
            else
            {
                dangerAlert.Visible = false;
                dangerAlert.Visible = true;
                alertDangerMessage.Text = "No se pudieron modificar los parámetros";
            }
        }

        protected void restablecerParametros_Click(object sender, EventArgs e)
        {            
            bool respuestaServicio = parametrosServicios.cargarParametrosPorDefecto();
            if (respuestaServicio)
            {
                Response.Redirect("~/Inicio.aspx");
            }
            else
            {
                dangerAlert.Visible = false;
                dangerAlert.Visible = true;
                alertDangerMessage.Text = "No se pudieron restablecer los parámetros";
            }
        }

        protected void cancelarOperacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}