using System;

namespace ManagedViewEngine
{
    public interface IViewData<out T>
    {
        T Data { get; }
        IViewId Id { get; set;}
        DateTime LastUpdateTime { get; set;}
    }
}