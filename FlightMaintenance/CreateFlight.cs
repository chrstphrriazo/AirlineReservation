using FlightReservation.BL.Validations.FlightMaintenance;
using FlightReservation.DL;
using System;

namespace FlightReservation.UI.FlightMaintenance
{
    public class CreateFlight
    {
        public void AddingFlight()
        {

            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            Console.WriteLine("FLIGHT MAINTENANCE - CREATE FLIGHT\n");

            Console.Write("Enter an Airline Code :");
            string airlineCode = Console.ReadLine();

            if (!validateFlightDetails.ValidateAirlineCode(airlineCode))
            {
                Console.WriteLine("Invalid Airline Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Console.Write("Enter a Flight Number : ");
            string flightNumber = Console.ReadLine();

            if (!validateFlightDetails.ValidateFlightNumber(flightNumber))
            {
                Console.WriteLine("Invalid Flight Number");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Console.Write("Enter an Arrival Station : ");
            string arrivalStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateStation(arrivalStation))
            {
                Console.WriteLine("Invalid Arrival Station Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Console.Write("Enter a Departure Station : ");
            string departureStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateStation(departureStation))
            {
                Console.WriteLine("Invalid Departure Station Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Console.Write("Enter a Scheduled Time of Arrival (00:00 - 23:59) : ");
            string STA = Console.ReadLine();

            if (!validateFlightDetails.ValidateTime(STA))
            {
                Console.WriteLine("Invalid Time Input.");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Console.Write("Enter a Scheduled Time of Departure (00:00 - 23:59) : ");
            string STD = Console.ReadLine();

            if (!validateFlightDetails.ValidateTime(STD))
            {
                Console.WriteLine("Invalid Time Input.");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            string flightInformation = $"{airlineCode.ToUpper()}-{flightNumber}-{arrivalStation.ToUpper()}-{departureStation.ToUpper()}-{STA}-{STD}";

            //Compare flightInformation to all flights

            FlightsRepository validateFlightData = new FlightsRepository();
            FlightQuery flightQuery = new FlightQuery(validateFlightData);

            if (!flightQuery.CreateFlight(flightInformation))
            {
                Console.WriteLine($"Flight {flightInformation} is created!");
            }
            else
            {
                Console.WriteLine("Flight Exist");
            }

            Console.WriteLine(flightInformation);

            Console.ReadLine();

            return;

        }
    }
}
