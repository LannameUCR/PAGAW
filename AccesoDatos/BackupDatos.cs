using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;


using System.IO;
using System.IO.Compression;

namespace AccesoDatos
{
    public class BackupDatos
    {
        #region
            private ConexionDatos conexion = new ConexionDatos();
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        #endregion


        public string respaldarDatos() {

            string message = "";

            /*Path de los archivos que requieren respaldo*/
            path = path.Remove(0, 6);
            path = path.Remove(path.Length - 9);
            string pathImage = path + "Images";
            string pathZIP = path + "ZIP";
            string pathPaquete = path + "PAQUETE";
            string pathFile = @"c:\FullBackupPAGAW";

            /*Path del directorio donde se guardan los backups*/
            string zipPathImage = @"c:\FullBackupPAGAW\image.zip";
            string zipPathZIP = @"c:\FullBackupPAGAW\ZIP.zip";
            string zipPathPAQUETE = @"c:\FullBackupPAGAW\PAQUETE.zip";

            //ZipFile.ExtractToDirectory(zipPath, extractPath);

            try
            {
                /*Se crea el directorio donde se guardará los backups, debido a que puede darse el 
                 * caso de que nos exista
                 */
                System.IO.Directory.CreateDirectory(pathFile);

                /*Se eliminan los archivos de backups viejos*/
                System.IO.File.Delete(zipPathImage);
                System.IO.File.Delete(zipPathZIP);
                System.IO.File.Delete(zipPathPAQUETE);
                System.IO.File.Delete(@"c:\FullBackupPAGAW\PAGAW.bak");

                /*Se generan los nuevos backups*/
                ZipFile.CreateFromDirectory(pathImage, zipPathImage);
                ZipFile.CreateFromDirectory(pathZIP, zipPathZIP);
                ZipFile.CreateFromDirectory(pathPaquete, zipPathPAQUETE);
                //ZipFile.CreateFromDirectory(masterPath, globalMasterPath);

                string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlConnection cnn = new SqlConnection(conn);

                SqlCommand cmd = new SqlCommand("backupdb", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();

                cmd.ExecuteNonQuery();

                message = "El backup fue realizado exitosamente";
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }








            return message;
        }
    }
}
