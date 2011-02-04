using System;
using System.Collections.Generic;

namespace ManagedViewEngine
{
    public interface IViewEngine
    {
        void Initialize(IEnumerable<Type> viewCollection);
        IView<T> GetView<T>();
        ISingletonView<T> GetSingletonView<T>();
    }
}