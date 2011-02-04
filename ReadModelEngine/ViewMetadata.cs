using System;

namespace ManagedViewEngine
{
    public class ViewMetadata
    {
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public ViewStatus Status { get; set; }
        public Exception LastError { get; set; }
        public Version CodeVersion { get; set; }
    }
}