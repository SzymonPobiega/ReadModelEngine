using System;

namespace ManagedViewEngine
{
    public interface IViewUpdater<T>
    {
        void Add(T newValue);
        void AddOrUpdate(T example, Func<T> add, Action<T> update);
        void Delete(T example);
    }
}