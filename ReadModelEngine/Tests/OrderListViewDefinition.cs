namespace ManagedViewEngine
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