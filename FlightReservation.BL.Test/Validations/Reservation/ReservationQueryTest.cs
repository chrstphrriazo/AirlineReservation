using FlightReservation.BL.Entities;
using FlightReservation.BL.Validations.Reservation;
using FlightReservation.DL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace FlightReservation.BL.Test.Validations.Reservation
{
    [TestClass]
    public class ReservationQueryTest
    {
        private ReservationQuery reservationQuery;
        private Mock<IDataRepository> dataRepository;

        [TestInitialize]
        public void Setup()
        {
            dataRepository = new Mock<IDataRepository>();

            reservationQuery = new ReservationQuery(dataRepository.Object);
        }

        [TestCleanup]
        public void Teardown()
        {
            dataRepository = null;
            reservationQuery = null;
        }

        //UNIT TEST G iv
        [TestMethod]
        public void CheckDuplicatePNR_PNRNumberHasDuplicate_ExpectedIsNotEqualToActual()
        {
            List<string> reservationData = new List<string>()
            {
                "PR-100-MNL-DVO-04/28/2023-ABCDEF"
            };

            string expectedPNR = "ABCDEF";
            string actualPNR = "ABCDEF";

            dataRepository.Setup(d => d.ReadData()).Returns(reservationData);

            actualPNR = reservationQuery.CheckDuplicatePNR(actualPNR);

            Assert.AreNotEqual(expectedPNR, actualPNR);
        }

        //UNIT TEST I 

        [TestMethod]
        public void SearchByPNRNumber_PNRNumberIsExisting_ReturnsExpected()
        {
            List<string> reservationsList = new List<string>()
            {
                "PR-100-MNL-DVO-04/28/2023-ABCDEF"
            };

            string expected = "ABCDEF";
            string search = "ABCDEF";

            List<Reservations> actualReservation = new List<Reservations>();

            dataRepository.Setup(d => d.ReadData()).Returns(reservationsList);

            actualReservation = reservationQuery.SearchByPNRNumber(search);

            Assert.AreEqual(expected, actualReservation[0].PNRNumber);
        }

        [TestMethod]
        public void SearchByPNRNumber_PNRNumberDoesNotExist_ReturnsExpected()
        {
            List<string> reservationsList = new List<string>()
            {
            };

            int expectedCount = 0;
            string search = "ABCDEF";

            List<Reservations> actualReservation = new List<Reservations>();

            dataRepository.Setup(d => d.ReadData()).Returns(reservationsList);

            actualReservation = reservationQuery.SearchByPNRNumber(search);

            Assert.AreEqual(expectedCount, actualReservation.Count);
        }

        //Unit Test J
        [TestMethod]
        public void GetAllReservations_ReservationsExist_ReturnsExpected()
        {
            List<string> reservationsList = new List<string>()
            {
                "PR-100-MNL-DVO-04/28/2023-ABCDEF",
                "PR-100-MNL-CEB-04/28/2023-GHIJKL",
                "PR-100-MNL-JAP-04/28/2023-MNOPQR"
            };

            int expectedCount = 3;

            List<Reservations> actualReservation = new List<Reservations>();

            dataRepository.Setup(d => d.ReadData()).Returns(reservationsList);

            actualReservation = reservationQuery.GetAllReservations();

            Assert.AreEqual(expectedCount, actualReservation.Count);
        }

        [TestMethod]
        public void GetAllReservations_ReservationsDoesNotExist_ReturnsExpected()
        {
            List<string> reservationsList = new List<string>()
            {
            };

            int expectedCount = 0;

            List<Reservations> actualReservation = new List<Reservations>();

            dataRepository.Setup(d => d.ReadData()).Returns(reservationsList);

            actualReservation = reservationQuery.GetAllReservations();

            Assert.AreEqual(expectedCount, actualReservation.Count);
        }
    }
}
