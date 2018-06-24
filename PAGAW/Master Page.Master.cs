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
    public partial class Master_Page : System.Web.UI.MasterPage
    {
        ParametrosServicios parametrosServicios = new ParametrosServicios();
        BackupServicios backupServicios = new BackupServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombreCompleto"] != null)
            {
                username.InnerText = "Bienvenid@ " + Session["nombreCompleto"].ToString();
                Page.Master.FindControl("MenuAdministrador").Visible = true;
                Page.Master.FindControl("menu_normal").Visible = false;
                Page.Master.FindControl("sessionLink").Visible = false;   
                Page.Master.FindControl("username").Visible = true;
                Page.Master.FindControl("BtnSalir").Visible = true;
            }
            else {
            }

            if (Session["parametros"] == null)
            {
                parametrosServicios.obtenerParametros();
                Session["parametros"] = true;
            }
        }
        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            String url = Page.ResolveUrl("~/Login.aspx");
            Response.Redirect(url);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            String url = Page.ResolveUrl("~/Login.aspx");
            Response.Redirect(url);
        }

        protected void BtnBackup_Click(object sender, EventArgs e)
        {
            backupServicios.generarBackup();
        }
    }
}