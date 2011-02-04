using System.Linq;

namespace ManagedViewEngine
{
    public interface IView<out T>
    {
        ViewMetadata GetMetadata();
        IViewData<T> Load(IViewId id);
        IQueryable<IViewData<T>> List();
    }
}