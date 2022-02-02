namespace SMS.Validator
{
    using MyWebServer.Common;
    using SMS.Models;
    using System.Text.RegularExpressions;

    public static class UserDataValidator
    {
        public static bool Validate(RegisterUserFormModel registerForm)
        {
            if (!IsValidUsername(registerForm.Username))
            {
                //TODO: Check here
                return false;
            }

            if (!IsValidEmail(registerForm.Email))
            {
                return false;
            }

            if (!IsValidPassword(registerForm.ConfirmPassword)
                || !IsValidPassword(registerForm.ConfirmPassword))
            {
                return false;
            }

            return true;
        }
        private static bool IsValidUsername(string username)
        {
            return username.Length > GlobalConstants.usernameMinLength ||
                username.Length < GlobalConstants.usernameMaxLength;
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, GlobalConstants.emailValidationTemplate);
        }

        private static bool IsValidPassword(string password)
        {
            return password.Length > GlobalConstants.passwordMinLength ||
                password.Length < GlobalConstants.passwordMaxLength;
        }
    }
}
