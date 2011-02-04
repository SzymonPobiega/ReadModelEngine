using System;
using System.Collections.Generic;

namespace ManagedViewEngine.SqlPersistence
{
    public class SqlViewEngine : IViewEngine
    {
        public void Initialize(IEnumerable<Type> viewCollection)
        {
        }

        public IView<T> GetView<T>()
        {
            throw new NotImplementedException();
        }

        public ISingletonView<T> GetSingletonView<T>()
        {
            throw new NotImplementedException();
        }
    }
}