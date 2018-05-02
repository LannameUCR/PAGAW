using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAGAW.Administracion
{
    public partial class InsertarAplicacion : System.Web.UI.Page
    {
        public static string pathImage = "C:\\Users\\Danny\\Desktop\\PAGAW-Iteracion1_LucreciaZu-iga_Terminado\\PAGAW\\Images\\img";
        public static string pathZIP = "C:\\Users\\Danny\\Desktop\\PAGAW-Iteracion1_LucreciaZu-iga_Terminado\\PAGAW\\ZIP\\zip";
        public static string pathPaquete = "C:\\Users\\Danny\\Desktop\\PAGAW-Iteracion1_LucreciaZu-iga_Terminado\\PAGAW\\PAQUETE\\codigo"; 
        //public static string path = "\\\\issac\\AppFiles\\CTL\\AT\\";

        #region variables globales
        AplicacionServicios appServicios = new AplicacionServicios();
        #endregion

        //public static string path = "../Images/img/";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInsertar_Click(object sender, EventArgs e)
        {
            int anno = DateTime.Today.Year;

            string imagePath = SaveFile(fuImagen, anno, pathImage);
            string zipPath = SaveFile(fuImagen, anno, pathZIP);
            string paquetePath = SaveFile(fuImagen, anno, pathPaquete);
            

            var tipoServidor = ddlTipoServidor.SelectedItem.Text;

            Aplicacion aplicacion = new Aplicacion(0, txtNombreLargo.Text, txtNombreCorto.Text, txtDescripcion_larga.Text, txtDescripcion_corta.Text,
            txtVersion_aplicacion.Text, "1", zipPath, paquetePath, txtUrlServidor.Text, tipoServidor, "", imagePath);

            appServicios.insertarAplicacion(aplicacion);
        }

        public static string SaveFile(System.Web.UI.WebControls.FileUpload fuImagen, int year, string path)
        {
            // Obtener el nombre del archivo que desea cargar.
            string archivo = fuImagen.FileName;
            
            /*Se obtiene la extensión del archivo*/
            FileInfo fi = new FileInfo(archivo);
            string ext = fi.Extension;

            /*Se obtiene el nombre y la extrensión del archivo*/
            String[] substrings = fi.Name.Split('.');

            // Path del directorio donde vamos a guardar el archivo
            string pathToCheck = path + year;

            //Verificamos si existe el directorio, sino existe se crea
            if (!Directory.Exists(pathToCheck))
            {
                Directory.CreateDirectory(pathToCheck);
            }

            // Crear la ruta y el nombre del archivo para comprobar si hay duplicados.
            pathToCheck = pathToCheck + "\\" + substrings[0] + ext;
            // Compruebe si ya existe un archivo con el
            // mismo nombre que el archivo que desea cargar .       
            if ((System.IO.File.Exists(pathToCheck)))
            {
                return null; //El archivo existe
            }
            else
            {
                // Llame al método SaveAs para guardar el archivo
                // guardado en el directorio especificado.
                fuImagen.SaveAs(pathToCheck);

                return pathToCheck;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdministradorAplicaciones.aspx");
        }
    }
}