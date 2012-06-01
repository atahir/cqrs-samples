using System;
using System.Collections.Generic;
using cqrs7.utilities;
using cqrs7.utilities.Interfaces;

namespace cqrs7.utilities
{
    public class Repository : IRepository<ReservationItem>
    {
        private Dictionary<string, ReservationItem> _memorydb = new Dictionary<string, ReservationItem>();
        private IEventStore _eventstore;


        public Repository(IEventStore eventstore)
        {
            _eventstore = eventstore;
        }

        public ReservationItem GetById(Guid id)
        {
            return _memorydb[id.ToString()];
        }

        public void Save(ReservationItem aggregate)
        {
            // -- save the uncommitted events to the event store
            List<IDomainEvent> events = aggregate.GetUncommitedEvents();

            _eventstore.SaveEvents(aggregate.Id, events);
            
            //_memorydb[aggregate.Id.ToString()] = aggregate;
        }
    }
}