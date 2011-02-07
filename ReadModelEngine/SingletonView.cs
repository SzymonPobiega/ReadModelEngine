using System;
using ManagedViewEngine.Persistence;

namespace ManagedViewEngine
{
    public abstract class SingletonView
    {
        private readonly StoredViewDifinition _definition;

        protected SingletonView(StoredViewDifinition definition)
        {
            _definition = definition;
        }

        protected StoredViewDifinition Definition
        {
            get { return _definition; }
        }

        public IViewPersistenceEngine PersistenceEngine { get; set; }
    }

    public class SingletonView<T> : SingletonView, ISingletonView<T>
    {
        public SingletonView(StoredViewDifinition definition) : base(definition)
        {
        }

        public ViewMetadata GetMetadata()
        {
            return PersistenceEngine.GetViewMetadata(Definition.UniqueId);
        }

        public T Load()
        {
            throw new NotImplementedException();
        }
    }
}