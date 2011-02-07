using System;

namespace ManagedViewEngine
{
    [Serializable]
    public class InvalidViewDefinitionException : Exception
    {
        private readonly string _viewDefinitionTypeName;

        public InvalidViewDefinitionException(Type viewDefinitionType)
        {
            _viewDefinitionTypeName = viewDefinitionType.AssemblyQualifiedName;
        }

        public string ViewDefinitionTypeName
        {
            get { return _viewDefinitionTypeName; }
        }
    }
}