using System;

namespace cqrs5.utilities
{
    // -- Introduce a base class called Aggregate Root that implements IAggregateRoot
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }

    public class AggreagteRoot : IAggregateRoot
    {
        public Guid Id { get; set; }
    }
    
    public class ReservationItem  : AggreagteRoot 
    {                                                                                   
        
        private bool _cancelled = false;
        private string _name;
        private int _numberOfSeats;
        private DateTime _dateOfGame;
        private string _contactNumber;
        
        public void Cancel()
        {
            // -- apply some validation rules here.
            if (_cancelled) throw new Exception("Reservation has already been cancelled!");
            
            // -- apply changes to domain model
            ApplyChanges(new ReservationCancelledEvent());

        }

        private void ApplyChanges(ReservationCancelledEvent reservationCancelledEvent)
        {
            _cancelled = true;
        }
                                                                                      
        public void MakeReservation(Guid id, string name, int numberOfSeats, DateTime dateOfGame, string contactNumber)
        {
         
            // apply some validation rules 
            if (numberOfSeats <= 0)
            {
                throw new Exception("Number of Seats can not be zero");
            }

            if (dateOfGame.Date < DateTime.Today.Date)
            {
                throw new Exception("Date of booking can not be in the past.");
            }

            // -- applying changes 
            ApplyChanges(new ReservationMadeEvent(id, name, numberOfSeats, dateOfGame, contactNumber));
            
        }

        private void ApplyChanges(ReservationMadeEvent e)
        {
            Id = e.Id;
            _name = e.Name;
            _numberOfSeats = e.NumberOfSeats;
            _dateOfGame = e.DateOfGame;                                                                                                                                                                                                                                                                                                                             
            _contactNumber = e.ContactNumber;
        }
    }

    public class ReservationCancelledEvent 
    {

    }

    public class ReservationMadeEvent 
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
