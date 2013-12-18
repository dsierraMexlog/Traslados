using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traslados.BE
{
    public class Concesionario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int ciudad { get; set; }
        public int estado { get; set; }
        public string contacto { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}
