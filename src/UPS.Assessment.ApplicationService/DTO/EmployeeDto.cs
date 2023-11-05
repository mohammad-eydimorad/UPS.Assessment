using Libs.Utils;

namespace UPS.Assessment.ApplicationService.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }


        public static EmployeeDto Create(int id, string name, string email, string gender, string status)
        {
            var employee = Create(name, email, gender, status);
            employee.SetId(id);
            return employee;
        }

        public static EmployeeDto Create(string name, string email, string gender, string status)
        {
            var employee = new EmployeeDto()
            {
                Gender = gender,
                Status = status
            };
            employee.SetName(name);
            employee.SetEmail(email);
            return employee;
        }

        private void SetId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Id));
            }

            Id = id;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(Name));
            }

            if (name.Length > 50)
            {
                throw new ArgumentException($"{nameof(Name)} is too long. Maximum length is 50 characters.");
            }
            this.Name = name;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email");
            }

            if (!EmailValidator.IsValidEmail(email))
            {
                throw new ArgumentException("Email is not valid.");
            }

            this.Email = email;
        }
    }
}
