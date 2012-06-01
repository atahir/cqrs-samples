using System;

namespace cqrs1.tests
{
    public class ReservationItem
    {
        private bool _cancelled = false;

        public Guid Id;
   
        private string _name;
        private int _numberOfSeats;
        private DateTime _dateOfGame;
        private string _contactNumber;

        public void Cancel()
        {
            // -- apply some validation rule here 
            if (_cancelled) throw new Exception("Reservation has already been cancelled!");
            
            // we need to apply an event to change the state of the domain object and not actally execute any code here to 
            // modify the state of the domain object. we should only have validation/business rules executed here.

            _cancelled = true;

        }

        public void MakeReservation(Guid id, string name, int numberOfSeats, DateTime dateOfGame, string contactNumber)
        {
            Id = id;
            // apply some validation rules 
            if (numberOfSeats <= 0)
            {
                throw new Exception("Number of Seats can not be zero");
            }

            if (dateOfGame.Date < DateTime.Today.Date)
            {
                throw new Exception("Date of booking can not be in the past.");
            }

            // apply and event here to change the state of the domain object has

            // -- ?? do we need to store the following proporties on this object ?? or can we just persist them by firing off
            // -- an event with data into an event store ???
            _name = name;
            _numberOfSeats = numberOfSeats;
            _dateOfGame = dateOfGame;
            _contactNumber = contactNumber;
        }
    }
}
