using FlightReservation.BL.Entities;
using FlightReservation.BL.Validations.FlightMaintenance;
using FlightReservation.DL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace FlightReservation.BL.Test.Validations
{
    [TestClass]
    public class FlightQueryTest
    {
        private FlightQuery flightQuery;
        private Mock<IDataRepository> dataRepository;

        [TestInitialize]
        public void Setup()
        {
            dataRepository = new Mock<IDataRepository>();

            flightQuery = new FlightQuery(dataRepository.Object);
        }

        [TestCleanup]
        public void Teardown()
        {
            dataRepository = null;
            flightQuery = null;
        }

        //UNIT TEST E

        [TestMethod]
        public void CheckDuplicateFlights_InputFlightIsExisting_ReturnsTrue()
        {
            List<string> flightData = new List<string>()
            {
                "PR-100-MNL-DVO-12:00-13:00",
                "PR-100-MNL-DVO-12:00-13:01"
            };

            string flightInput = "PR-100-MNL-DVO-12:00-13:00";

            bool expected = true;

            dataRepository.Setup(d => d.ReadData()).Returns(flightData);

            bool actual = flightQuery.CreateFlight(flightInput);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckDuplicateFlights_InputFlightIsUnique_ReturnsFalse()
        {
            List<string> flightData = new List<string>()
            {
                "PR-100-MNL-DVO-12:00-13:00",
                "PR-100-MNL-DVO-12:00-13:01"
            };

            string flightInput = "PNR-100-MNL-DVO-12:00-13:00";

            bool expected = false;

            dataRepository.Setup(d => d.ReadData()).Returns(flightData);

            bool actual = flightQuery.CreateFlight(flightInput);

            Assert.AreEqual(expected, actual);
        }

        //UNIT TEST G - i and H
        [TestMethod]
        public void SearchFlights_InputFlightIsExisting_ReturnsExpectedValue()
        {
            List<string> flightData = new List<string>()
            {
                "PR-100-MNL-DVO-12:00-13:00",
                "PR-100-MNL-DVO-12:00-13:01"
            };

            string airlineCode = "PR";
            string flightNumber = "100";
            string departure = "MNL";
            string arrival = "DVO";

            int expectedCount = 2;

            dataRepository.Setup(d => d.ReadData()).Returns(flightData);

            List<Flights> actual = flightQuery.SearchFlight(airlineCode, flightNumber, departure, arrival);

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [TestMethod]
        public void SearchFlights_InputFlightDoesNotExist_ReturnsExpectedValue()
        {
            List<string> flightData = new List<string>();

            string airlineCode = "PR";
            string flightNumber = "100";
            string departure = "MNL";
            string arrival = "DVO";

            int expectedCount = 0;

            dataRepository.Setup(d => d.ReadData()).Returns(flightData);

            List<Flights> actual = flightQuery.SearchFlight(airlineCode, flightNumber, departure, arrival);

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }
}
