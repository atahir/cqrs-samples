using System;

namespace CQRS1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CQRS - sample ");  
            Console.ReadLine();

            var res = new ReservationService();
            ReservationDetail reservationDto = new ReservationDetail();
            reservationDto.ContactNumber = "0173322333";
            reservationDto.DateOfGame = DateTime.Today;
            reservationDto.Name = "Anjam Tahir";
            reservationDto.NumberOfSeats = 4; 
 
           // var id =  res.MakeReservation(reservationDto);

            MakeReservationCommand reservationCommand;
            reservationCommand.Name = "Anjam";


            var id = res.MakeReservation(reservationCommand);


        }
    }

    public interface IReservationService
    {
        ReservationDetail GetReservation(Guid id);
        //Guid MakeReservation(ReservationDetail reservationDto);
        void CancelReservation(ReservationDetail reservationDto);

        Guid MakeReservation(MakeReservationCommand command);

    }

    public class MakeReservationCommand     
    {
        
    }

    public class ReservationService : IReservationService
    {
        private ReservationDetail _reservationDto = new ReservationDetail();

        public ReservationDetail GetReservation(Guid id)
        {
            ReservationDetail reservation = null;

            if (_reservationDto.Id == id)
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

            // -- assign id to simulate that we have made the reservation.
            _reservationDto.Id = Guid.NewGuid();

            return _reservationDto.Id;
        }

        public void CancelReservation(ReservationDetail reservationDto)
        {
            throw new NotImplementedException();
        }

        public Guid MakeReservation(MakeReservationCommand command)
        {
            throw new NotImplementedException();
        }
    }

    public class ReservationDetail
    {
        public DateTime DateOfGame { get; set; }
        public int NumberOfSeats { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public Guid Id { get; set; }
    }

}

