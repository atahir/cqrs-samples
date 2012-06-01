using System;

namespace cqrs6.utilities.Commands
{
    public class CancelReservationCommand : ICommand
    {
        public readonly Guid Id;

        public CancelReservationCommand(Guid id)
        {
            Id = id;
        }
    }
}
