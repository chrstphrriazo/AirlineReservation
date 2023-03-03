using FlightReservation.BL.Entities;
using FlightReservation.BL.Validations.Reservation;
using FlightReservation.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Reservation
{
    public class ListReservations
    {
        public void ListAllReservations()
        {
            ReservationsRepository reservationsRepository = new ReservationsRepository();
            ReservationQuery reservationQuery = new ReservationQuery(reservationsRepository);
            ReservationMenu reservationMenu = new ReservationMenu();
            Console.WriteLine("LIST OF ALL RESERVATIONS\n");

            List<Reservations> allReservations =  reservationQuery.GetAllReservations();

            if(allReservations.Count < 1)
            {
                Console.WriteLine("There Are No Reservations Available!\n");
            }

            for(int i = 0; i < allReservations.Count; i++)
            {
                Console.WriteLine($"[{i+1}] {allReservations[i].AirlineCode}-{allReservations[i].FlightNumber}-{allReservations[i].ArrivalStation}-{allReservations[i].DepartureStation}-{allReservations[i].FlightDate}-{allReservations[i].PNRNumber}");
            }

            Console.Write("Press any key to exit...");
            Console.ReadLine();
            Console.Clear();
            reservationMenu.Reservation();
        }
    }
}
