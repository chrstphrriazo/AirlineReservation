using FlightReservation.BL.Entities;
using FlightReservation.BL.Validations;
using FlightReservation.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Reservation
{
    public class CreateReservations
    {

        public void CreateReservation()
        {
            InputFlightFields(out string airlineCode, out string flightNumber, out string arrivalStation, out string departureStation);

            List<Flights> existingFlights = CheckExistingFlight(airlineCode, flightNumber, arrivalStation, departureStation);

            if (existingFlights.Count < 1)
            {
                Console.WriteLine($"There Are No Available Flights with {airlineCode}-{flightNumber}-{arrivalStation}-{departureStation}\n");
                RetryReservation();
            }

            Console.WriteLine("Available Flights:\n");

            for (int i = 0; i < existingFlights.Count; i++)
            {
                Console.WriteLine($"[{i+1}] {existingFlights[i].AirlineCode}" +
                    $"-{existingFlights[i].FlightNumber}" +
                    $"-{existingFlights[i].ArrivalStation}" +
                    $"-{existingFlights[i].DepartureStation}" +
                    $"-{existingFlights[i].STA}" +
                    $"-{existingFlights[i].STD}");
            }

            ReserveFlightOption();

            Console.Clear();

            for (int i = 0; i < existingFlights.Count; i++)
            {
                Console.WriteLine($"[{i+1}] {existingFlights[i].AirlineCode}" +
                    $"-{existingFlights[i].FlightNumber}" +
                    $"-{existingFlights[i].ArrivalStation}" +
                    $"-{existingFlights[i].DepartureStation}" +
                    $"-{existingFlights[i].STA}" +
                    $"-{existingFlights[i].STD}");
            }

            Console.Write("\nChoose The Flight You Want To Reserve : (Enter List Number)");
            string choice = Console.ReadLine();
            int listChoice;

            bool checkParse = int.TryParse(choice, out listChoice);

            if (!checkParse)
            {
                Console.WriteLine("Invalid Input!");
                Console.ReadLine();
                Console.Clear();
                ReservationMenu reservationMenu = new ReservationMenu();
                reservationMenu.Reservation();
            }

            if(listChoice > existingFlights.Count || listChoice < 1)
            {
                Console.WriteLine("Invalid Input!");
                Console.ReadLine();
                Console.Clear();
                ReservationMenu reservationMenu = new ReservationMenu();
                reservationMenu.Reservation();
            }

            listChoice--;


        }

        public List<Flights> CheckExistingFlight(string airlineCode, string flightNumber, string arrivalStation, string departureStation)
        {
            FlightsRepository flightsRepository = new FlightsRepository();
            FlightQuery flightQuery = new FlightQuery(flightsRepository);
            List<Flights> flights = flightQuery.SearchFlight(field1: airlineCode, field2: flightNumber, field3: arrivalStation, field4: departureStation);

            return flights;
        }

        public void ReserveFlightOption()
        {
            ReservationMenu reservation = new ReservationMenu();
            Console.WriteLine("\nDo You Want To Reserve A Flight?\n");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    return;
                case "2":
                    Console.WriteLine("Going Back To Reservation Menu");
                    Console.Write("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    reservation.Reservation();
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    Console.Write("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    reservation = new ReservationMenu();
                    reservation.Reservation();
                    break;
            }
        }

        public void RetryReservation()
        {
            ReservationMenu reservation = new ReservationMenu();
            Console.WriteLine("Do You Want To Search Again?\n");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    CreateReservation();
                    return;
                case "2":
                    Console.WriteLine("Going Back To Reservation Menu");
                    Console.Write("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    reservation.Reservation();
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    Console.Write("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    reservation = new ReservationMenu();
                    reservation.Reservation();
                    break;
            }
        }

        public void InputFlightFields(out string airlineCode, out string flightNumber, out string arrivalStation, out string departureStation)
        {
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            ReservationMenu reservationMenu = new ReservationMenu();
            Console.WriteLine("ENTER FLIGHT DETAILS - RESERVATION\n");
            Console.Write("Enter an Airline Code :");
            airlineCode = Console.ReadLine();

            if (!validateFlightDetails.ValidateAirlineCode(airlineCode))
            {
                Console.WriteLine("Invalid Airline Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                reservationMenu.Reservation();
            }

            Console.Write("Enter a Flight Number : ");
            flightNumber = Console.ReadLine();

            if (!validateFlightDetails.ValidateFlightNumber(flightNumber))
            {
                Console.WriteLine("Invalid Flight Number");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                reservationMenu.Reservation();
            }

            Console.Write("Enter an Arrival Station : ");
            arrivalStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateStation(arrivalStation))
            {
                Console.WriteLine("Invalid Arrival Station Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                reservationMenu.Reservation();
            }

            Console.Write("Enter a Departure Station : ");
            departureStation = Console.ReadLine();

            if (!validateFlightDetails.ValidateStation(departureStation))
            {
                Console.WriteLine("Invalid Departure Station Code");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                reservationMenu.Reservation();
            }
        }
    }
}
