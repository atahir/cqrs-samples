using System;
using cqrs7.utilities.Interfaces;

namespace cqrs7.utilities
{
    public class AggreagteRoot : IAggregateRoot
    {
        public Guid Id { get; set; }
    }
}