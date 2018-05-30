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

        public List<Aplicacion> getApps(string tipoServidor)
        {
            return appoDatos.getApps(tipoServidor);

        }

        public List<Aplicacion> getAplicacionPorNombre(string nombreAplicacion)
        {
            return appoDatos.getAplicacionPorNombre(nombreAplicacion);
        }

        public List<Aplicacion> getAplicacionPorUnidadAdministrativa(int nombreUnidadAdministrativa)
        {
            return appoDatos.getAplicacionPorUnidadAdministrativa(nombreUnidadAdministrativa);
        }

        public void eliminarAplicacion(Aplicacion appElimimar)
        {
            appoDatos.EliminarApplicacion(appElimimar);
        }


        public void insertarAplicacion(Aplicacion appInsertar)
        {
            appoDatos.InsertarApplicacion(appInsertar);
        }

        public void actualizarAplicacion(Aplicacion appInsertar)
        {
            appoDatos.ActualizarApplicacion(appInsertar);
        }
    }
}
