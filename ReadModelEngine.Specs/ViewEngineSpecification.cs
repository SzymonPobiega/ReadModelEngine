using System;
using ManagedViewEngine;
using ManagedViewEngine.Persistence;
using NUnit.Framework;
using ReadModelEngine.Specs.Objects;

namespace ReadModelEngine.Specs
{
    [TestFixture]
    public abstract class ViewEngineSpecification
    {
        private IViewPersistenceEngine _persistenceEngine;

        protected abstract IViewPersistenceEngine CreatePersistenceEngine();

        [SetUp]
        public void InitializePersistenceEngine()
        {
            _persistenceEngine = CreatePersistenceEngine();
        }

        private IViewEngine CreateEngine()
        {
            return new ViewEngine(_persistenceEngine);
        }

        [Test]
        public void After_calling_Initialize_all_initialized_views_should_be_available()
        {
            IViewEngine engine = CreateEngine();
            engine.Initialize(new [] {typeof(CustomerListViewDefinition), typeof(CustomerDetailsViewDefinition), typeof(SalesSummaryViewDefinition)});
            
            engine.GetView<CustomerListView>();
            engine.GetView<CustomerDetailsView>();
            engine.GetSingletonView<SalesSummaryView>();
        }

        [Test]
        public void After_calling_Initialize_metadata_should_be_available()
        {
            _persistenceEngine.InitializeViewMetadata(new ViewMetadata
                                                          {
                                                              UniqueId = typeof(CustomerListViewDefinition).AssemblyQualifiedName,
                                                              CodeVersion = typeof(CustomerListViewDefinition).Assembly.GetName().Version.ToString()
                                                          });

            IViewEngine engine = CreateEngine();
            engine.Initialize(new[] { typeof(CustomerListViewDefinition)});

            engine.GetView<CustomerListView>();
            engine.GetView<CustomerDetailsView>();
            engine.GetSingletonView<SalesSummaryView>();
        }

        [Test]
        public void After_calling_Initialize_not_initialized_views_should_not_be_available()
        {
            IViewEngine engine = CreateEngine();
            engine.Initialize(new[] { typeof(CustomerListViewDefinition)});

            TestDelegate act = () => engine.GetView<CustomerDetailsView>();

            Assert.Throws<ViewNotFoundException>(act);
        }

        [Test]
        public void Load_should_return_instance_of_view_if_present()
        {
            IViewEngine engine = CreateEngine();
            var view = engine.GetView<CustomerListView>();
            var instance = view.Load(null);
        }
    }
}

    