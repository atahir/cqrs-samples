using System;
using cqrs7.utilities.Interfaces;

namespace cqrs7.utilities
{
    public class ReservationMadeEvent : IDomainEvent 
    {                                                   
        public readonly Guid Id;
        public readonly string Name;
        public readonly int NumberOfSeats;
        public readonly DateTime DateOfGame;
        public readonly string ContactNumber;
        
        public ReservationMadeEvent(Guid id, string name, int numberOfSeats, DateTime dateOfGame, string contactNumber)
        {
            Id = id;
            Name = name;
            NumberOfSeats = numberOfSeats;
            DateOfGame = dateOfGame;
            ContactNumber = contactNumber;
        }
    }
}