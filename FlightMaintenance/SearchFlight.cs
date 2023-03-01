using FlightReservation.BL.Entities;
using FlightReservation.BL.Validations;
using FlightReservation.DL;
using System;
using System.Collections.Generic;
using static FlightReservation.BL.Validations.FlightQuery;

namespace FlightReservation.UI.FlightMaintenance
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
                    SearchFlights(FlightSearch.FlightNumber);
                    SearchFlightMenu();
                    break;
                case "2":
                    Console.Clear();
                    SearchFlights(FlightSearch.AirlineCode);
                    SearchFlightMenu();
                    break;
                case "3":
                    Console.Clear();
                    SearchByOriginAndDestination(FlightSearch.Destinations);
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

        public void SearchFlights(FlightSearch flightSearch)
        {

            string searchFlight;

            if(FlightSearch.AirlineCode == flightSearch)
            {
                searchFlight = SearchByAirlineCode();
            }
            else
            {
                searchFlight = SearchByFlightNumber();
            }

            FlightsRepository flightsRepository = new FlightsRepository();
            FlightQuery flightQuery = new FlightQuery(flightsRepository);

            List<Flights> flights = flightQuery.SearchFlight(searchFlight, flightSearch);

            if (flights.Count < 1 && flightSearch == FlightSearch.AirlineCode)
            {
                Console.WriteLine($"There are no flights with Airline Code - {searchFlight}.");
            }
            else if (flights.Count < 1 && flightSearch == FlightSearch.FlightNumber)
            {
                Console.WriteLine($"There are no flights with Flight Number - {searchFlight}.");
            }

            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine($"{flights[i].AirlineCode}-{flights[i].FlightNumber}-{flights[i].ArrivalStation}-{flights[i].DepartureStation}-{flights[i].STA}-{flights[i].STD}");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void SearchByOriginAndDestination(FlightSearch flightSearch)
        {

            //string[] searchFlight = new string[2];

            string origin = "", destination = "", airlineCode, flightNumber;

            if(FlightSearch.Destinations == flightSearch)
            {
                string[] searchFlight = SearchByDestination();
                origin = searchFlight[0];
                destination = searchFlight[1];
            }
            else
            {
                airlineCode = "";
                flightNumber = "";
                Console.WriteLine($"{airlineCode}-{flightNumber}");
                //
            }

            FlightsRepository flightsRepository = new FlightsRepository();
            FlightQuery flightQuery = new FlightQuery(flightsRepository);

            List<Flights> flights = flightQuery.SearchFlight(field1: origin, field2: destination, FlightSearch.Destinations);

            if (flights.Count < 1 && flightSearch == FlightSearch.Destinations)
            {
                Console.WriteLine($"There are no flights with Flight Number - {origin}-{destination}.");
            }

            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine($"{flights[i].AirlineCode}-{flights[i].FlightNumber}-{flights[i].AirlineCode}-{flights[i].ArrivalStation}-{flights[i].DepartureStation}-{flights[i].STA}-{flights[i].STD}");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public string SearchByAirlineCode()
        {
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();

            Console.Write("Enter Airline Code : ");
            string airlineCode = Console.ReadLine();

            if (!validateFlightDetails.ValidateAirlineCode(airlineCode))
            {
                Console.WriteLine("Invalid Flight Number");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                SearchFlightMenu();
            }

            return airlineCode;
        }

        public string SearchByFlightNumber()
        {
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();

            Console.Write("Enter Flight Number : ");
            string flightNumber = Console.ReadLine();

            if (!validateFlightDetails.ValidateFlightNumber(flightNumber))
            {
                Console.WriteLine("Invalid Flight Number");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                SearchFlightMenu();
            }

            return flightNumber;
        }

        public string[] SearchByDestination()
        {
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();

            string[] returnData = new string[2];

            Console.Write("Enter Origin Station : ");
            string originStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateStation(originStation))
            {
                Console.WriteLine("Invalid Arrival Station Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                SearchFlightMenu();
            }

            Console.WriteLine("Enter Destination Station : ");
            string destinationStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateStation(destinationStation))
            {
                Console.WriteLine("Invalid Arrival Station Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                SearchFlightMenu();
            }

            returnData[0] = originStation;
            returnData[1] = destinationStation;

            return returnData;
        }
    }
}
