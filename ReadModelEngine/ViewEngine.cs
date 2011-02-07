using System;
using System.Collections.Generic;
using ManagedViewEngine.Persistence;

namespace ManagedViewEngine
{
    public class ViewEngine : IViewEngine
    {
        private readonly Dictionary<Type, View> _views = new Dictionary<Type, View>();
        private readonly Dictionary<Type, SingletonView> _singletonViews = new Dictionary<Type, SingletonView>();
        private readonly IViewPersistenceEngine _persistenceEngine;

        public ViewEngine(IViewPersistenceEngine persistenceEngine)
        {
            _persistenceEngine = persistenceEngine;
        }

        public void Initialize(IEnumerable<Type> viewCollection)
        {
            foreach (var viewType in viewCollection)
            {
                InitializeAnyView(viewType);
            }
        }

        private void InitializeAnyView(Type viewDefinitionType)
        {
            var baseType = viewDefinitionType.BaseType;
            var elementType = GetViewElementType(baseType);
            var baseTypeDefinition = baseType.GetGenericTypeDefinition();
            if (baseTypeDefinition == typeof(ViewDefinition<>))
            {
                InitializeView(elementType);
            }
            else if (baseTypeDefinition == typeof(SingletonViewDefinition<>))
            {
                InitializeSingletonView(elementType);
            }
            else
            {
                throw new InvalidViewDefinitionException(viewDefinitionType);
            }
        }

        private static Type GetViewElementType(Type viewDefinitionType)
        {
            return viewDefinitionType.GetGenericArguments()[0];
        }

        private void InitializeView(Type viewType)
        {
            Type viewManagerType = typeof (View<>).MakeGenericType(viewType);
            var viewManager = (View) Activator.CreateInstance(viewManagerType);
            viewManager.PersistenceEngine = _persistenceEngine;
            _views[viewType] = viewManager;
        }

        private void InitializeSingletonView(Type viewType)
        {
            Type viewManagerType = typeof(SingletonView<>).MakeGenericType(viewType);
            var viewManager = (SingletonView)Activator.CreateInstance(viewManagerType);
            viewManager.PersistenceEngine = _persistenceEngine;
            _singletonViews[viewType] = viewManager;
        }

        public IView<T> GetView<T>()
        {
            View viewManager;
            if (_views.TryGetValue(typeof(T), out viewManager))
            {
                return (IView<T>) viewManager;
            }
            throw new ViewNotFoundException(typeof (T));
        }

        public ISingletonView<T> GetSingletonView<T>()
        {
            SingletonView viewManager;
            if (_singletonViews.TryGetValue(typeof(T), out viewManager))
            {
                return (ISingletonView<T>)viewManager;
            }
            throw new ViewNotFoundException(typeof(T));
        }
    }
}