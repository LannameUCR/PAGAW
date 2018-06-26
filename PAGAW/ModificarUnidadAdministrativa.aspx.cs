using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Servicios;

namespace PAGAW
{
    public partial class ModificarUnidadAdministrativa : System.Web.UI.Page
    {
        private UnidadAdministrativaServicios uaServicios;
        private int idUA;

        protected void Page_Load(object sender, EventArgs e)
        {           
            uaServicios = new UnidadAdministrativaServicios();
            idUA = Convert.ToInt32(Request.QueryString["idUA"]);
            Hashtable hashtbl = uaServicios.getHasUA();
            if (hashtbl.ContainsKey(idUA))
            {
                if (!IsPostBack)
                {
                    UnidadAdministrativa unidadAdministrativa = (UnidadAdministrativa)hashtbl[idUA];
                    uaNombre.Text = unidadAdministrativa.nombre_ua;
                    uaDescCorta.Text = unidadAdministrativa.descripcion_corta;
                    uaDescLarga.Text = unidadAdministrativa.descripcion_larga;

                    if (unidadAdministrativa.activo == "Activo")
                    {
                        checkActivo.Checked = true;
                    }
                    else
                    {
                        checkActivo.Checked = false;
                    }
                }
            } 
        }


        protected void cancelarOperacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministradorUnidadAdministrativa.aspx");
        }
        string val = "";
        protected void uaNombre_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            val = t.Text;
            System.Diagnostics.Debug.Write(uaNombre.Text + "\n");
            System.Diagnostics.Debug.Write(uaDescLarga.Text + "\n");
            System.Diagnostics.Debug.Write(uaDescCorta.Text + "\n");            
        }

        protected void modificar_unidad_Click(object sender, EventArgs e)
        {
            string activo = "False";

            if (checkActivo.Checked == true)
            {
                activo = "True";
            }

            System.Diagnostics.Debug.Write("\n" + val);
            UnidadAdministrativa unidadAdministrativa = new UnidadAdministrativa(idUA, uaNombre.Text, uaDescCorta.Text, uaDescLarga.Text, activo);
            System.Diagnostics.Debug.Write("\n" + unidadAdministrativa.id_ua);
            System.Diagnostics.Debug.Write(uaNombre.Text + " ");
            System.Diagnostics.Debug.Write(uaDescCorta.Text + " ");
            System.Diagnostics.Debug.Write(uaDescLarga.Text + "\n");
            bool respuestaServicio = uaServicios.modificarUA(unidadAdministrativa);

            if (respuestaServicio)
            {
                Response.Redirect("AdministradorUnidadAdministrativa.aspx");
            }
            else
            {
                dangerAlert.Visible = false;
                dangerAlert.Visible = true;
                alertDangerMessage.Text = "No se pudo modificar la unidad administrativa";
            }
        }
    }
}