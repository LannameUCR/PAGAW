using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Servicios
{
    public class UnidadAdministrativaServicios
    {
        #region variables globales
        UnidadAdministrativaDatos uaDatos = new UnidadAdministrativaDatos();
        #endregion

        public List<UnidadAdministrativa> getUnidades()
        {
            return uaDatos.obtenerUnidadesAdministrativas();
        }
    }
}
