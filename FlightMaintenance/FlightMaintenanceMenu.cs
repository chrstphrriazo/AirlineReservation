using System;

namespace FlightReservation.UI.FlightMaintenance
{
    public class FlightMaintenanceMenu
    {
        public void FlightMaintenance()
        {
            Console.WriteLine("FLIGHT MAINTENANCE MENU\n");
            Console.WriteLine("[1] Add a Flight");
            Console.WriteLine("[2] Search a flight");
            Console.WriteLine("[3] Back to Main Menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    CreateFlight createFlight = new CreateFlight();
                    createFlight.AddingFlight();
                    FlightMaintenance();
                    break;
                case "2":
                    Console.Clear();
                    SearchFlight searchFlight = new SearchFlight();
                    searchFlight.SearchFlightMenu();
                    FlightMaintenance();
                    break;
                case "3":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid Option");
                    Console.ReadLine();
                    Console.Clear();
                    FlightMaintenance();
                    break;
            }
        }
    }
}
