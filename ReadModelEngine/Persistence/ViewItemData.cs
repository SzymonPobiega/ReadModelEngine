using System.Collections.Generic;

namespace ManagedViewEngine.Persistence
{
    public class ViewItemData
    {
        private readonly Dictionary<string, object> _propertyValues;

        public ViewItemData(Dictionary<string, object> propertyValues)
        {
            _propertyValues = propertyValues;
        }

        public IDictionary<string, object> PropertyValues
        {
            get { return _propertyValues; }
        }
    }
}