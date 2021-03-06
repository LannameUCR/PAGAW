﻿using Entidades;
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
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);


       
        //public static string path = "\\\\issac\\AppFiles\\CTL\\AT\\";

        #region variables globales
        AplicacionServicios appServicios = new AplicacionServicios();
        UnidadAdministrativaServicios unidadServicios = new UnidadAdministrativaServicios();

        #endregion

        //public static string path = "../Images/img/";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindRepeater();

        }
        private void BindRepeater()
        {
            List<UnidadAdministrativa> listaUnidades = unidadServicios.getUAs();

            dpUnidadAdministrativa.DataSource = listaUnidades;
            dpUnidadAdministrativa.DataTextField = "nombre_ua";
            dpUnidadAdministrativa.DataValueField = "id_ua";
            dpUnidadAdministrativa.DataBind();
        }
        protected void BtnInsertar_Click(object sender, EventArgs e)
        {
            int anno = DateTime.Today.Year;
            path = path.Remove(0, 6);
            path = path.Remove(path.Length - 9);
            string pathImage = path+ "PAGAW\\Images\\img";
            string pathZIP = path + "PAGAW\\ZIP\\zip";
            string pathPaquete = path + "PAGAW\\PAQUETE\\codigo";
            string imagePath = SaveFile(fuImagen, anno, pathImage);

            string zipPath = SaveFile(fupCodigoZip, anno, pathZIP);
            string paquetePath = SaveFile(fuCodigoFuente, anno, pathPaquete);
           
            var tipoServidor = ddlTipoServidor.SelectedItem.Text;

            string [] array = imagePath.Split('\\');


            UnidadAdministrativa unidad = new UnidadAdministrativa();
            unidad.id_ua = Convert.ToInt32(dpUnidadAdministrativa.SelectedValue.ToString());
            Aplicacion aplicacion = new Aplicacion(0, txtNombreLargo.Text, txtNombreCorto.Text, txtDescripcion_larga.Text, txtDescripcion_corta.Text,
            txtVersion_aplicacion.Text, "1", zipPath, paquetePath, txtUrlServidor.Text, tipoServidor,unidad, "~\\Images\\img" + anno +"\\"+ array[10]);

            appServicios.insertarAplicacion(aplicacion);
            String url = Page.ResolveUrl("~/AdministradorAplicaciones.aspx?servidor=" + tipoServidor);

            Response.Redirect(url);
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
                return pathToCheck; //El archivo existe
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
            String url = Page.ResolveUrl("~/AdministradorAplicaciones.aspx");
            Response.Redirect(url);
        }

        protected void dpUnidadAdministrativa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}