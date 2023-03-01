using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Reservation
{
    class ReservationMenu
    {
        public void Reservation()
        {
            Console.WriteLine("RESERVATIONS MENU\n");
            Console.WriteLine("[1] Create Reservation");
            Console.WriteLine("[2] List All Reservations");
            Console.WriteLine("[3] Search By PNR Number");
            Console.WriteLine("[4] Back To Main Menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    CreateReservations createReservations = new CreateReservations();
                    createReservations.CreateReservation();
                    Reservation();
                    break;
                case "2":
                    Console.Clear();
                    Reservation();
                    break;
                case "3":
                    Console.Clear();
                    Reservation();
                    return;
                default:
                    Console.WriteLine("Invalid Option");
                    Console.ReadLine();
                    Console.Clear();
                    Reservation();
                    break;
            }
        }
    }
}
