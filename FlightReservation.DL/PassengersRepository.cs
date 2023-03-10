using System.Collections.Generic;
using System.IO;

namespace FlightReservation.DL
{
    public class PassengersRepository : IDataRepository
    {
        public void WriteData(string writeData)
        {
            FileStream fileStreamWrite = new FileStream(@"C:\Users\criazo\source\repos\FlightReservation\FlightReservation.DL\RepositoryTextFile\Passengers.txt", FileMode.Append, FileAccess.Write);

            StreamWriter streamWriter = new StreamWriter(fileStreamWrite);

            streamWriter.WriteLine(writeData);

            streamWriter.Flush();
            streamWriter.Close();
            fileStreamWrite.Close();
        }

        public List<string> ReadData()
        {
            List<string> flightData = new List<string>();
            FileStream fileStreamRead = new FileStream(@"C:\Users\criazo\source\repos\FlightReservation\FlightReservation.DL\RepositoryTextFile\Passengers.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStreamRead);

            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string rowData;

            while ((rowData = streamReader.ReadLine()) != null)
            {
                flightData.Add(rowData);
            }

            streamReader.Close();
            fileStreamRead.Close();

            return flightData;
        }
    }
}
