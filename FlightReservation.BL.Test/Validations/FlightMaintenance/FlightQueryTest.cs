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
        public void CheckDuplicateFlights_InputFlightIsExisting_ReturnsFalse()
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
    }
}
