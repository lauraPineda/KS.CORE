using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace KS.CORE.ENTITIES
{
    [DataContract]
    public class CotizacionRequestDTO
    {
        [DataMember]
        public int[] tServicios { get; set; }
        [DataMember]
        public string sCodigoDescuento { get; set; }
    }
}
