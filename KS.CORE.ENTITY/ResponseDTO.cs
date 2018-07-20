using System.Runtime.Serialization;

namespace KS.CORE.ENTITIES
{
    [DataContract]
    public class ResponseDTO<T>
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public T Result { get; set; }
    }
}
