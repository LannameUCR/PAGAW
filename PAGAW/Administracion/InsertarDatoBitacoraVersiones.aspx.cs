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
    public partial class InsertarDatoBitacoraVersiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Text = Session["nombreCompleto"].ToString();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BitacoraDeVersionesServicios bitacoraVersionesServicios = new BitacoraDeVersionesServicios();
            txtNombreUsuario.Text = Session["nombreCompleto"].ToString();

            DateTime fechaHoy = DateTime.Now;
            string fechas = fechaHoy.ToString("yyyy/MM/dd");
            bitacoraVersionesServicios.insertarDatoBitacoraVersiones(new BitacoraDeVersiones(Session["nombreCompleto"].ToString(),
            fechas, txtDescripcion.Text));
            Response.Redirect("/AdministrarBitacoraVersiones.aspx");


        }
    }
}