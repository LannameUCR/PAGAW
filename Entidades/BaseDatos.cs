using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class BaseDatos
    {
        public String baseBI { get; set; }
        public String baseLogin { get; set; }

        public String servidorBI { get; set; }
        public String usuarioBI { get; set; }
        public String contrasenaBI { get; set; }

        public String servidorLogin { get; set; }
        public String usuarioLogin { get; set; }
        public String contrasenaLogin { get; set; }

    }
}
