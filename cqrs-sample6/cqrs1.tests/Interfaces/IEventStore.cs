using System;
using System.Collections.Generic;

namespace cqrs6.utilities.Interfaces
{
    public interface IEventStore
    {
        void SaveEvents(Guid id, List<IDomainEvent> events);
    }
}