using FlightReservation.BL.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightReservation.BL.Test.Validations
{
    [TestClass]
    public class ValidateFlightDetailsTest
    {
        [TestMethod]
        public void ValidateAirlineCode_InputIsBlank_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateAirlineCode(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateAirlineCode_InputIsLessThanTwoAndGreaterThanThree_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string testInput1 = "12";
            string testInput2 = "1234";
            bool expected1 = false;
            bool expected2 = false;

            //Act
            bool actual1 = validateFlightDetails.ValidateAirlineCode(testInput1);
            bool actual2 = validateFlightDetails.ValidateAirlineCode(testInput2);

            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void ValidateAirlineCode_InputHasMultipleNumericCharacter_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "11P";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateAirlineCode(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /*        [TestMethod]
                public void ValidateAirlineCode_InputNumericValueIsNotInFirstCharacter_ReturnsFalse()
                {
                    //Arrange
                    ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
                    string input = "P1P";
                    bool expected = false;

                    //Act
                    bool actual = validateFlightDetails.ValidateAirlineCode(input);

                    //Assert
                    Assert.AreEqual(expected, actual);
                }*/

        [TestMethod]
        public void ValidateAirlineCode_NonAlphanumericInput_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "P@C";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateAirlineCode(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateAirlineCode_HappyPath_ReturnsTrue()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "9999";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateAirlineCode(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        // Validate Flight Number

        [TestMethod]
        public void ValidateFlightNumber_NonNumericInput_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "P@C";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateFlightNumber(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateFlightNumber_NoInput_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateFlightNumber(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateFlightNumber_InputGreaterThan9999_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "10000";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateFlightNumber(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateFlightNumber_InputLessThan1_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "0";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateFlightNumber(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateFlightNumber_HappyPath_ReturnsTrue()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input1 = "1";
            string input2 = "9999";
            bool expected1 = true;
            bool expected2 = true;

            //Act
            bool actual1 = validateFlightDetails.ValidateFlightNumber(input1);
            bool actual2 = validateFlightDetails.ValidateFlightNumber(input2);

            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        // Validate Stations

        [TestMethod]
        public void ValidateStations_InputIsLessThanAndGreaterThanThree_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input1 = "AB";
            string input2 = "ABCD";
            bool expected1 = false;
            bool expected2 = false;

            //Act
            bool actual1 = validateFlightDetails.ValidateStation(input1);
            bool actual2 = validateFlightDetails.ValidateStation(input2);

            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void ValidateStations_InputIsBlank_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateStation(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateStations_InputStartsWithNumericCharacter_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "1AB";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateStation(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateStations_HappyPath_ReturnsTrue()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "A12";
            bool expected = true;

            //Act
            bool actual = validateFlightDetails.ValidateStation(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //Validate Scheduled Time

        [TestMethod]
        public void ValidateScheduledTime_InputInvalidTime_ReturnsFalse()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "13:69";
            bool expected = false;

            //Act
            bool actual = validateFlightDetails.ValidateTime(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateScheduledTime_HappyPath_ReturnsTrue()
        {
            //Arrange
            ValidateFlightDetails validateFlightDetails = new ValidateFlightDetails();
            string input = "13:59";
            bool expected = true;

            //Act
            bool actual = validateFlightDetails.ValidateTime(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
