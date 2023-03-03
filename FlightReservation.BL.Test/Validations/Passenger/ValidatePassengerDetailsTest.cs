using FlightReservation.BL.Validations.Passenger;
using FlightReservation.BL.Validations.Reservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlightReservation.BL.Test.Validations.Passenger
{
    [TestClass]
    public class ValidatePassengerDetailsTest
    {
        private ValidatePassengerDetails validatePassengerDetails;

        [TestInitialize]
        public void Setup()
        {
            validatePassengerDetails = new ValidatePassengerDetails();
        }

        [TestCleanup]
        public void Teardown()
        {
            validatePassengerDetails = null;
        }

        //UNIT TEST F i - iii
        [TestMethod]
        public void ValidateName_FirstNameIsBlank_ReturnsFalse()
        {
            bool expected = false;

            string firstName = string.Empty;

            bool actual = validatePassengerDetails.ValidateName(firstName);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateName_LastNameIsBlank_ReturnsFalse()
        {
            bool expected = false;

            string lastName = string.Empty;

            bool actual = validatePassengerDetails.ValidateName(lastName);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateName_FirstNameHasMoreThen20Characters_ReturnsFalse()
        {
            bool expected = false;

            string firstName = "Chrisostomo De Jesus Procopio Dela Cruz Y John";

            bool actual = validatePassengerDetails.ValidateName(firstName);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateName_LastNameHasMoreThen20Characters_ReturnsFalse()
        {
            bool expected = false;

            string lastName = "Santosisimonalisaenotondalism";

            bool actual = validatePassengerDetails.ValidateName(lastName);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateName_FirstNameHappyPath_ReturnsTrue()
        {
            bool expected = true;

            string lastName = "Jose";

            bool actual = validatePassengerDetails.ValidateName(lastName);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateName__LastNameHappyPath_ReturnTrue()
        {
            bool expected = true;

            string lastName = "Rizal";

            bool actual = validatePassengerDetails.ValidateName(lastName);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateIfFutureDated_BirthDateInputIsFutureDated_ReturnsFalse()
        {
            bool expected = false;

            string birthDate = "12/25/2199";

            bool actual = validatePassengerDetails.ValidateIfFutureDated(birthDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateIfFutureDated_BirthDateInputIsToday_ReturnsTrue()
        {
            bool expected = true;

            string birthDate = (DateTime.Now.Date).ToString("MM/dd/yyyy");

            bool actual = validatePassengerDetails.ValidateIfFutureDated(birthDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateIfFutureDated_BirthDateInputIsPastDated_ReturnsTrue()
        {
            bool expected = true;

            string birthDate = "04/28/1990";

            bool actual = validatePassengerDetails.ValidateIfFutureDated(birthDate);

            Assert.AreEqual(expected, actual);
        }

        //G iii

        [TestMethod]
        public void CalculateAge_BirthDateInputIsToday_ReturnsExpectedValue()
        {
            string expected = "0";

            string birthDate = (DateTime.Now.Date).ToString("MM/dd/yyyy");

            string actual = validatePassengerDetails.CalculateAge(birthDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAge_BirthDateInputIsPastDated_ReturnsExpecteedValue()
        {
            string expected = "22";

            string birthDate = "04/28/2000";

            string actual = validatePassengerDetails.CalculateAge(birthDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAge_BirthDateInputIsLeapYear_ReturnsExpecteedValue()
        {
            string expected = "23";

            string birthDate = "02/29/2000";

            string actual = validatePassengerDetails.CalculateAge(birthDate);

            Assert.AreEqual(expected, actual);
        }
    }
}
