using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace Servicios
{
    public class UnidadAdministrativaServicios
    {
        UnidadAdministrativaDatos UAdatos = new UnidadAdministrativaDatos();

        public List<UnidadAdministrativa> getUAs()
        {
            return UAdatos.getTodasUAs();
        }
    }
}
