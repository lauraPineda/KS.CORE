using System.Runtime.Serialization;

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
        public decimal dPrecioConDescuento { get; set; }
    }
}
