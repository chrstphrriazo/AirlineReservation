using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservation.DL
{
    class ReservationsRepository
    {
        public void WriteData(string writeData)
        {
            FileStream fileStreamWrite = new FileStream(@"C:\Users\criazo\Reservations.txt", FileMode.Append, FileAccess.Write);

            StreamWriter streamWriter = new StreamWriter(fileStreamWrite);

            streamWriter.WriteLine(writeData);

            streamWriter.Flush();
            streamWriter.Close();
            fileStreamWrite.Close();
        }

        public List<string> ReadData()
        {
            List<string> flightData = new List<string>();
            FileStream fileStreamRead = new FileStream(@"C:\Users\criazo\Reservations.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStreamRead);

            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string rowData;

            while ((rowData = streamReader.ReadLine()) != null)
            {
                flightData.Add(rowData);
            }

            Console.ReadLine();
            streamReader.Close();
            fileStreamRead.Close();

            return flightData;
        }
    }
}
