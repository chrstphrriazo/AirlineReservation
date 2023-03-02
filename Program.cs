using FirstProject;
using System;

namespace FlightReservation.UI
{
    public class Program
    {
        static void Main()
        {  
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime.Hour}:{dateTime.Minute}");
            MainMenu main = new MainMenu();

            main.Menu();
            Console.ReadLine();
        }
    }
}
