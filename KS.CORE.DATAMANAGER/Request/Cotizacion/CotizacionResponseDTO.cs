using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KS.CORE.ENTITIES
{
    [DataContract]
    public class CotizacionResponseDTO
    {
        [DataMember]
        public uint IdServicio { get; set; }
        [DataMember]
        public string sDescripcion { get; set; }
        [DataMember]
        public decimal dPrecioServicio { get; set; }
        [DataMember]
        public decimal dPorcentajeDescuento { get; set; }
    }
}
