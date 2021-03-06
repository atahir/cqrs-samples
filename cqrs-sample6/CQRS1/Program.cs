﻿using System;
using cqrs6.utilities;
using cqrs6.utilities.CommandHandlers;
using cqrs6.utilities.Commands;
using cqrs6.utilities.Interfaces;


namespace cqrs6
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


            IEventStore eventstore = new InMemoryEventStore();

            IRepository<ReservationItem> repository = new Repository(eventstore);

            // -- tell associated hander to handle the command
            var commandHander = new MakeReservationCommandHander(repository);
            commandHander.Handle(command);

            Console.WriteLine("Reservation Made...... ");
            Console.WriteLine("To can cancel reservation press enter.");
            Console.ReadLine();


        }
    }
}