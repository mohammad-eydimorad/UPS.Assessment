using Libs.Utils;

namespace UPS.Assessment.ApplicationService.DTO
{
    public class EmployeeDto
    {
        private string _name = "";
        private int _id;
        private string email = "";

        public int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Id));
                }

                _id = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name));
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException($"{nameof(Name)} is too long. Maximum length is 50 characters.");
                }
                _name = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Email));
                }

                if (!EmailValidator.IsValidEmail(value))
                {
                    throw new ArgumentException("Email is not valid.");
                }

                email = value;
            }
        }
        public string Gender { get; set; } = "";
        public string Status { get; set; } = "";

        public EmployeeDto() { }

        public EmployeeDto(int id, string name, string email, string gender, string status)
            : this(name, email, gender, status)
        {
            Id = id;
        }

        public EmployeeDto(string name, string email, string gender, string status)
        {
            Gender = gender;
            Status = status;
            Name = name;
            Email = email;
        }
    }
}
