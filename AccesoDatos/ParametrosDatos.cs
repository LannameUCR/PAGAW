using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ParametrosDatos
    {
        private ConexionDatos conexion = new ConexionDatos();

        public void obtenerParametros()
        {           
            SqlConnection sqlConnection = conexion.conexionBI();
            String sql = "sp_obtener_parametros";            

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;
            sqlConnection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Parametros.getInstance().CantidadRegistros = Convert.ToInt32(reader["cantidad_registros"]);
                Parametros.getInstance().RutaPruebas = reader["ruta_absoluta_Spruebas"].ToString();
                Parametros.getInstance().RutaProduccion = reader["ruta_absoluta_Sproduccion"].ToString();
                Parametros.getInstance().RutaArchivos = reader["ruta_absoluta_Sarchivos"].ToString();
                Parametros.getInstance().CuentaCorreo = reader["cuenta_correo"].ToString();
                Parametros.getInstance().Contrasena = reader["contrasena"].ToString(); 
            }
            sqlConnection.Close();            
        }

        public bool cargarParametrosPorDefecto()
        {
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "sp_cargar_parametros_por_defecto";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;
            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader == null)
            {
                return false;
            }
            while (reader.Read())
            {
                Parametros.getInstance().CantidadRegistros = Convert.ToInt32(reader["cantidad_registros"]);
                Parametros.getInstance().RutaPruebas = reader["ruta_absoluta_Spruebas"].ToString();
                Parametros.getInstance().RutaProduccion = reader["ruta_absoluta_Sproduccion"].ToString();
                Parametros.getInstance().RutaArchivos = reader["ruta_absoluta_Sarchivos"].ToString();
                Parametros.getInstance().CuentaCorreo = reader["cuenta_correo"].ToString();
                Parametros.getInstance().Contrasena = reader["contrasena"].ToString();
            }
            sqlConnection.Close();
            return true;
        }

        public bool modificarParametros()
        {
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "sp_modificar_parametros";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("cantidadRegistros", SqlDbType.Int).Value = Parametros.getInstance().CantidadRegistros;
            cmd.Parameters.Add("rutaPruebas ", SqlDbType.NVarChar).Value = Parametros.getInstance().RutaPruebas;
            cmd.Parameters.Add("rutaProduccion", SqlDbType.NVarChar).Value = Parametros.getInstance().RutaProduccion;
            cmd.Parameters.Add("rutaArchivos", SqlDbType.NVarChar).Value = Parametros.getInstance().RutaArchivos;
            cmd.Parameters.Add("cuentaCorreo", SqlDbType.NVarChar).Value = Parametros.getInstance().CuentaCorreo;
            cmd.Parameters.Add("contrasena", SqlDbType.NVarChar).Value = Parametros.getInstance().Contrasena;

            sqlConnection.Open();

            if (cmd.ExecuteNonQuery() > 0)
            {
                sqlConnection.Close();
                return true;
            }
            else
            {
                sqlConnection.Close();
                return false;
            }
        }
    }
}