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
        public Hashtable hashUnidadesAdministivas { get; set; }
        public List<UnidadAdministrativa> obtenerUnidadesAdministrativas()
        {
            hashUnidadesAdministivas = new Hashtable();
            List<UnidadAdministrativa> listaUnidadesAdministivas = new List<UnidadAdministrativa>();
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "";

            sql = "obtener_unidades_administrativas";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;
            sqlConnection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                UnidadAdministrativa unidadAdministrativa = new UnidadAdministrativa();
                unidadAdministrativa.id_ua = Convert.ToInt32(reader["id_ua"].ToString());
                unidadAdministrativa.nombre_ua= reader["nombre_ua"].ToString();
                unidadAdministrativa.descripcion_larga = reader["descripcion_larga"].ToString();
                unidadAdministrativa.descripcion_corta = reader["descripcion_corta"].ToString();
                listaUnidadesAdministivas.Add(unidadAdministrativa);
                hashUnidadesAdministivas.Add(unidadAdministrativa.id_ua, unidadAdministrativa);
            }
            sqlConnection.Close();
            return listaUnidadesAdministivas;
        }
    }
}
