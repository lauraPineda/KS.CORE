using System;
using System.Runtime.Serialization;

namespace KS.CORE.ENTITIES
{
    [DataContract]
    public class OrdenRequestDTO:CotizacionRequestDTO
    {
        [DataMember]
        public string sNombre { get; set; }
        [DataMember]
        public string sApellidos { get; set; }
        [DataMember]
        public string sTelefono { get; set; }
        [DataMember]
        public string sEmail { get; set; }
        [DataMember]
        public string sRazonSocial { get; set; }
        [DataMember]
        public Boolean bIcluyeIVA { get; set; }
    }
}
