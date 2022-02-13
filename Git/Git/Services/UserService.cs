namespace MyWebServer.Services
{
    using Git.Contracts;
    using Git.Data.Models;
    using Git.Models;
    using MyWebServer.Common;
    using MyWebServer.DataForm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly IRepository repository;
        public UserService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public void CreateUser(RegisterDataForm registerDataForm)
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = registerDataForm.Username,
                Email = registerDataForm.Email,
                Password = registerDataForm.Password,
            };
            this.repository.Add<User>(user);
            this.repository.SaveChanges();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool IsUserExists(LoginDataForm loginDataForm)
         => this.repository.All<User>()
            .Any(x => x.Username == loginDataForm.Username &&
            x.Password == HashPassword(loginDataForm.Password));

        public (bool, IEnumerable<ErrorViewModel>) ValidateUser
            (RegisterDataForm loginDataForm)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (string.IsNullOrEmpty(loginDataForm.Username)
                || loginDataForm.Username.Length < GlobalConstants.usernameMinLength
                || loginDataForm.Username.Length > GlobalConstants.usernameMaxLenght)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Invalid Username!"));
            }
            if (string.IsNullOrWhiteSpace(loginDataForm.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Invalid Email!"));
            }
            if (string.IsNullOrEmpty(loginDataForm.Password) ||
                string.IsNullOrEmpty(loginDataForm.ConfirmPassword) ||
                loginDataForm.ConfirmPassword.Length < GlobalConstants.passwordMinLength ||
                loginDataForm.ConfirmPassword.Length > GlobalConstants.passwordMaxLength)
            {
                isValid = false;
                errors.Add(new ErrorViewModel($"Password should be between {GlobalConstants.passwordMinLength} and {GlobalConstants.passwordMaxLength} characters length!"));
            }
            if (loginDataForm.Password != loginDataForm.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Passwords shoud be the same!"));
            }

            return (isValid, errors);
        }
    }
}
