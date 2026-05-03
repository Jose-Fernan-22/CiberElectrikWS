using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bo
{
    public class EmpleadoBO
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public bool estado { get; set; }

        // Llaves Foráneas
        public int codigoDistrito { get; set; }
        public int codigoRol { get; set; }
        public int codigoTipoDocumento { get; set; }
        public int codigoSexo { get; set; }

        // Campos adicionales para los INNER JOIN
        public string nombreDistrito { get; set; }
        public string nombreRol { get; set; }
        public string nombreTipoDocumento { get; set; }
        public string nombreSexo { get; set; }
    }
}
