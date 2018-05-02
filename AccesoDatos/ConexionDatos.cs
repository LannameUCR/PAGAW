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

        /*
         * Lucrecia Zuñiga Sae
         29/04/201
         * metodo que se utiliza para loguearse a la aplicacion 
         * recibe el nombre de usuario que se loguea
         * devuelve el id del rol del usuario y el nombre completo del usuario en un vector
         */
        public object[] loguearse(String usuario , String contrasena)
        {
            object[] rolNombreCompleto = new object[2];
            SqlConnection sqlConnection = conexionLogin();
            //conexion Lanamme
            /*  SqlCommand sqlCommand = new SqlCommand("select R.id_rol, U.nombre_completo from " +
                  "Rol R, Usuario U, Aplicacion A, Usuario_Rol_Aplicacion URA " +
                  "where A.nombre_aplicacion='Bienes Institucionales' and U.usuario=@usuario and URA.id_aplicacion=A.id_aplicacion and " +
                  "URA.id_usuario = u.id_usuario and R.id_rol = URA.id_rol ;", sqlConnection);
              sqlCommand.Parameters.AddWithValue("@usuario", usuario.ToLower());
              */
            SqlCommand sqlCommand = new SqlCommand("select rol, nombre_usuario from  usuario where  nombre_usuario=@usuario and contrasena = @contrasena ;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@usuario", usuario.ToLower());
            sqlCommand.Parameters.AddWithValue("@contrasena", contrasena.ToLower());
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {

                int rol = Int32.Parse(reader.GetValue(0).ToString());
                String nombreCompleto = reader.GetValue(1).ToString();

                rolNombreCompleto[0] = rol;
                rolNombreCompleto[1] = nombreCompleto;
            }

            sqlConnection.Close();

            return rolNombreCompleto;
        }





    }
}