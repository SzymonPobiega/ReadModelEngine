using System;
using System.Runtime.Serialization;

namespace ManagedViewEngine
{
    [DataContract]
    public class ViewMetadata
    {
        [DataMember]
        public string UniqueId { get; set; }
        [DataMember]
        public DateTime CreationTime { get; set; }
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }
        [DataMember]
        public ViewStatus Status { get; set; }
        [DataMember]
        public Exception LastError { get; set; }
        [DataMember]
        public string CodeVersion { get; set; }
    }
}