using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;
using System.Collections;

namespace Servicios
{
    public class UnidadAdministrativaServicios
    {
        UnidadAdministrativaDatos UAdatos = new UnidadAdministrativaDatos();

        public List<UnidadAdministrativa> getUAs()
        {
            return UAdatos.getTodasUAs();
        }

        public bool agregarUA(UnidadAdministrativa unidadAdministrativa)
        {
            return UAdatos.agregarUnidadAdministrativa(unidadAdministrativa);
        }

        public bool modificarUA(UnidadAdministrativa unidadAdministrativa)
        {
            return UAdatos.modificarUA(unidadAdministrativa);
        }

        public Hashtable getHasUA()
        {
            return UnidadAdministrativaDatos.hashUA;
        }
    }
}
