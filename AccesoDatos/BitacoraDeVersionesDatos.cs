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
    public class BitacoraDeVersionesDatos
    {
        private ConexionDatos conexion = new ConexionDatos();

        public List<BitacoraDeVersiones> obtenerDatoBitacoraVersiones()
        {
            List<BitacoraDeVersiones> listaBitacoraVersiones = new List<BitacoraDeVersiones>();
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "";

            sql = "sp_obtener_bitacora_versiones";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;
            sqlConnection.Open();
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                BitacoraDeVersiones bitacora = new BitacoraDeVersiones();

                bitacora.id_Bitacora = Convert.ToInt32(reader["id_Bitacora"].ToString());
                bitacora.nombre_usuario = reader["nombre_usuario"].ToString();

                string[] array = reader["fecha_de_operacion"].ToString().Split(' ');
                bitacora.fecha_de_operacion = array[0];

                bitacora.descripcion = reader["descripcion"].ToString();

                listaBitacoraVersiones.Add(bitacora);

            }

            sqlConnection.Close();
            return listaBitacoraVersiones;

        }

        public void insertarDatoBitacoraVersiones(BitacoraDeVersiones bitacora)
        {
            SqlConnection sqlConnection = conexion.conexionBI();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Tb_bitacora_Versiones VALUES('" + bitacora.nombre_usuario + "'," +
                "'" + bitacora.fecha_de_operacion + "','" + bitacora.descripcion + "')", sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        public void actualizarDatoBitacoraVersiones(BitacoraDeVersiones bitacora)
        {
            SqlConnection sqlConnection = conexion.conexionBI();
            SqlCommand sqlCommand = new SqlCommand("UPDATE Tb_bitacora_Versiones SET descripcion = '" + bitacora.descripcion + "' WHERE id_Bitacora="+ bitacora.id_Bitacora + "", sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }
    }
}
