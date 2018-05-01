using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aplicacion
    {
        public int idApp { get; set; }
        public String nombre_largo { get; set; }
        public String nombre_corto { get; set; }
        public String descrp_larga { get; set; }
        public String descrp_corta { get; set; }
        public String version { get; set; }
        public String habilitado { get; set; }
        public String codigo { get; set; }
        public String paquete { get; set; }
        public String url { get; set; }
        public String servidor { get; set; }
        public String imagenUrl { get; set; }     
    }
}
