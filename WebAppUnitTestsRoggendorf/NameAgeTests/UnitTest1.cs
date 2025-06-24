using System.ComponentModel.DataAnnotations;
using FirstResponsiveWebAppRoggendorf.Models;

namespace NameAgeTests
{
    public class UnitTest1
    {
        //Name Tests
        [Fact]
        public void ValidName()
        {
            //Arrange
            var user = new NameAgeModel { userName = "Bob", userDOB = DateTime.Today };
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>(); //To get error message

            //Act
            bool isValid = Validator.TryValidateObject(user, context, results, true);

            //Assert
            Assert.True(isValid);
            Assert.Empty(results);
        }
        [Fact]
        public void NullName()
        {
            //Arrange
            var user = new NameAgeModel { userName = null, userDOB = DateTime.Today };
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>(); //To get error message

            //Act
            bool isValid = Validator.TryValidateObject(user, context, results, true);

            //Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Please enter a name");
        }
        [Fact]
        public void NonAlphabeticName()
        {
            //Arrange
            var user = new NameAgeModel { userName = "Bob123", userDOB = DateTime.Today };
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>(); //To get error message

            //Act
            bool isValid = Validator.TryValidateObject(user, context, results, true);

            //Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Only letters are allowed.");
        }

        //Age Tests
        [Fact]
        public void AgePassedBirthday() //When current day is after the birthday
        {
            //Arrange
            var birthDate = new DateTime(DateTime.Today.Year - 20, 1, 1); //Jan 1, 20 years ago
            var user = new NameAgeModel { userDOB = birthDate };

            //Act
            int age = user.DisplayNameAndCurrentAge();

            //Assert
            Assert.Equal(20, age);
        }
        [Fact]
        public void AgeBeforeBirthday() //When current day is before birthday
        {
            //Arrange
            var birthDate = new DateTime(DateTime.Today.Year - 20, DateTime.Today.Month + 1, 1); //birthday in the next month
            var user = new NameAgeModel { userDOB = birthDate };

            //Act
            int age = user.DisplayNameAndCurrentAge();

            //Assert
            Assert.Equal(19, age);
        }
        [Fact]
        public void AgeBirthdayToday() //When current day is birhtday
        {
            //Arrange
            var birthDate = DateTime.Today.AddYears(-20); //birthday today
            var user = new NameAgeModel { userDOB = birthDate };

            //Act
            int age = user.DisplayNameAndCurrentAge();

            //Assert
            Assert.Equal(20, age);
        }
        [Fact]
        public void NullDOB()
        {
            // Arrange
            var user = new NameAgeModel { userDOB = null };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => user.DisplayNameAndCurrentAge());
        }
    }

    
}