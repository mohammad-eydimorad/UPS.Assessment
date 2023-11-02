namespace UPS.Assessment.Domain.UnitTests
{
    public class EmployeeTests
    {
        [Fact]
        public void Create_ValidEmployee_ReturnsEmployee()
        {
            // Arrange
            int id = 1;
            string name = "Name";
            string email = "name@example.com";
            Gender gender = Gender.Male;
            Status status = Status.Active;

            // Act
            var employee = Employee.Create(id, name, email, gender, status);

            // Assert
            Assert.NotNull(employee);
            Assert.Equal(id, employee.Id);
            Assert.Equal(name, employee.Name);
            Assert.Equal(email, employee.Email);
            Assert.Equal(gender, employee.Gender);
            Assert.Equal(status, employee.Status);
        }

        [Fact]
        public void Create_InvalidId_ThrowsArgumentNullException()
        {
            // Arrange
            int invalidId = -1;
            string name = "Name";
            string email = "name@sample.com";
            Gender gender = Gender.Male;
            Status status = Status.Active;

            // Act and Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                    Employee.Create(invalidId, name, email, gender, status));
            Assert.Equal("Id", exception.ParamName);
        }

        [Fact]
        public void Create_NullName_ThrowsArgumentNullException()
        {
            // Arrange
            string email = "name@sample.com";
            Gender gender = Gender.Male;
            Status status = Status.Active;

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => 
                    Employee.Create(null, email, gender, status));
            Assert.Equal("Name", exception.ParamName);
        }

        [Fact]
        public void Create_TooLongName_ThrowsArgumentException()
        {
            // Arrange
            string email = "name@sample.com";
            Gender gender = Gender.Male;
            Status status = Status.Active;
            string longName = new('A', 51);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Employee.Create(longName, email, gender, status));
        }

        [Theory]
        [InlineData("valid@example.com")]
        [InlineData("another_valid.email@example.co.uk")]
        [InlineData("123@example.net")]
        [InlineData("test.email@example-domain.com")]
        public void Create_ValidEmail_ReturnsTrue(string email)
        {
            // Arrange
            string name = "name";
            Gender gender = Gender.Male;
            Status status = Status.Active;

            // Act
            var employee = Employee.Create(name, email, gender, status);

            // Assert
            Assert.NotNull(employee);
        }

        [Theory]
        [InlineData("invalid_email")]
        [InlineData("no@tld.")]
        [InlineData("invalid@.com")]
        public void Create_InvalidEmail_ReturnsFalse(string invalidEmail)
        {
            // Arrange
            string name = "name";
            Gender gender = Gender.Male;
            Status status = Status.Active;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Employee.Create(name, invalidEmail, gender, status));
        }

        [Fact]
        public void Create_NullEmail_ThrowsArgumentNullException()
        {
            // Arrange
            string name = "name";
            Gender gender = Gender.Male;
            Status status = Status.Active;

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                    Employee.Create(name, null, gender, status));
            Assert.Equal("Email", exception.ParamName);
        }

        [Fact]
        public void Create_InvalidEmail_ThrowsArgumentNullException()
        {
            // Arrange
            string name = "name";
            Gender gender = Gender.Male;
            Status status = Status.Active;
            string invalidEmail = "invalid_email";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Employee.Create(name, invalidEmail, gender, status));
        }
    }
}