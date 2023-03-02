using FlightReservation.BL.Entities;
using FlightReservation.BL.Validations.Passenger;
using FlightReservation.BL.Validations.Reservation;
using FlightReservation.DL;
using System;
using System.Collections.Generic;

namespace FirstProject.Reservation
{
    public class SearchByPNR
    {
        public void SearchByPNRNumber()
        {
            ReservationsRepository reservationsRepository = new ReservationsRepository();
            PassengersRepository passengersRepository = new PassengersRepository();
            ValidateReservationDetails validateReservationDetails = new ValidateReservationDetails();
            ReservationMenu reservationMenu = new ReservationMenu();

            ReservationQuery reservationQuery = new ReservationQuery(reservationsRepository);
            PassengerQuery passengerQuery = new PassengerQuery(passengersRepository);

            Console.Write("Enter PNR Number : ");

            string pnrNumber = Console.ReadLine();

            if (!validateReservationDetails.ValidatePNRNumber(pnrNumber))
            {
                Console.WriteLine("Invalid PNR Number!");
                Console.ReadLine();
                Console.Clear();
                reservationMenu.Reservation();
            }

            List<Reservations> reservationByPNRNumber = reservationQuery.SearchByPNRNumber(pnrNumber);

            if(reservationByPNRNumber.Count < 1)
            {
                Console.WriteLine($"No Existing Reservation With PNR Number : {pnrNumber}");
                Console.Write("\nPress any key to exit...");
                Console.ReadLine();
                Console.Clear();
                reservationMenu.Reservation();
            }
            List<Passengers> passengersByPNRNumber = passengerQuery.SearchByPNRNumber(pnrNumber);

            for (int i = 0; i < reservationByPNRNumber.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {reservationByPNRNumber[i].AirlineCode}-{reservationByPNRNumber[i].FlightNumber}-{reservationByPNRNumber[i].ArrivalStation}-{reservationByPNRNumber[i].DepartureStation}-{reservationByPNRNumber[i].FlightDate}-{reservationByPNRNumber[i].PNRNumber}");
            }

            for (int i = 0; i < passengersByPNRNumber.Count; i++)
            {
                Console.WriteLine($"Passenger {i + 1}\nFirst Name : {passengersByPNRNumber[i].FirstName}\nLast Name : {passengersByPNRNumber[i].LastName}\nBirth Date : {passengersByPNRNumber[i].BirthDate}\nAge : {passengersByPNRNumber[i].Age}\nPNR Number : {passengersByPNRNumber[i].PNRNumber}\n");
            }

            Console.Write("Press any key to exit...");
            Console.ReadLine();
            Console.Clear();
            reservationMenu.Reservation();
        }
    }
}
