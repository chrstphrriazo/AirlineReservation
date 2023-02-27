using FirstProject.FlightMaintenance;
using System;
using System.Collections.Generic;
using System.IO;

namespace FirstProject
{
    public class ValidateFlightData
    {
        public void WriteData(string writeData)
        {
            FileStream fileStreamWrite = new FileStream(@"C:\Users\criazo\Flights.txt", FileMode.Append, FileAccess.Write);

            StreamWriter streamWriter = new StreamWriter(fileStreamWrite);

            streamWriter.WriteLine(writeData);

            streamWriter.Flush();
            streamWriter.Close();
            fileStreamWrite.Close();
        }

        public bool ReadData(string readData)
        {
            FileStream fileStreamRead = new FileStream(@"C:\Users\criazo\Flights.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStreamRead);

            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string flightData;

            bool checkExistingData = false;

            while ((flightData = streamReader.ReadLine()) != null)
            {
                if (flightData == readData)
                {
                    checkExistingData = true;
                    break;
                }
            }

            Console.ReadLine();
            streamReader.Close();
            fileStreamRead.Close();

            return checkExistingData;
        }

        public List<Flights> SearchFlight(string field, FlightSearch flightField)
        {
            List<Flights> flightList = new List<Flights>();

            FileStream fileStreamRead = new FileStream(@"C:\Users\criazo\Flights.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStreamRead);

            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string flightData;

            while ((flightData = streamReader.ReadLine()) != null)
            {
                string[] rowData = flightData.Split('-');

                if (FlightSearch.AirlineCode == flightField)
                {
                    if (rowData[0] == field)
                    {
                        flightList.Add(new Flights(rowData[0], rowData[1], rowData[2], rowData[3], rowData[4], rowData[5]));
                    }
                    continue;
                }

                if (FlightSearch.FlightNumber == flightField)
                {
                    if (rowData[1] == field)
                    {
                        flightList.Add(new Flights(rowData[0], rowData[1], rowData[2], rowData[3], rowData[4], rowData[5]));
                    }
                    continue;
                }
            }
            Console.ReadLine();
            streamReader.Close();
            fileStreamRead.Close();

            return flightList;
        }

        public List<Flights> SearchFlight(string origin, string destination)
        {
            List<Flights> flightList = new List<Flights>();

            FileStream fileStreamRead = new FileStream(@"C:\Users\criazo\Flights.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStreamRead);

            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string flightData;

            while ((flightData = streamReader.ReadLine()) != null)
            {
                string[] rowData = flightData.Split('-');

                if (rowData[2] == origin && rowData[3] == destination)
                {
                    flightList.Add(new Flights(rowData[0], rowData[1], rowData[2], rowData[3], rowData[4], rowData[5]));
                }

            }

            Console.ReadLine();
            streamReader.Close();
            fileStreamRead.Close();

            return flightList;
        }

        public enum FlightSearch
        {
            AirlineCode,
            FlightNumber
        }
    }
}
