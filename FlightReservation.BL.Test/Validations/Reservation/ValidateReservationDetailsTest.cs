using FlightReservation.BL.Validations.Reservation;
using FlightReservation.DL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace FlightReservation.BL.Test.Validations.Reservation
{
    [TestClass]
    public class ValidateReservationDetailsTest
    {
        private ValidateReservationDetails validateReservationDetails;

        [TestInitialize]
        public void Setup()
        {
            validateReservationDetails = new ValidateReservationDetails();
        }

        [TestCleanup]
        public void Teardown()
        {
            validateReservationDetails = null;
        }

        //UNIT TEST F - iv

        [TestMethod]
        public void CheckPassengerCount_PassengerCountIsLessThanOne_ReturnsFalse()
        {
            string input = "0";

            bool expected = false;

            bool actual = validateReservationDetails.PassengerCount(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckPassengerCount_PassengerCountIsGreaterThanFive_ReturnsFalse()
        {
            string input = "6";

            bool expected = false;

            bool actual = validateReservationDetails.PassengerCount(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckPassengerCount_PassengerCountIsNotNumeric_ReturnsFalse()
        {
            string input = "ABC@!@";

            bool expected = false;

            bool actual = validateReservationDetails.PassengerCount(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckPassengerCount_PassengerCountHappyPath_ReturnsTrue()
        {
            string input = "5";

            bool expected = true;

            bool actual = validateReservationDetails.PassengerCount(input);

            Assert.AreEqual(expected, actual);
        }

        //Unit Test G ii
        //
        [TestMethod]
        public void ValidateIfPastDated_FlightIsPastDated_ReturnsFalse()
        {
            string date = "01/01/2000";
            bool expected = false;

            bool actual = validateReservationDetails.ValidateIfPastDated(date);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateIfPastDated_FlightIsPresentDated_ReturnsTrue()
        {
            string date = DateTime.Now.Date.ToString("MM/dd/yyyy");
            bool expected = true;

            bool actual = validateReservationDetails.ValidateIfPastDated(date);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateIfPastDated_FlightIsFutureDated_ReturnsTrue()
        {
            string date = "01/01/2024";
            bool expected = true;

            bool actual = validateReservationDetails.ValidateIfPastDated(date);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePNRNumber_HappyPath_ReturnsTrue()
        {
            string pnrNumber = "P12GHX";

            bool expected = true;

            bool actual = validateReservationDetails.ValidatePNRNumber(pnrNumber);

            Assert.AreEqual(expected, actual);
        }
    }
}
