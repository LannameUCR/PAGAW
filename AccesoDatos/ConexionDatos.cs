using Entidades;
using System;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class ConexionDatos
    {

        BaseDatos baseDatos = new BaseDatos();
        Archivo archivo = new Archivo();
        public SqlConnection conexionLogin()
        { 

            baseDatos = archivo.leerArchivo();

            SqlConnection conn = new SqlConnection();

            String ConnStr = @"Data Source=" + baseDatos.servidorLogin + ";Initial Catalog=" + baseDatos.baseLogin + ";User ID=" + baseDatos.usuarioLogin + ";Password=" + baseDatos.contrasenaLogin + ";Trusted_Connection=False; ";

            conn.ConnectionString = ConnStr;
            return conn;
        }

        /*
         * Lucrecia Zuñiga Sae
         29/04/201
     *
     *Metodo que lee el del archivo los datos del servidor y establece la coneccion 
     */
        public SqlConnection conexionBI()
        {
            baseDatos = archivo.leerArchivo();
            SqlConnection conn = new SqlConnection();

            String ConnStr = @"Data Source=" + baseDatos.servidorBI + ";Initial Catalog=" + baseDatos.baseBI + ";User ID=" + baseDatos.usuarioBI + ";Password=" + baseDatos.contrasenaBI + ";Trusted_Connection=False; ";

            conn.ConnectionString = ConnStr;
            return conn;
        }


     

    }
}