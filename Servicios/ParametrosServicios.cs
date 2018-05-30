using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ParametrosServicios
    {
        ParametrosDatos parametrosDatos = new ParametrosDatos();

        public void obtenerParametros()
        {
            parametrosDatos.obtenerParametros();
        }

        public bool cargarParametrosPorDefecto()
        {
            return parametrosDatos.cargarParametrosPorDefecto();
        }

        public bool modificarParametros()
        {
            return parametrosDatos.modificarParametros();
        }
    }
}
