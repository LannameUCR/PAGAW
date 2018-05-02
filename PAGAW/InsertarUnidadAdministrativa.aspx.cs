using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Servicios;

namespace PAGAW
{
    public partial class InsertarUnidadAdministrativa : System.Web.UI.Page
    {
        private UnidadAdministrativaServicios uaServicios;

        protected void Page_Load(object sender, EventArgs e)
        {
            uaServicios = new UnidadAdministrativaServicios();            
        }

        protected void agregarUnidad_Click(object sender, EventArgs e)
        {
            UnidadAdministrativa unidadAdministrativa = new UnidadAdministrativa(uaNombre.Text, uaDescCorta.Text, uaDescLarga.Text);
            bool respuestaServicio = uaServicios.agregarUA(unidadAdministrativa);

            if (respuestaServicio)
            {
                Response.Redirect("AdministradorUnidadAdministrativa.aspx");
            }
            else
            {
                dangerAlert.Visible = false;
                dangerAlert.Visible = true;
                alertDangerMessage.Text = "No se pudo ingresar la unidad administrativa";
            }
        }

        protected void cancelarOperacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministradorUnidadAdministrativa.aspx");
        }
    }
}