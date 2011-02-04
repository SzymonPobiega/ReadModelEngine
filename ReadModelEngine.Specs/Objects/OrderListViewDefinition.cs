using ManagedViewEngine;

namespace ReadModelEngine.Specs.Objects
{
    public class OrderListViewDefinition : ViewDefinition<OrderListView>
    {
        public OrderListViewDefinition()
        {
            Id(x => x.Id);
            Share(x => x.CustomerName);
        }
    }
}