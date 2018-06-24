using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BackupServicios
    {
        #region variables globales
        BackupDatos backupDatos = new BackupDatos();
        #endregion

        public string generarBackup() {
            string message = "";

            message = backupDatos.respaldarDatos();

            return message;
        }
    }
}
