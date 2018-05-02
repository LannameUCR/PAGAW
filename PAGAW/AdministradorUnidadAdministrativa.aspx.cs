﻿using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAGAW
{
    public partial class AdministradorUnidadAdministrativa : System.Web.UI.Page
    {
        UnidadAdministrativaServicios UaServicios = new UnidadAdministrativaServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Session["listaUnidades"] = null;
                hdIdUA.Value = "";
                List<UnidadAdministrativa> listaUas = UaServicios.getUAs();
                Session["listaUnidades"] = listaUas;

            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idUa = Convert.ToInt32(hdIdUA.Value);
            List<UnidadAdministrativa> listaUas = (List<UnidadAdministrativa>)Session["listaUnidades"];
            UnidadAdministrativa uaElimimar = new UnidadAdministrativa();
            foreach (UnidadAdministrativa uaTemporal in listaUas)
            {
                if (uaTemporal.id_ua == idUa)
                {

                    uaElimimar = uaTemporal;
                    break;
                }
            }
            Session["uaEliminar"] = uaElimimar;

            String url = Page.ResolveUrl("~/Administracion/EliminarUnidadAdministrativa.aspx");
            Response.Redirect(url);

        }
    }
}