using System.Runtime.Serialization;

namespace KS.CORE.ENTITIES
{
    [DataContract]
    public class CotizacionRequestDTO
    {
        [DataMember]
        public uint[] tServicios { get; set; }
        [DataMember]
        public string sCodigoDescuento { get; set; }
    }
}
