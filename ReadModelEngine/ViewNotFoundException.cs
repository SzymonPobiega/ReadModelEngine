using System;

namespace ManagedViewEngine
{
    [Serializable]
    public class ViewNotFoundException : Exception
    {
        private readonly string _viewTypeName;

        public ViewNotFoundException(Type viewType)
        {
            _viewTypeName = viewType.AssemblyQualifiedName;
        }

        public string ViewTypeName
        {
            get { return _viewTypeName; }
        }
    }
}