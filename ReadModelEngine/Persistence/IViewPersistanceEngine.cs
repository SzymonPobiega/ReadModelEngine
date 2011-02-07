using System;
using System.Collections.Generic;

namespace ManagedViewEngine.Persistence
{
    public interface IViewPersistenceEngine
    {
        void InitializeViewMetadata(ViewMetadata viewMetadata);
        ViewMetadata GetViewMetadata(string viewId);
        void UpdateLastViewUpdateTime(string viewId, DateTime newLastUpdateTimeUtc);

        ViewItemData GetViewItem(string viewId, Guid id);

        IEnumerable<ViewItemData> GetViewItemList(string viewId, int first, int pageSize, IEnumerable<Constraint> constraints,
                                                  IEnumerable<Ordering> ordering);

        void AddItem(string viewId, ViewItemData newViewItemData);
        void AddOrUpdate(string viewId, IEnumerable<Constraint> specification, ViewItemData newData);
        void Delete(string viewId, IEnumerable<Constraint> specification);
    }
}