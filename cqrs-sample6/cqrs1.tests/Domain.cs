using System;
using System.Collections.Generic;
using cqrs6.utilities.Interfaces;

namespace cqrs6.utilities
{
    // -- Introduce a base class called Aggregate Root that implements IAggregateRoot

    public class ReservationItem  : AggreagteRoot 
    {                                                                                   
        
        private bool _cancelled = false;
        private bool _reservationMade = false;
        readonly List<IDomainEvent> uncommitedevents = new List<IDomainEvent>();


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

            // -- applying changes 
            ApplyChanges(new ReservationMadeEvent(id, name, numberOfSeats, dateOfGame, contactNumber));
            
        }

        private void ApplyChanges(ReservationMadeEvent e)
        {
            _reservationMade = true;
            uncommitedevents.Add(e);
        }

        public List<IDomainEvent> GetUncommitedEvents()
        {
            return uncommitedevents;
        }
    }
}
