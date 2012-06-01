using System;
using System.Collections.Generic;

namespace cqrs7.utilities.Interfaces
{
    public interface IEventStore
    {
        void SaveEvents(Guid id, List<IDomainEvent> events);
    }
}