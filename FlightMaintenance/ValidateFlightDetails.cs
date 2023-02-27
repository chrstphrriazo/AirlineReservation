using System;
using System.Globalization;
using System.Linq;

namespace FirstProject.FlightMaintenance
{
    public class ValidateFlightDetails
    {
        public bool ValidateDepartureStation(string departureStation)
        {

            if (!CheckUpperCase(departureStation))
            {
                Console.WriteLine("Letters Should Be In Uppercase");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }


            if (departureStation.Length > 3 || departureStation.Length < 3)
            {
                Console.WriteLine("Invalid Departure Station Length");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            if (Char.IsDigit(departureStation[0]))
            {
                Console.WriteLine("Invalid Departure Station Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            return true;
        }

        public bool ValidateArrivalStation(string arrivalStation)
        {

            if (!CheckUpperCase(arrivalStation))
            {
                Console.WriteLine("Letters Should Be In Uppercase");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            if (arrivalStation.Length > 3 || arrivalStation.Length < 3)
            {
                Console.WriteLine("Invalid Arrival Station Length");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            if (Char.IsDigit(arrivalStation[0]))
            {
                Console.WriteLine("Invalid Arrival Station Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            return true;
        }

        public bool ValidateFlightNumber(string flightNumber)
        {
            if (flightNumber.Any(ch => !char.IsDigit(ch)))
            {
                Console.WriteLine("Invalid Flight Number");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            if (flightNumber.Length < 1 || flightNumber.Length > 4)
            {
                Console.WriteLine("Invalid Flight Number Length");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            return true;
        }

        public bool ValidateAirlineCode(string airlineCode)
        {

            if(!CheckUpperCase(airlineCode))
            {
                Console.WriteLine("Letters Should Be In Uppercase");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            if (airlineCode.Length < 2 || airlineCode.Length > 3)
            {
                Console.WriteLine("Invalid Airline Code Length");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            if ((airlineCode.Count(c => Char.IsDigit(c))) > 1 || airlineCode.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                Console.WriteLine("Invalid Airline Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                return false;
            }
            return true;
        }

        public bool CheckUpperCase(string input)
        {
            if(input == input.ToUpper())
            {
                return true;
            }
            return false;
        }

        public bool ValidateDate(string date)
        {
            bool valideDate = DateTime.TryParseExact(
                date,
                "HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);

            if (!valideDate)
            {
                Console.WriteLine("Invalid Time Input.");
                Console.ReadLine();
                Console.Clear();
                return valideDate;
            }

            return valideDate;
        }
    }
}
