using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KS.CORE.ENTITIES
{
    [DataContract]
    public class RequestDTO<T>
    {
        [DataMember]
        public int IdWebSite { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public T Signature { get; set; }
    }
}
