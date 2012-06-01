using System;

namespace cqrs7.utilities.Commands
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
