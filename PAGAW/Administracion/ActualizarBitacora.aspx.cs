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
    public partial class ModificarBitacora : System.Web.UI.Page
    {
        #region variables globales
        BitacoraDeVersionesServicios bitacoraVersionesServicios = new BitacoraDeVersionesServicios();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BitacoraDeVersiones datoEliminar = (BitacoraDeVersiones)Session["listaDeBitacora"];
                txtId.Text = datoEliminar.id_Bitacora + "";
                txtNombreUsuario.Text = datoEliminar.nombre_usuario;
                txtFechaOperacion.Text = datoEliminar.fecha_de_operacion;
                txtDescripción.Text = datoEliminar.descripcion;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/AdministrarBitacoraVersiones.aspx");
            Response.Redirect(url);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            /*string[] array = txtFechaOperacion.Text.Split('/');

            string fecha = array[2] + "/" + array[1] + "/" + array[0];
            **/
            BitacoraDeVersiones bitacora = new BitacoraDeVersiones(Int32.Parse(txtId.Text),txtNombreUsuario.Text, txtFechaOperacion.Text, txtDescripción.Text);

            bitacoraVersionesServicios.actualizarDatoBitacoraVersiones(bitacora);

            String url = Page.ResolveUrl("~/AdministrarBitacoraVersiones.aspx");
            Response.Redirect(url);
        }
    }
}