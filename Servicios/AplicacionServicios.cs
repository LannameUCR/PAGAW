using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class AplicacionServicios
    {
        #region variables globales
        AplicacionDatos appoDatos = new AplicacionDatos();
        #endregion       

        public List<Aplicacion> getApps()
        {
            return appoDatos.getApps();

        }        
    }
}
