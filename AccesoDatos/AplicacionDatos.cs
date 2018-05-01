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
    public class AplicacionDatos
    {
        private ConexionDatos conexion = new ConexionDatos();
        public Hashtable hashApps { get; set; }
        public List<Aplicacion> getApps()
        {
            hashApps = new Hashtable();
            List<Aplicacion> listaApps = new List<Aplicacion>();
            SqlConnection sqlConnection = conexion.conexionBI();

            String sql = "";

            sql = "get_aplicaciones";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;
            sqlConnection.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Aplicacion app = new Aplicacion();
                app.idApp = Convert.ToInt32(reader["id_aplicacion"].ToString());
                app.nombre_largo = reader["nombre_largo_aplicacion"].ToString();
                app.nombre_corto = reader["nombre_corto_aplicacion"].ToString();
                app.descrp_larga = reader["descripcion_larga_app"].ToString();
                app.descrp_corta = reader["descripcion_corta_app"].ToString();                
                app.version = reader["version_aplicacion"].ToString();
                app.habilitado = reader["habilitado_aplicacion"].ToString();
                app.codigo = reader["codigo_aplicacion"].ToString();
                app.paquete = reader["paquete_instalacion"].ToString();                               
                app.url = reader["url"].ToString();
                app.servidor = reader["tipo_servidor"].ToString();
                app.imagenUrl = reader["imagen"].ToString();                               
                listaApps.Add(app);
                hashApps.Add(app.idApp, app);
            }
            sqlConnection.Close();
            return listaApps;
        }
    }
}
