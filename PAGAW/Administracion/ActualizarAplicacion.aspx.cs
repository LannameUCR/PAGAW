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
    public partial class ActualizarAplicacion : System.Web.UI.Page
    {
        public static string path = "C:\\Users\\Danny\\Desktop\\PAGAW-Iteracion1_LucreciaZu-iga_Terminado\\PAGAW\\Images\\img";

        #region variables globales
        AplicacionServicios appServicios = new AplicacionServicios();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];

            var tipoServidor = ddlTipoServidor.SelectedItem.Text;

            Aplicacion aplicacion = new Aplicacion(Int32.Parse(id), txtNombreLargo.Text, txtNombreCorto.Text, txtDescripcion_larga.Text, txtDescripcion_corta.Text,
            txtVersion_aplicacion.Text, "1", "rutaZIP", "Rutapaquete", txtUrlServidor.Text, tipoServidor, "", "IMG");

            appServicios.actualizarAplicacion(aplicacion);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdministradorAplicaciones.aspx");
        }
    }
}