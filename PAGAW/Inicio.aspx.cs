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

        }
    }
}