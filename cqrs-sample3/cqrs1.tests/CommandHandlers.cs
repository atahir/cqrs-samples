using System;

namespace cqrs3.utilities
{
    
    public interface ICommandHandler<T> where T : ICommand 
    {
        void Handle(T command);
    }

    public class MakeReservationCommandHander: ICommandHandler<MakeReservationCommand>
    {
        private readonly IRepository<ReservationItem> _repository;
       
        public MakeReservationCommandHander(IRepository<ReservationItem> respository)
        {
            _repository = respository;
        } 

        public void Handle(MakeReservationCommand command)
        {
            var reservationitem = new ReservationItem(command.Id, 
                                               command.Name, 
                                               command.NumberOfSeats, 
                                               command.DateOfGame,
                                               command.ContactNumber);
            _repository.Save(reservationitem);

        }
    }

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

    public interface IRepository<T>
    {
        T GetById(Guid id);
        void Save(T aggregate);
    }
}