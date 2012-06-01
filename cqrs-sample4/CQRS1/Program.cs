using System;
using System.Collections.Generic;
using cqrs1.tests;


namespace CQRS1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("CQRS - sample ");
            Console.ReadLine();


            // -- create a new make a reservation command 
            var command = new MakeReservationCommand(Guid.NewGuid(), "Anjam Tahir", 4, DateTime.Now.AddDays(2),
                                                     "01733112233");

            IRepository<ReservationItem> repository = new Repository();

            // -- tell associated hander to handle the command
            var commandHander = new MakeReservationCommandHander(repository);
            commandHander.Handle(command);

        }
    }

    
}