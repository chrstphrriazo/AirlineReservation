using FirstProject.Reservation;
using FlightReservation.UI.FlightMaintenance;
using System;

namespace FlightReservation.UI
{
    public class Program
    {
        static void Main(string[] args)
        {  
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime.Hour}:{dateTime.Minute}");
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("MAIN MENU\n");

            Console.WriteLine("Choose your service:");
            Console.WriteLine("[1] Flight Maintenance");
            Console.WriteLine("[2] Reservation");
            Console.WriteLine("[3] Exit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    FlightMaintenanceMenu flightMaintenanceMenu = new FlightMaintenanceMenu();
                    flightMaintenanceMenu.FlightMaintenance();
                    Menu();
                    break;

                case "2":
                    Console.WriteLine("RS");
                    ReservationMenu reservationMenu = new ReservationMenu();
                    reservationMenu.Reservation();
                    Console.Clear();
                    Menu();
                    break;
                case "3":
                    Console.WriteLine("Thank you!");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                    break;
            }
            Console.ReadLine();
        }
    }
}
