using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Parametros
    {
        public static Parametros parametros;
        private int cantidadRegistros;
        private string rutaPruebas;
        private string rutaProduccion;
        private string rutaArchivos;

        public int CantidadRegistros
        {
            get
            {
                return cantidadRegistros;
            }

            set
            {
                cantidadRegistros = value;
            }
        }

        public string RutaPruebas
        {
            get
            {
                return rutaPruebas;
            }

            set
            {
                rutaPruebas = value;
            }
        }

        public string RutaProduccion
        {
            get
            {
                return rutaProduccion;
            }

            set
            {
                rutaProduccion = value;
            }
        }

        public string RutaArchivos
        {
            get
            {
                return rutaArchivos;
            }

            set
            {
                rutaArchivos = value;
            }
        }

        public static Parametros getInstance()
        {
            if (parametros == null)
            {
                parametros = new Parametros();
            }
            return parametros;
        }
    }
}
