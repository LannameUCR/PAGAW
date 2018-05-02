
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace AccesoDatos
{
    public class UnidadAdministrativaDatos
    {
        private ConexionDatos conexion = new ConexionDatos();
        public static Hashtable hashUA;

        public List<UnidadAdministrativa> getTodasUAs()
        {
            hashUA = new Hashtable();
            List<UnidadAdministrativa> listaUAs = new List<UnidadAdministrativa>();
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "";

            sql = "getTodasUnidadesAdministrativas";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;
            sqlConnection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                UnidadAdministrativa ua = new UnidadAdministrativa();

                ua.id_ua = Convert.ToInt32(reader["id_ua"].ToString());

                ua.nombre_ua = reader["nombre_ua"].ToString();
                ua.descripcion_corta = reader["descripcion_corta"].ToString();

                ua.descripcion_larga = reader["descripcion_larga"].ToString();
                listaUAs.Add(ua);
                hashUA.Add(ua.id_ua, ua);
            }
            sqlConnection.Close();
            return listaUAs;
        }

        public bool agregarUnidadAdministrativa(UnidadAdministrativa unidadAdministrativa)
        {
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "sp_agregar_unidad_administrativa";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("nombre", SqlDbType.NVarChar).Value = unidadAdministrativa.nombre_ua;
            cmd.Parameters.Add("descripcion_larga", SqlDbType.NVarChar).Value = unidadAdministrativa.descripcion_larga;
            cmd.Parameters.Add("descripcion_corta", SqlDbType.NVarChar).Value = unidadAdministrativa.descripcion_corta;

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

        public bool modificarUA(UnidadAdministrativa unidadAdministrativa)
        {
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "sp_modificar_unidad_administrativa";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("idUA", SqlDbType.NVarChar).Value = unidadAdministrativa.id_ua;
            cmd.Parameters.Add("nombre", SqlDbType.NVarChar).Value = unidadAdministrativa.nombre_ua;
            cmd.Parameters.Add("descripcion_larga", SqlDbType.NVarChar).Value = unidadAdministrativa.descripcion_larga;
            cmd.Parameters.Add("descripcion_corta", SqlDbType.NVarChar).Value = unidadAdministrativa.descripcion_corta;

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
