using cqrs6.utilities.Commands;
using cqrs6.utilities.Interfaces;

namespace cqrs6.utilities.CommandHandlers
{
    public class CancelReservationCommandHander: ICommandHandler<CancelReservationCommand>
    {
        private readonly IRepository<ReservationItem> _respository;
        // constructor
        public CancelReservationCommandHander(IRepository<ReservationItem> repository )
        {
            _respository = repository;
        } 

        public void Handle(CancelReservationCommand command)
        {
            var reservationitem = _respository.GetById(command.Id);
            reservationitem.Cancel();

            _respository.Save(reservationitem);

        }
    }
}