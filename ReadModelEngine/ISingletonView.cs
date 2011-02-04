namespace ManagedViewEngine
{
    public interface ISingletonView<out T>
    {
        ViewMetadata GetMetadata();
        T Load();
    }
}