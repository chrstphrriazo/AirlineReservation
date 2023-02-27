using System;
using System.Collections.Generic;

namespace FirstProject.FlightMaintenance
{
    class SearchFlight
    {
        public void SearchFlightMenu()
        {
            Console.WriteLine("FLIGHT MAINTENANCE - SEARCH FLIGHTS\n");

            Console.WriteLine("[1] Search Flight Number");
            Console.WriteLine("[2] Search Airline Code");
            Console.WriteLine("[3] Search Origin and Destination");
            Console.WriteLine("[4] Back to Flight Maintenance Menu");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    SearchByFlightNumber();
                    SearchFlightMenu();
                    break;
                case "2":
                    Console.Clear();
                    SearchByAirlineCode();
                    SearchFlightMenu();
                    break;
                case "3":
                    Console.Clear();
                    SearchByOriginAndDestination();
                    SearchFlightMenu();
                    break;
                case "4":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid Input!");
                    Console.ReadLine();
                    Console.Clear();
                    SearchFlightMenu();
                    break;
            }
        }

        public void SearchByFlightNumber()
        {
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            Console.Write("Enter Flight Number : ");
            string flightNumber = Console.ReadLine();

            if (!validateFlightDetails.ValidateFlightNumber(flightNumber))
            {
                return;
            }

            ValidateFlightData validateFlightData = new ValidateFlightData();

            List<Flights> flights = new List<Flights>();

            flights = validateFlightData.SearchFlight(flightNumber, ValidateFlightData.FlightSearch.FlightNumber);

            if(flights.Count < 1)
            {
                Console.WriteLine($"There are no flights with Flight Number - {flightNumber}.");
            }

            for(int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine($"{flights[i].AirlineCode}-{flights[i].FlightNumber}-{flights[i].ArrivalStation}-{flights[i].DepartureStation}-{flights[i].STA}-{flights[i].STD}");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void SearchByAirlineCode()
        {
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            Console.Write("Enter Airline Code : ");
            string airlineCode = Console.ReadLine();

            if (!validateFlightDetails.ValidateAirlineCode(airlineCode))
            {
                return;
            }

            ValidateFlightData validateFlightData = new ValidateFlightData();

            List<Flights> flights = new List<Flights>();

            flights = validateFlightData.SearchFlight(airlineCode, ValidateFlightData.FlightSearch.AirlineCode);

            if (flights.Count < 1)
            {
                Console.WriteLine($"There are no flights with Airline Code - {airlineCode}.");
            }

            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine($"{flights[i].AirlineCode}-{flights[i].FlightNumber}-{flights[i].AirlineCode}-{flights[i].ArrivalStation}-{flights[i].DepartureStation}-{flights[i].STA}-{flights[i].STD}");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void SearchByOriginAndDestination()
        {
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            Console.Write("Enter Origin Station : ");
            string originStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateDepartureStation(originStation))
            {
                return;
            }

            Console.WriteLine("Enter Destination Station : ");
            string destinationStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateDepartureStation(destinationStation))
            {
                return;
            }

            ValidateFlightData validateFlightData = new ValidateFlightData();

            List<Flights> flights = new List<Flights>();

            flights = validateFlightData.SearchFlight(originStation, destinationStation);

            if (flights.Count < 1)
            {
                Console.WriteLine($"There are no flights with Flight Number - {originStation}-{destinationStation}.");
            }

            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine($"{flights[i].AirlineCode}-{flights[i].FlightNumber}-{flights[i].AirlineCode}-{flights[i].ArrivalStation}-{flights[i].DepartureStation}-{flights[i].STA}-{flights[i].STD}");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
