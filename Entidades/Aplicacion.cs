using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aplicacion
    {
        public int id_aplicacion { get; set; }
        public String nombre_largo_aplicacion { get; set; }
        public String nombre_corto_aplicacion { get; set; }
        public String descripcion_larga_app { get; set; }
        public String descripcion_corta_app { get; set; }
        public String version_aplicacion { get; set; }
        public String habilitado_aplicacion { get; set; }
        public String codigo_aplicacion { get; set; }
        public String paquete_instalacion { get; set; }
        public String url { get; set; }
        public String tipo_servidor { get; set; }
        public UnidadAdministrativa unidad { get; set; }
        public String imagen { get; set; }

        public Aplicacion(int id_aplicacion, String nombre_largo_aplicacion, String nombre_corto_aplicacion,
        String descripcion_larga_app, String descripcion_corta_app, String version_aplicacion, String habilitado_aplicacion,
        String codigo_aplicacion, String paquete_instalacion, String url, String tipo_servidor, UnidadAdministrativa unidad, String imagen)
        {
            this.id_aplicacion = id_aplicacion;
            this.nombre_largo_aplicacion = nombre_largo_aplicacion;
            this.nombre_corto_aplicacion = nombre_corto_aplicacion;
            this.descripcion_larga_app = descripcion_larga_app;
            this.descripcion_corta_app = descripcion_corta_app;
            this.version_aplicacion = version_aplicacion;
            this.habilitado_aplicacion = habilitado_aplicacion;
            this.codigo_aplicacion = codigo_aplicacion;
            this.paquete_instalacion = paquete_instalacion;
            this.url = url;
            this.tipo_servidor = tipo_servidor;
            this.unidad = unidad;
            this.imagen = imagen;
        }

        public Aplicacion() { }
 
    }
}
