using System;

namespace cqrs3.utilities
{
    public class ReservationItem
    {
        private bool _cancelled = false;
        private Guid _id;
        private string _name;
        private int _numberOfSeats;
        private DateTime _dateOfGame;
        private string _contactNumber;

        public ReservationItem(Guid id, string name, int numberOfSeats, DateTime dateOfGame, string contactNumber)
        {
            _id = id;
            _name = name;
            _numberOfSeats = numberOfSeats;
            _dateOfGame = dateOfGame;
            _contactNumber = contactNumber;

            // apply and event here to indicate that the state of the domain object has changed

        }

        public void Cancel()
        {
            _cancelled = true;
            // we need to apply and event that indicated that the state of the domain object has changed

        }
    }
}
