
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace AccesoDatos
{
    public class UnidadAdministrativaDatos
    {
        private ConexionDatos conexion = new ConexionDatos();

        public List<UnidadAdministrativa> getTodasUAs()
        {


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

            }
            sqlConnection.Close();
            return listaUAs;
        }
    }
}
