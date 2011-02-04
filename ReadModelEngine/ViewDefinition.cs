using System;

namespace ManagedViewEngine
{
    public class ViewDefinition<TView>
    {
        public void Id(Func<TView, object> id)
        {
            
        }

        public void Index(Func<TView, object> id)
        {
            
        }

        public void Share(Func<TView, object> id)
        {

        }
    }
}