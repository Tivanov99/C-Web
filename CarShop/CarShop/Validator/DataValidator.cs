namespace CarShop.Validator
{
    using MyWebServer.Common;
    using System.Text.RegularExpressions;

    public class DataValidator
    {
        public bool IsValidUserRegistraionData(string username,
            string password,
            string confrimPasswor,
            string email)
        {
            if (!IsUsernameValid(username))
            {
                return false;
            }
            if (!IsValidPassword(password))
            {
                return false;
            }
            if (!IsValidPassword(confrimPasswor) || !IsPasswordsAreTheSame(password, confrimPasswor))
            {
                return false;
            }
            if (!IsEmailValid(email))
            {
                return false;
            }
            return true;
        }

        private bool IsUsernameValid(string username)
        => username.Length >= GlobalConstants.UsernameMinLength &&
            username.Length <= GlobalConstants.UsernameMaxLength;

        private bool IsValidPassword(string password)
        => password.Length >= GlobalConstants.PassworMinLength &&
            password.Length <= GlobalConstants.PassworMaxLength;

        private bool IsPasswordsAreTheSame(string password, string confirmPassword)
            => password == confirmPassword;

        private bool IsEmailValid(string email)
            => Regex.IsMatch(email, GlobalConstants.EmailValidationTemplate);
    }
}
