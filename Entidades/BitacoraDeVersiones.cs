using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BitacoraDeVersiones
    {
        public int id_Bitacora { get; set; }
        public string nombre_usuario { get; set; }
        public string fecha_de_operacion { get; set; }
        public string descripcion { get; set; }

        public BitacoraDeVersiones() { }

        public BitacoraDeVersiones(string nombre_usuario, string fecha_de_operacion, string descripcion)
        {
            this.nombre_usuario = nombre_usuario;
            this.fecha_de_operacion = fecha_de_operacion;
            this.descripcion = descripcion;
        }

        public BitacoraDeVersiones(int id_Bitacora, string nombre_usuario, string fecha_de_operacion, string descripcion)
        {
            this.id_Bitacora = id_Bitacora;
            this.nombre_usuario = nombre_usuario;
            this.fecha_de_operacion = fecha_de_operacion;
            this.descripcion = descripcion;
        }
    }
}
