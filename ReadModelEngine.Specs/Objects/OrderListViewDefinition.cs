using ManagedViewEngine;

namespace ReadModelEngine.Specs.Objects
{
    public class OrderListViewDefinition : ViewDefinition<OrderListView>
    {
        public OrderListViewDefinition()
        {
            Share(x => x.CustomerName);
        }
    }
}