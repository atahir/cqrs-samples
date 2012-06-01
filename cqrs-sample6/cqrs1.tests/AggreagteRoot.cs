using System;
using cqrs6.utilities.Interfaces;

namespace cqrs6.utilities
{
    public class AggreagteRoot : IAggregateRoot
    {
        public Guid Id { get; set; }
    }
}