using FlightReservation.BL.Logic;
using FlightReservation.BL.Validations.Passenger;
using FlightReservation.BL.Entities;
using FlightReservation.BL.Validations.FlightMaintenance;
using FlightReservation.BL.Validations.Reservation;
using FlightReservation.DL;
using System;
using System.Collections.Generic;

namespace FirstProject.Reservation
{
    public class CreateReservations
    {

        public void CreateReservation()
        {
            InputFlightFields(out string airlineCode, out string flightNumber, out string arrivalStation, out string departureStation);

            ReservationsRepository reservationsRepository = new ReservationsRepository();
            ReservationQuery reservationQuery = new ReservationQuery(reservationsRepository);

            List<Flights> existingFlights = reservationQuery.CheckExistingFlight(airlineCode, flightNumber, arrivalStation, departureStation);

            if (existingFlights.Count < 1)
            {
                Console.WriteLine($"There Are No Available Flights with {airlineCode}-{flightNumber}-{departureStation}-{arrivalStation}\n");
                RetryReservation();
            }

            Console.WriteLine("Available Flights:\n");

            for (int i = 0; i < existingFlights.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {existingFlights[i].AirlineCode}" +
                    $"-{existingFlights[i].FlightNumber}" +
                    $"-{existingFlights[i].DepartureStation}" +
                    $"-{existingFlights[i].ArrivalStation}" +
                    $"-{existingFlights[i].STD}" +
                    $"-{existingFlights[i].STA}");
            }

            ReserveFlightOption();

            Console.Clear();

            for (int i = 0; i < existingFlights.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {existingFlights[i].AirlineCode}" +
                    $"-{existingFlights[i].FlightNumber}" +
                    $"-{existingFlights[i].DepartureStation}" +
                    $"-{existingFlights[i].ArrivalStation}" +
                    $"-{existingFlights[i].STD}" +
                    $"-{existingFlights[i].STA}");
            }

            Console.Write("\nChoose The Flight You Want To Reserve (Enter List Number) : ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            bool checkParse = int.TryParse(choice, out int listChoice);

            if (!checkParse)
            {
                Console.WriteLine("Invalid Input!");
                Console.ReadLine();
                Console.Clear();
                ReservationMenu reservationMenu = new ReservationMenu();
                reservationMenu.Reservation();
            }

            if (listChoice > existingFlights.Count || listChoice < 1)
            {
                Console.WriteLine("Invalid Input!");
                Console.ReadLine();
                Console.Clear();
                ReservationMenu reservationMenu = new ReservationMenu();
                reservationMenu.Reservation();
            }

            InputReservationsField(out string flightDate, out string passengers);

            string reservationsData = $"{airlineCode}-{flightNumber}-{departureStation}-{arrivalStation}-{flightDate}";

            List<string> passengerList =  CreatePassenger(passengers);

            GeneratePNRNumber generatePNRNumber = new GeneratePNRNumber();
            string pnrNumber = generatePNRNumber.GeneratePNR();

            pnrNumber = reservationQuery.CheckDuplicatePNR(pnrNumber);
            
            Console.WriteLine($"PNR Number : {pnrNumber}\n");

            ReservationDetails(passengerList, reservationsData, pnrNumber);
        }

        private void ReservationDetails(List<string> passengerDetails, string reservationDetails, string pnrNumber)
        {
            ReservationsRepository reservationsRepository = new ReservationsRepository();
            PassengersRepository passengersRepository = new PassengersRepository();

            ReservationQuery reservationQuery = new ReservationQuery(reservationsRepository);
            PassengerQuery passengerQuery = new PassengerQuery(passengersRepository);

            Console.WriteLine($"\nRESERVATION SUCCESS! PNR Number {pnrNumber} Is Generated. Details below:\n");

            reservationDetails += $"-{pnrNumber}";

            Console.WriteLine($"Reserved to Flight : {reservationDetails}\n");

            for(int i = 0; i < passengerDetails.Count; i++)
            {
                passengerDetails[i] = passengerDetails[i] + $"-{pnrNumber}";
                string[] passengerData = passengerDetails[i].Split('-');
                Console.WriteLine($"Passenger {i + 1}");
                Console.WriteLine($"First Name : {passengerData[0]}");
                Console.WriteLine($"Last Name : {passengerData[1]}");
                Console.WriteLine($"Birth Date : {passengerData[2]}");
                Console.WriteLine($"Age : {passengerData[3]}");
                Console.WriteLine($"PNR Number : {passengerData[4]}");
                Console.WriteLine();
            }

            reservationQuery.CreateReservation(reservationDetails);
            passengerQuery.CreatePassenger(passengerDetails);


            Console.Write("Press any key to exit...");
            Console.ReadLine();
            Console.Clear();
        }

        private List<string> CreatePassenger(string passengerCount)
        {
            ValidatePassengerDetails validatePassengerDetails  = new ValidatePassengerDetails();
            ReservationMenu reservationMenu = new ReservationMenu();

            List<string> passengersList = new List<string>();

            Console.WriteLine("ENTER PASSENGER DETAILS - PASSENGERS\n");

            int passengers = Int32.Parse(passengerCount);

            for(int i = 0; i < passengers; i++)
            {
                Console.WriteLine($"Enter Passenger {i + 1}\n");
                Console.Write("Enter Passenger First Name : ");
                string firstName = Console.ReadLine();

                if (!validatePassengerDetails.ValidateName(firstName))
                {
                    Console.WriteLine("Invalid Name");
                    Console.Write("Press Any Key to Continue...");
                    Console.ReadLine();
                    Console.Clear();
                    reservationMenu.Reservation();
                }

                firstName = firstName.ToUpper();

                Console.Write("Enter Passenger Last Name : ");
                string lastName = Console.ReadLine();

                if (!validatePassengerDetails.ValidateName(lastName))
                {
                    Console.WriteLine("Invalid Name");
                    Console.Write("Press Any Key to Continue...");
                    Console.ReadLine();
                    Console.Clear();
                    reservationMenu.Reservation();
                }

                lastName = lastName.ToUpper();

                Console.Write("Enter Passenger Birth Date : ");
                string passengerBirthdate = Console.ReadLine();

                if (!validatePassengerDetails.ValidateDate(passengerBirthdate))
                {
                    Console.WriteLine("Invalid Date Format");
                    Console.Write("Press Any Key to Continue...");
                    Console.ReadLine();
                    Console.Clear();
                    reservationMenu.Reservation();
                }

                if (!validatePassengerDetails.ValidateIfFutureDated(passengerBirthdate))
                {
                    Console.WriteLine("Date Input is Future Dated");
                    Console.Write("Press Any Key to Continue...");
                    Console.ReadLine();
                    Console.Clear();
                    reservationMenu.Reservation();
                }

                string passengerAge = validatePassengerDetails.CalculateAge(passengerBirthdate);

                string passenger = $"{firstName}-{lastName}-{passengerBirthdate}-{passengerAge}";
                Console.WriteLine(passenger);

                Console.WriteLine();

                passengersList.Add(passenger);
            }

            return passengersList;
        }

        private void InputReservationsField(out string _flightDate, out string _passengers)
        {
            ValidateReservationDetails validateReservationDetails = new ValidateReservationDetails();
            ReservationMenu reservationMenu = new ReservationMenu();
            Console.WriteLine("ENTER RESERVATION DETAILS - RESERVATION\n");

            Console.Write("Enter Flight Date (MM/DD/YYYY) : ");
            _flightDate = Console.ReadLine();

            if (!validateReservationDetails.ValidateDate(_flightDate))
            {
                Console.WriteLine("Invalid Date Format");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                reservationMenu.Reservation();
            }

            if (!validateReservationDetails.ValidateIfPastDated(_flightDate))
            {
                Console.WriteLine("Date Input Is Past Dated");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                reservationMenu.Reservation();
            }

            Console.Write("Enter Number of Passengers : ");
            _passengers = Console.ReadLine();

            if (!validateReservationDetails.PassengerCount(_passengers))
            {
                Console.WriteLine("Invalid Passenger Count");
                Console.Write("Press Any Key to Continue...");
                Console.ReadLine();
                Console.Clear();
                reservationMenu.Reservation();
            }

            Console.Write("Press Any Key to continue...");
            Console.ReadLine();
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
                    break;
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
            Console.Write("Enter an Airline Code : ");
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
