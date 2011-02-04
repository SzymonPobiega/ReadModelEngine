using System;

namespace ManagedViewEngine
{
    public interface ISingletonViewUpdater<T>
    {
        void AddOrUpdate(Func<T> add, Action<T> update);
        void Delete();
    }
}