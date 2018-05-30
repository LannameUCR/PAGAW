using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ObjectoFileChooser
    {
        public int idArchivoMuestra { get; set; }
        public string nombreArchivo { get; set; }
        public string rutaArchivo { get; set; }

        public ObjectoFileChooser() { }

        public ObjectoFileChooser(int idArchivoMuestra, string nombreArchivo, string rutaArchivo)
        {
            this.idArchivoMuestra = idArchivoMuestra;
            this.nombreArchivo = nombreArchivo;
            this.rutaArchivo = rutaArchivo;
        }


    }
}
