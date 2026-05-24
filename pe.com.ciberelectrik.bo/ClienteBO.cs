using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bo
{
    [Serializable]
    [DataContract]
    public class ClienteBO
    {
        [DataMember]
        public int codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellidoPaterno { get; set; }
        [DataMember]
        public string apellidoMaterno { get; set; }
        [DataMember]
        public string documento { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string celular { get; set; }
        [DataMember]
        public string correo { get; set; }
        [DataMember]
        public bool estado { get; set; }

        // Llaves Foráneas
        [DataMember]
        public int codigoDistrito { get; set; }
        [DataMember]
        public int codigoTipoDocumento { get; set; }
        [DataMember]
        public int codigoSexo { get; set; }

        // Campos adicionales para los INNER JOIN
        [DataMember]
        public string nombreDistrito { get; set; }
        [DataMember]
        public string nombreTipoDocumento { get; set; }
        [DataMember]
        public string nombreSexo { get; set; }
    }
}
