using Libs.Utils;
using System;

namespace UPS.Assessment.Domain
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public Status Status { get; private set; }

        public static Employee Create(int id, string name, string email, Gender gender, Status status)
        {
            var employee = Create(name, email, gender, status);
            employee.SetId(id);
            return employee;
        }

        public static Employee Create(string name, string email, Gender gender, Status status)
        {
            var employee = new Employee()
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
            Name = name;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email");
            }

            if(!EmailValidator.IsValidEmail(email))
            {
                throw new ArgumentException("Email is not valid.");
            }

            Email = email;
        }
    }
}
