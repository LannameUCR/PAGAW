using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BackupRestoreServicios
    {
        #region variables globales
        BackupRestoreDatos backupRestoreDatos = new BackupRestoreDatos();
        #endregion

        public string generarBackup() {
            string message = "";

            message = backupRestoreDatos.respaldarDatos();

            return message;
        }

        public string ejecutarRestore()
        {
            string message = "";

            message = backupRestoreDatos.restaurarDatos();

            return message;
        }
    }
}
