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
    public class BackupRestoreDatos
    {
        #region
            private ConexionDatos conexion = new ConexionDatos();
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        #endregion

        /*Método encargado de hacer el backup de la bd y del contenido del sistema*/
        public string respaldarDatos()
        {
            string message = "";

            /*Path de los archivos que requieren respaldo*/
            path = path.Remove(0, 6);
            path = path.Remove(path.Length - 9);
            string pathImage = path + "PAGAW\\Images";
            string pathZIP = path + "PAGAW\\ZIP";
            string pathPaquete = path + "PAGAW\\PAQUETE";
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

                string conn = WebConfigurationManager.ConnectionStrings["ConnectionStringBackup"].ToString();
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

        /*Método encargado de hacer un restore de la bd*/
        public string restaurarDatos()
        {
            string message = "";

            /*Path de los archivos que requieren respaldo*/
            path = path.Remove(0, 6);
            path = path.Remove(path.Length - 9);
            string pathImage = path + "PAGAW\\Images";
            string pathZIP = path + "PAGAW\\ZIP";
            string pathPaquete = path + "PAGAW\\PAQUETE";
            string pathRestore = path + "PAGAW\\RESTORE"; 

            /*Path del directorio donde se guardan los backups*/
            string zipPathImage = @"c:\FullBackupPAGAW\image.zip";
            string zipPathZIP = @"c:\FullBackupPAGAW\ZIP.zip";
            string zipPathPAQUETE = @"c:\FullBackupPAGAW\PAQUETE.zip";

            try
            {
                //Se eliminan las carpetas restauradas para poder restaurarlas de nuevo
                if (System.IO.Directory.Exists(pathImage) && System.IO.Directory.Exists(pathZIP) && System.IO.Directory.Exists(pathPaquete))
                {
                    System.IO.Directory.Delete(pathImage, true);
                    System.IO.Directory.Delete(pathZIP, true);
                    System.IO.Directory.Delete(pathPaquete, true);
                }

                //Se crea la parte de restore
                System.IO.Directory.CreateDirectory(pathRestore);

                //Se desconprime las imágenes de backup en la carpeta de restore
                ZipFile.ExtractToDirectory(zipPathImage, pathRestore);

                //Se mueve el contenido de la carpeta de restore a la carpeta original de las imágenes
                System.IO.Directory.Move(pathRestore, pathImage);

                //Se desconprime los CÓDIGO ZIP de backup en la carpeta de restore
                ZipFile.ExtractToDirectory(zipPathZIP, pathRestore);

                //Se mueve el contenido de la carpeta de restore a la carpeta original de los CÓDIGO ZIP
                System.IO.Directory.Move(pathRestore, pathZIP);

                //Se desconprime los archivos de PAQUETE DE INSTALACIÓN de backup en la carpeta de restore
                ZipFile.ExtractToDirectory(zipPathPAQUETE, pathRestore);

                //Se mueve el contenido de la carpeta de restore a la carpeta original de los PAQUETE DE INSTALACIÓN
                System.IO.Directory.Move(pathRestore, pathPaquete);

                string conn = WebConfigurationManager.ConnectionStrings["ConnectionStringRestore"].ToString();
                SqlConnection cnn = new SqlConnection(conn);

                SqlCommand cmd = new SqlCommand("restoredb", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();

                cmd.ExecuteNonQuery();

                message = "El restore fue realizado exitosamente";
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }

            return message;
        }
    }
}
