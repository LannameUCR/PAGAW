using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BitacoraDeVersionesServicios
    {
        #region variables globales
        BitacoraDeVersionesDatos bitacoraDatos = new BitacoraDeVersionesDatos();
        #endregion

        public void insertarDatoBitacoraVersiones(BitacoraDeVersiones bitacora)
        {
            bitacoraDatos.insertarDatoBitacoraVersiones(bitacora);
        }

        public List<BitacoraDeVersiones> obtenerBitacoraVersiones()
        {
            return bitacoraDatos.obtenerDatoBitacoraVersiones();
        }

        public void actualizarDatoBitacoraVersiones(BitacoraDeVersiones bitacora)
        {
            bitacoraDatos.actualizarDatoBitacoraVersiones(bitacora);
        }

    }
}
