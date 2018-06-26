using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAGAW.Administracion
{
    public partial class BackupRestore : System.Web.UI.Page
    {
        BackupRestoreServicios backupServicios = new BackupRestoreServicios();

        protected void Page_Load(object sender, EventArgs e)
        {
           // lblMenssage.Text = "El restore fue realizado exitosamente";
        }

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            string message = backupServicios.generarBackup();

            lblMenssage.Text = "Mensaje: " + message;
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            string message = backupServicios.ejecutarRestore();

            lblMenssage.Text = "Mensaje: " + message;
        }
    }
}