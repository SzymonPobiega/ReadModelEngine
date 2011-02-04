﻿using System.Text;

namespace ManagedViewEngine
{
    public class Test
    {
        public void After_calling_Initialize_all_initialized_views_should_be_available()
        {
            IViewEngine engine = null;
            engine.Initialize(new [] {typeof(CustomerListView), typeof(CustomerDetailsView), typeof(SalesSummaryView)});
            
            engine.GetView<CustomerListView>();
            engine.GetView<CustomerDetailsView>();
            engine.GetSingletonView<SalesSummaryView>();
        }

        public void Load_should_return_instance_of_view_if_present()
        {
            IViewEngine engine = null;
            var view = engine.GetView<CustomerListView>();
            var instance = view.Load(null);
        }
    }
}

    