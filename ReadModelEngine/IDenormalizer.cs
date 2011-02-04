namespace ManagedViewEngine
{
    public interface IDenormalizer<TView, in TEvent>
    {
        void Denormalize(ISingletonViewUpdater<TView> updater, TEvent evnt);
    }
}