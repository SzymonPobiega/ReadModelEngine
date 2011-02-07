using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ManagedViewEngine
{
    [DataContract]
    public class StoredViewDifinition
    {
        [DataMember]
        public string UniqueId { get; set; }

        [DataMember]
        public List<string> SharedProperties { get; set; }

        [DataMember]
        public List<string> IndexedProperties { get; set; }
    }
}