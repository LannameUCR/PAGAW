using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UnidadAdministrativa
    {
        public int id_ua { get; set; }
        public string nombre_ua { get; set; }
        public string descripcion_larga { get; set; }
        public string descripcion_corta { get; set; }

        public UnidadAdministrativa(int id_ua, string nombre_ua, string descripcion_corta, string descripcion_larga)
        {
            this.id_ua = id_ua;
            this.nombre_ua = nombre_ua;
            this.descripcion_corta = descripcion_corta;
            this.descripcion_larga = descripcion_larga;
        }

        public UnidadAdministrativa() { }

        public UnidadAdministrativa(string nombre_ua, string descripcion_larga, string descripcion_corta)
        {
            this.nombre_ua = nombre_ua;
            this.descripcion_larga = descripcion_larga;
            this.descripcion_corta = descripcion_corta;
        }
    }
}
