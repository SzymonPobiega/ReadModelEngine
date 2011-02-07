namespace ManagedViewEngine.Persistence
{
    public class Ordering
    {
        private readonly string _propertyName;
        private readonly bool _ascending;

        public Ordering(string propertyName, bool ascending)
        {
            _propertyName = propertyName;
            _ascending = ascending;
        }

        public Ordering(string propertyName) : this(propertyName, true)
        {
        }

        public bool Ascending
        {
            get { return _ascending; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }
    }
}