namespace FirstProject.FlightMaintenance
{
    public class Flights
    {
        public string AirlineCode { get; set; }
        public string FlightNumber { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        public string STA { get; set; }
        public string STD { get; set; }


        public Flights(string airlineCode, string flightNumber, string arrivalStation, string departureStation, string _STA, string _STD)
        {
            AirlineCode = airlineCode;
            FlightNumber = flightNumber;
            ArrivalStation = arrivalStation;
            DepartureStation = departureStation;
            STA = _STA;
            STD = _STD;
        }

    }
}
