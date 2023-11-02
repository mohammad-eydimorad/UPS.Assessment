using System.Text.RegularExpressions;

namespace Libs.Utils
{
    public static class EmailValidator
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Define a regular expression pattern for a valid email address
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Create a Regex object and use it to match the email
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }
}
