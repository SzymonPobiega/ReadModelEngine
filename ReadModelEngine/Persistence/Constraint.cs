namespace ManagedViewEngine.Persistence
{
    public class Constraint
    {
        private readonly string _propertyName;
        private readonly object _propertyValue;

        public Constraint(string propertyName, object propertyValue)
        {
            _propertyName = propertyName;
            _propertyValue = propertyValue;
        }

        public object PropertyValue
        {
            get { return _propertyValue; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }
    }
}