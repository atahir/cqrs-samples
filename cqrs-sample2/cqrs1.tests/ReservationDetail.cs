using System;

namespace cqrs2.utilities
{
    public class ReservationDetail
    {
        public DateTime DateOfGame { get; set; }
        public int NumberOfSeats { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public Guid Id { get; set; }
    }
}