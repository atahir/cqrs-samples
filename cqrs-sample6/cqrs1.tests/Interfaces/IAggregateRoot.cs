using System;

namespace cqrs6.utilities.Interfaces
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}