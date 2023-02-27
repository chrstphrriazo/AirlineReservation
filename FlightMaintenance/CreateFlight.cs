using System;

namespace FirstProject.FlightMaintenance
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
                return;
            }

            Console.Write("Enter a Flight Number : ");
            string flightNumber = Console.ReadLine();

            if (!validateFlightDetails.ValidateFlightNumber(flightNumber))
            {
                return;
            }

            Console.Write("Enter an Arrival Station : ");
            string arrivalStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateArrivalStation(arrivalStation))
            {
                return;
            }

            Console.Write("Enter a Departure Station : ");
            string departureStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateDepartureStation(departureStation))
            {
                return;
            }

            Console.Write("Enter a Scheduled Time of Arrival (00:00 - 23:59) : ");
            string STA = Console.ReadLine();

            if (!validateFlightDetails.ValidateDate(STA))
            {
                return;
            }

            Console.Write("Enter a Scheduled Time of Departure (00:00 - 23:59) : ");
            string STD = Console.ReadLine();

            if (!validateFlightDetails.ValidateDate(STD))
            {
                return;
            }

            string flightInformation = $"{airlineCode.ToUpper()}-{flightNumber}-{arrivalStation.ToUpper()}-{departureStation.ToUpper()}-{STA}-{STD}";

            //Compare flightInformation to all flights

            ValidateFlightData validateFlightData = new ValidateFlightData();

            if (!validateFlightData.ReadData(flightInformation))
            {
                validateFlightData.WriteData(flightInformation);
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
