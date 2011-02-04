﻿namespace ManagedViewEngine
{
    public class SalesSummaryViewDenormalizer : IDenormalizer<SalesSummaryView, CustomerCreatedEvent>
    {
        public void Denormalize(ISingletonViewUpdater<SalesSummaryView> updater, CustomerCreatedEvent evnt)
        {
            updater.AddOrUpdate(() => new SalesSummaryView(), x => { x.TotalSales++; });
        }
    }
}