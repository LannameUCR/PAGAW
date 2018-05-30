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

                app.id_aplicacion = Convert.ToInt32(reader["id_aplicacion"].ToString());
                app.nombre_largo_aplicacion = reader["nombre_largo_aplicacion"].ToString();
                app.nombre_corto_aplicacion = reader["nombre_corto_aplicacion"].ToString();
                app.descripcion_larga_app = reader["descripcion_larga_app"].ToString();
                app.descripcion_corta_app = reader["descripcion_corta_app"].ToString();
                app.version_aplicacion = reader["version_aplicacion"].ToString();
                app.habilitado_aplicacion = reader["habilitado_aplicacion"].ToString();
                app.codigo_aplicacion = reader["codigo_aplicacion"].ToString();
                app.paquete_instalacion = reader["paquete_instalacion"].ToString();
                app.url = reader["url"].ToString();
                app.tipo_servidor = reader["tipo_servidor"].ToString();
                app.imagen = reader["imagen"].ToString();

                listaApps.Add(app);

            }
            sqlConnection.Close();
            return listaApps;

        }

        /**/
        public List<Aplicacion> getAplicacionPorNombre(string nombreAplicacion)
        {
            List<Aplicacion> listaApps = new List<Aplicacion>();
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "";

            sql = "sp_obtener_aplicacion_por_nombre";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            //definir el parametro no output
            SqlParameter nombre_plicacion = new SqlParameter("@nombre_aplicacion", nombreAplicacion);
            cmd.Parameters.Add(nombre_plicacion);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Aplicacion app = new Aplicacion();

                app.id_aplicacion = Convert.ToInt32(reader["id_aplicacion"].ToString());
                app.nombre_largo_aplicacion = reader["nombre_largo_aplicacion"].ToString();
                app.nombre_corto_aplicacion = reader["nombre_corto_aplicacion"].ToString();
                app.descripcion_larga_app = reader["descripcion_larga_app"].ToString();
                app.descripcion_larga_app = reader["descripcion_corta_app"].ToString();
                app.descripcion_larga_app = reader["version_aplicacion"].ToString();
                app.descripcion_larga_app = reader["habilitado_aplicacion"].ToString();
                app.descripcion_larga_app = reader["codigo_aplicacion"].ToString();
                app.descripcion_larga_app = reader["paquete_instalacion"].ToString();
                app.descripcion_larga_app = reader["url"].ToString();
                app.descripcion_larga_app = reader["tipo_servidor"].ToString();
                app.descripcion_larga_app = reader["imagen"].ToString();

                listaApps.Add(app);
            }

            sqlConnection.Close();

            return listaApps;
        }

        public List<Aplicacion> getAplicacionPorUnidadAdministrativa(int idUnidadAdministrativa)
        {
            List<Aplicacion> listaApps = new List<Aplicacion>();
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "";

            sql = "sp_obtener_aplicacion_por_unidad_administrativa";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            //definir el parametro no output
            SqlParameter nombre_ua = new SqlParameter("@id_ua", idUnidadAdministrativa);
            cmd.Parameters.Add(nombre_ua);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Aplicacion app = new Aplicacion();

                app.id_aplicacion = Convert.ToInt32(reader["id_aplicacion"].ToString());
                app.nombre_largo_aplicacion = reader["nombre_largo_aplicacion"].ToString();
                app.nombre_corto_aplicacion = reader["nombre_corto_aplicacion"].ToString();
                app.descripcion_larga_app = reader["descripcion_larga_app"].ToString();
                app.descripcion_larga_app = reader["descripcion_corta_app"].ToString();
                app.descripcion_larga_app = reader["version_aplicacion"].ToString();
                app.descripcion_larga_app = reader["habilitado_aplicacion"].ToString();
                app.descripcion_larga_app = reader["codigo_aplicacion"].ToString();
                app.descripcion_larga_app = reader["paquete_instalacion"].ToString();
                app.descripcion_larga_app = reader["url"].ToString();
                app.descripcion_larga_app = reader["tipo_servidor"].ToString();
                app.descripcion_larga_app = reader["imagen"].ToString();

                listaApps.Add(app);
            }

            sqlConnection.Close();

            return listaApps;
        }

        public void InsertarApplicacion(Aplicacion appInsertar)
        {
            SqlConnection sqlConnection = conexion.conexionBI();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Tb_Aplicaciones VALUES('" + appInsertar.nombre_largo_aplicacion + "'," +
                "'" + appInsertar.nombre_corto_aplicacion + "','" + appInsertar.descripcion_larga_app + "','" + appInsertar.descripcion_corta_app + "'," +
                "'" + appInsertar.version_aplicacion + "','" + appInsertar.habilitado_aplicacion + "','" + appInsertar.codigo_aplicacion + "'," +
                "'" + appInsertar.paquete_instalacion + "','" + appInsertar.url + "','" + appInsertar.tipo_servidor + "'," +
                "'" + appInsertar.imagen + "')", sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        public void EliminarApplicacion(Aplicacion appElimimar)
        {
            SqlConnection sqlConnection = conexion.conexionBI();
            SqlCommand sqlCommand = new SqlCommand("Delete from Tb_Aplicaciones " +
                                                   "where id_aplicacion=@idapp", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idapp", appElimimar.id_aplicacion);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        public void ActualizarApplicacion(Aplicacion appInsertar)
        {
            Aplicacion app = appInsertar;
            SqlConnection sqlConnection = conexion.conexionBI();
            SqlCommand sqlCommand = new SqlCommand("UPDATE Tb_Aplicaciones SET nombre_largo_aplicacion='" + appInsertar.nombre_largo_aplicacion + "'," +
                "nombre_corto_aplicacion='" + appInsertar.nombre_corto_aplicacion + "',descripcion_larga_app='" + appInsertar.descripcion_larga_app + "'," +
                "descripcion_corta_app='" + appInsertar.descripcion_corta_app + "',version_aplicacion='" + appInsertar.version_aplicacion + "'," +
                "habilitado_aplicacion='" + appInsertar.habilitado_aplicacion + "',codigo_aplicacion='" + appInsertar.codigo_aplicacion + "'," +
                "paquete_instalacion='" + appInsertar.paquete_instalacion + "',url='" + appInsertar.url + "',tipo_servidor='" + appInsertar.tipo_servidor + "'," +
                "imagen='" + appInsertar.imagen + "' WHERE id_aplicacion=" + appInsertar.id_aplicacion + "", sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

    }
}
