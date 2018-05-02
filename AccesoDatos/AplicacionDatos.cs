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
    public class AplicacionDatos
    {
        private ConexionDatos conexion = new ConexionDatos();

        public List<Aplicacion> getApps()
        {
            List<Aplicacion> listaApps = new List<Aplicacion>();
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "";

            sql = "sp_obtener_aplicaciones";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;
            sqlConnection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Aplicacion app = new Aplicacion();
                app.idApp = Convert.ToInt32(reader["id_aplicacion"].ToString());

                app.nombre = reader["nombre_largo_aplicacion"].ToString();
                app.version = reader["version_aplicacion"].ToString();
                app.descrp_corta = reader["descripcion_corta_app"].ToString();
                app.descrp_larga = reader["descripcion_larga_app"].ToString();
                app.paquete = reader["paquete_instalacion"].ToString();
                app.codigo = reader["codigo_aplicacion"].ToString();

                
                app.url = reader["url"].ToString();
                app.imagenUrl = reader["imagen"].ToString();
                app.servidor = reader["tipo_servidor"].ToString();
                app.estado = reader["habilitado_aplicacion"].ToString();




                listaApps.Add(app);

            }
            sqlConnection.Close();
            return listaApps;

        }

        public void EliminarApplicacion(Aplicacion appElimimar)
        {
            SqlConnection sqlConnection = conexion.conexionBI();
            SqlCommand sqlCommand = new SqlCommand("Delete from Tb_Aplicaciones " +
                                                   "where id_aplicacion=@idapp", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idapp", appElimimar.idApp);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }
    }
}
