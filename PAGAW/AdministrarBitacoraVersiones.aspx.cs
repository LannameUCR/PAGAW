using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAGAW
{
    public partial class BitacoraVersiones : System.Web.UI.Page
    {
        #region variables globales
        BitacoraDeVersionesServicios bitacoraServicios = new BitacoraDeVersionesServicios();
        #endregion
        #region Cargar pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            //int[] rolesPermitidos = { 2 };
            //Utilidades.escogerMenu(Page, rolesPermitidos);
            if (!Page.IsPostBack)
            {
                Session["listaDeBitacora"] = null;
                hdIdDato.Value = "";
                List<BitacoraDeVersiones> listaDatosBitacora = bitacoraServicios.obtenerBitacoraVersiones();
                Session["listaDeBitacora"] = listaDatosBitacora;

            }
        }
        #endregion

        #region acciones de botones

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administracion/InsertarDatoBitacoraVersiones.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            int idDato = Convert.ToInt32(hdIdDato.Value);
            List<BitacoraDeVersiones> listaDatosBitacora = (List<BitacoraDeVersiones>)Session["listaDeBitacora"];
            BitacoraDeVersiones datoBitacoraActualizar = new BitacoraDeVersiones();

            foreach (BitacoraDeVersiones datoTemporal in listaDatosBitacora)
            {
                if (datoTemporal.id_Bitacora == idDato)
                {
                    //activo_copia a editar
                    datoBitacoraActualizar = datoTemporal;
                    break;
                }
            }

            Session["listaDeBitacora"] = datoBitacoraActualizar;

            String url = Page.ResolveUrl("~/Administracion/ActualizarBitacora.aspx");
            Response.Redirect(url);


            //Response.Redirect("Administracion/ActualizarAplicacion.aspx?id=" + idApp + "");
        }
        #endregion
    }
}