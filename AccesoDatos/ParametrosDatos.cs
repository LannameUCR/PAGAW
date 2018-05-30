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
            }
            sqlConnection.Close();            
        }

        public void cargarParametrosPorDefecto()
        {
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "sp_cargar_parametros_por_defecto";
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
            }
            sqlConnection.Close();
        }

        public bool modificarParametros()
        {
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "sp_modificar_parametros";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("cantidad_registros", SqlDbType.Int).Value = Parametros.getInstance().CantidadRegistros;
            cmd.Parameters.Add("ruta_absoluta_Spruebas", SqlDbType.NVarChar).Value = Parametros.getInstance().RutaPruebas;
            cmd.Parameters.Add("ruta_absoluta_Sproduccion", SqlDbType.NVarChar).Value = Parametros.getInstance().RutaProduccion;
            cmd.Parameters.Add("ruta_absoluta_Sarchivos", SqlDbType.NVarChar).Value = Parametros.getInstance().RutaArchivos;

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