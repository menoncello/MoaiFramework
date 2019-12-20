namespace MoaiFramework.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Events;

    public interface IEventStoreRepository : IDisposable
    {
        Task<IList<StoredEvent>> GetAllAsync(Guid aggregateId);

        Task StoreAsync(StoredEvent theEvent);
    }
}