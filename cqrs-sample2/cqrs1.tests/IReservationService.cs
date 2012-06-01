using System;

namespace cqrs2.utilities
{
    public interface IReservationService
    {
        // -- crud based interafce
        ReservationDetail GetReservation(Guid id);
        Guid MakeReservation(ReservationDetail reservationDto);
        void CancelReservation(ReservationDetail reservationDto);

        // -- using commands
        void CancelReservation(CancelReservationCommand command);
        Guid MakeReservation(MakeReservationCommand command);
    }
}