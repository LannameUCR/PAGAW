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
    public partial class ActualizarAplicacion : System.Web.UI.Page
    {
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

        //public static string path = "\\\\issac\\AppFiles\\CTL\\AT\\";

        #region variables globales
        AplicacionServicios appServicios = new AplicacionServicios();
        List<ObjectoFileChooser> listaObjetoFileChooser = new List<ObjectoFileChooser>();
        UnidadAdministrativaServicios unidadServicios = new UnidadAdministrativaServicios();
        AplicacionServicios appService = new AplicacionServicios();
        String tipoServidor = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (!IsPostBack)
            {

                Aplicacion appActualizar = (Aplicacion)Session["appActualizar"];
                txtIdApp.Text = appActualizar.id_aplicacion + "";
                txtNombreLargo.Text = appActualizar.nombre_largo_aplicacion;
                txtNombreCorto.Text = appActualizar.nombre_corto_aplicacion;
                txtDescripcion_larga.Text = appActualizar.descripcion_larga_app;
                txtDescripcion_corta.Text = appActualizar.descripcion_corta_app;

                txtVersion_aplicacion.Text = appActualizar.version_aplicacion;
                txtUrlServidor.Text = appActualizar.url;
                tipoServidor = appActualizar.tipo_servidor;
                //
                txtImagenAplicacion.Visible = false;
                rpImagenAplicacion.Visible = true;

                txtCodigoZIP.Visible = false;
                rpCodigoZIP.Visible = true;

                txtCodigoFuente.Visible = false;
                rpCodigoFuente.Visible = true;

                ddlTipoServidor.Items.FindByValue(appActualizar.tipo_servidor.ToString()).Selected = true;

                
              //  dpUnidadAdministrativa.Items.FindByValue(appActualizar.unidad.id_ua.ToString()).Selected = true;


                //Imagen de aplicación
                listaObjetoFileChooser.Add(new ObjectoFileChooser(appActualizar.id_aplicacion, appActualizar.imagen, appActualizar.imagen));

                rpImagenAplicacion.DataSource = listaObjetoFileChooser;
                rpImagenAplicacion.DataBind();

                //Código ZIP de aplicación
                listaObjetoFileChooser.Clear();
                listaObjetoFileChooser.Add(new ObjectoFileChooser(appActualizar.id_aplicacion, appActualizar.paquete_instalacion, appActualizar.paquete_instalacion));

                rpCodigoZIP.DataSource = listaObjetoFileChooser;
                rpCodigoZIP.DataBind();

                //Código fuente de aplicación
                listaObjetoFileChooser.Clear();
                listaObjetoFileChooser.Add(new ObjectoFileChooser(appActualizar.id_aplicacion, appActualizar.codigo_aplicacion, appActualizar.codigo_aplicacion));

                rpCodigoFuente.DataSource = listaObjetoFileChooser;
                rpCodigoFuente.DataBind();

                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {
            List<UnidadAdministrativa> listaUnidades = unidadServicios.getUAs();

            dpUnidadAdministrativa.DataSource = listaUnidades;
            dpUnidadAdministrativa.DataTextField = "nombre_ua";
            dpUnidadAdministrativa.DataValueField = "id_ua";
            dpUnidadAdministrativa.DataBind();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int anno = DateTime.Today.Year;
            path = path.Remove(0, 6);
            path = path.Remove(path.Length - 9);
            string pathImage = path + "Images\\img";
            string pathZIP = path + "ZIP\\zip";
            string pathPaquete = path + "PAQUETE\\codigo";
            string imagePath = SaveFile(fuImagen, anno, pathImage);
            string zipPath = SaveFile(fupCodigoZip, anno, pathZIP);
            string paquetePath = SaveFile(fuCodigoFuente, anno, pathPaquete);

            var tipoServidor = ddlTipoServidor.SelectedItem.Text;
            UnidadAdministrativa unidad = new UnidadAdministrativa();
            unidad.id_ua=Convert.ToInt32(dpUnidadAdministrativa.SelectedValue.ToString());
            Aplicacion aplicacion = new Aplicacion(Int32.Parse(txtIdApp.Text), txtNombreLargo.Text, txtNombreCorto.Text, txtDescripcion_larga.Text, txtDescripcion_corta.Text,
            txtVersion_aplicacion.Text, "1", zipPath, paquetePath, txtUrlServidor.Text, tipoServidor, unidad, imagePath);

            appServicios.actualizarAplicacion(aplicacion);

      
            String url = Page.ResolveUrl("~/AdministradorAplicaciones.aspx?servidor=" + tipoServidor);
            Response.Redirect(url);
        }

        public static string SaveFile(System.Web.UI.WebControls.FileUpload fuImagen, int year, string path)
        {
            // Obtener el nombre del archivo que desea cargar.
            string archivo = fuImagen.FileName;
            String url = path + archivo;
            /*Se obtiene la extensión del archivo*/
            FileInfo fi = new FileInfo(url);
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
            Aplicacion appServer = (Aplicacion)Session["appActualizar"];
            tipoServidor = appServer.tipo_servidor;
            String url = Page.ResolveUrl("~/AdministradorAplicaciones.aspx?servidor=" + tipoServidor);
            Response.Redirect(url);
        }

        protected void dpUnidadAdministrativa_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}