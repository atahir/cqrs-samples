using System;
using System.Collections.Generic;
using cqrs7.utilities.Interfaces;

namespace cqrs7.utilities
{
    public class InMemoryEventStore : IEventStore
    {
        Dictionary<string, List<IDomainEvent>> inMemoryEventStore = new Dictionary<string, List<IDomainEvent>>();

        public void SaveEvents(Guid id, List<IDomainEvent> events)
        {
            inMemoryEventStore.Add(id.ToString(), events);
        }
    }
}