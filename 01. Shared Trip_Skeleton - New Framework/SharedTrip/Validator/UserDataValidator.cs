using MyWebServer.Common;
using System.Text.RegularExpressions;

namespace SharedTrip.Validator
{
    public class UserDataValidator
    {
        private string emailRegexTemplate = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        public UserDataValidator()
        {

        }

        public bool IsValidRegistraionData(string username, string email,
            string password, string confirmPassword)
        {
            if (!ValidUsername(username))
            {
                return false;
            }

            if (!ValidEmail(email))
            {
                return false;
            }
            if (!ValidPassword(password) ||
                !ValidPassword(confirmPassword) ||
                !PasswordComparator(password, confirmPassword))
            {
                return false;
            }

            return true;
        }

        public bool IsValidLoginData(string username, string password)
        {
            if (!ValidUsername(username))
            {
                return false;
            }
            if (!ValidPassword(password))
            {
                return false;
            }
            return true;
        }

        private bool ValidUsername(string username)
        {
            return username.Length >= GlobalConstants.UsernameMinLength &&
                username.Length <= GlobalConstants.UsernameMaxLength;
        }
        private bool ValidEmail(string email)
        {
            return Regex.IsMatch(email, this.emailRegexTemplate);
        }
        private bool ValidPassword(string password)
        {
            return password.Length >= GlobalConstants.PasswordMinLength &&
                password.Length <= GlobalConstants.PasswordMaxLength;
        }
        private bool PasswordComparator(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }
    }
}
