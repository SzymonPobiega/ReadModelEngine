namespace ManagedViewEngine
{
    public class CustomerListViewDefinition : ViewDefinition<CustomerListView>
    {
        public CustomerListViewDefinition()
        {
            Id(x => x.Name);
        }
    }
}