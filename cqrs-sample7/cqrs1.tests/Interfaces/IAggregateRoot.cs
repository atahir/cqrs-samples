using System;

namespace cqrs7.utilities.Interfaces
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}