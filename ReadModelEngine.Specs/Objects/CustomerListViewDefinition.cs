using ManagedViewEngine;

namespace ReadModelEngine.Specs.Objects
{
    public class CustomerListViewDefinition : ViewDefinition<CustomerListView>
    {
        public CustomerListViewDefinition()
        {
            Id(x => x.Name);
        }
    }
}