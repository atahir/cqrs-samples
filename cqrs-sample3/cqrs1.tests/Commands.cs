using System;

namespace cqrs3.utilities
{
    public interface ICommand
    {
    }

    public class MakeReservationCommand : ICommand
    {
        public readonly Guid Id;
        public readonly DateTime DateOfGame;
        public readonly int NumberOfSeats;
        public readonly string Name;
        public readonly string ContactNumber;

        public MakeReservationCommand(Guid id, string name, int noOfSeats, DateTime dateOfGame, string contactNumber)
        {
            Id = id;
            Name = name;
            DateOfGame = dateOfGame;
            NumberOfSeats = noOfSeats;
            ContactNumber = contactNumber;
        }
    }

    public class CancelReservationCommand : ICommand
    {
        public readonly Guid Id;

        public CancelReservationCommand(Guid id)
        {
            Id = id;
        }
    }
}
