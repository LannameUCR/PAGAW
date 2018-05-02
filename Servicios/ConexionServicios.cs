using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ConexionServicios
    {
        #region variables globales
        ConexionDatos conexionDatos = new ConexionDatos();
        #endregion

        #region metodos
        /*
         * Lucrecia Zuñiga Sáenz
         * 01/05/2018
         * metodo que se utiliza para loguearse a la aplicacion 
         * recibe el nombre de usuario que se loguea
         * devuelve el id del rol del usuario y el nombre completo del usuario en un vector
         */
        public object[] loguearse(String usuario , String contrasena)
        {
            return conexionDatos.loguearse(usuario , contrasena);
        }
        #endregion
    }
}
