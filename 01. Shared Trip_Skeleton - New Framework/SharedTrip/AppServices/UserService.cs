namespace SharedTrip.AppServices
{
    using MyWebServer.Services;
    using SharedTrip.ApplicationModels;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Validator;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class UserService : IUserService
    {
        private ApplicationDbContext dbContext;
        private IPasswordHasher passwordHasher;
        private UserDataValidator userDataValidator;
        private string emailValidationTemplate = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        public UserService(ApplicationDbContext dbContext,
            IPasswordHasher passwordHasher,
            UserDataValidator userDataValidator)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
            this.userDataValidator = userDataValidator;
        }

        public bool Create(UserRegisterForm registerForm)
        {
            if (this.userDataValidator
                .IsValidRegistraionData(registerForm.Username,
                registerForm.Email,
                registerForm.Password,
                registerForm.ConfirmPassword))
            {
                string hashedPassword =
                    hashPassword(registerForm.Password);

                User user = new()
                {
                    Username = registerForm.Username,
                    Email = registerForm.Email,
                    Password = hashedPassword
                };

                this.dbContext.Users.Add(user);
                this.dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public string GetUserId(string username, string password)
        {
            string hashedPassword = this.passwordHasher.HashPassword(password);

            return this.dbContext
            .Users
            .Where(x => x.Id == username && x.Password == hashedPassword)
            .Select(x => x.Id)
            .FirstOrDefault();
        }

        public bool IsEmailAvailable(string email)
        => Regex.IsMatch(email, emailValidationTemplate);

        public bool IsUserAvailable(string username, string password)
        => this.dbContext
                .Users
                .Any(x => x.Username == username &&
                     x.Password == hashPassword(password));

        private string hashPassword(string password)
       => this.passwordHasher
                    .HashPassword(password);
    }
}
