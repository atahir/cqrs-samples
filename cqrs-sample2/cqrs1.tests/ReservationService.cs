using System;

namespace cqrs2.utilities
{
    public class ReservationService : IReservationService
    {
        private ReservationDetail _reservationDto = new ReservationDetail();

        // -- origional interface
        
        public ReservationDetail GetReservation(Guid id)
        {
            ReservationDetail reservation = null;

            if (_reservationDto.Id == id )
            {
                reservation = _reservationDto;
            }
            else
            {
                throw new InvalidOperationException("An invalid reference number was passed in.");
            }

            return reservation;
        }

        public Guid MakeReservation(ReservationDetail reservationDto)
        {
            _reservationDto = reservationDto; 
            _reservationDto.Id = Guid.NewGuid(); 

            return _reservationDto.Id;
        }

        public void CancelReservation(ReservationDetail reservationDto)
        {
            throw new NotImplementedException();
        }

        // -- using commands

        public void CancelReservation(CancelReservationCommand command)
        {
            throw new NotImplementedException();
        }

        public Guid MakeReservation(MakeReservationCommand command)
        {
            throw new NotImplementedException();
        }
    }
}