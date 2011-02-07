using System;
using System.Linq;
using ManagedViewEngine.Persistence;

namespace ManagedViewEngine
{
    public abstract class View
    {
        private readonly StoredViewDifinition _definition;

        protected View(StoredViewDifinition definition)
        {
            _definition = definition;
        }

        protected StoredViewDifinition Definition
        {
            get { return _definition; }
        }

        public IViewPersistenceEngine PersistenceEngine { get; set; }
    }

    public class View<T> : View, IView<T>
    {
        public View(StoredViewDifinition definition) : base(definition)
        {
        }

        public ViewMetadata GetMetadata()
        {
            return PersistenceEngine.GetViewMetadata(Definition.UniqueId);
        }

        public IViewData<T> Load(IViewId id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IViewData<T>> List()
        {
            throw new NotImplementedException();
        }
    }
}