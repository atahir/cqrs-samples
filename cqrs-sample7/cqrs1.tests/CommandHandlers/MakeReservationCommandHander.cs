using cqrs7.utilities.Commands;
using cqrs7.utilities.Interfaces;

namespace cqrs7.utilities.CommandHandlers
{
    public class MakeReservationCommandHander: ICommandHandler<MakeReservationCommand>
    {
        private readonly IRepository<ReservationItem> _repository;
        // constructor
        public MakeReservationCommandHander(IRepository<ReservationItem> respository)
        {
            _repository = respository;
        } 

        public void Handle(MakeReservationCommand command)
        {
            var reservationitem = new ReservationItem();

            reservationitem.MakeReservation(command.Id, 
                                            command.Name, 
                                            command.NumberOfSeats, 
                                            command.DateOfGame,
                                            command.ContactNumber);

            _repository.Save(reservationitem);

        }
    }
}