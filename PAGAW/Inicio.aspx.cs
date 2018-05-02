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
    public partial class WebForm1 : System.Web.UI.Page
    {
        UnidadAdministrativaServicios unidadServicios = new UnidadAdministrativaServicios();
        AplicacionServicios appService = new AplicacionServicios();
        List<Aplicacion> listaApps = new List<Aplicacion>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {
            listaApps = appService.getApps();
            this.repiterApps.DataSource = listaApps;
            this.repiterApps.DataBind();

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
            this.repiterApps.DataSource = listaApps;
            this.repiterApps.DataBind();
        }
    }
}