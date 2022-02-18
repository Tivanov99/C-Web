using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.DataModels;
using CarShop.ViewModels;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(
            IRepository repo,
            IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public (bool registered, string error) Create(RegisterViewModel registerModel)
        {
            bool registered = false;
            string error = null;

            var (isValid, validationError) = validationService
                .Validate(registerModel);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            User user = new User()
            {
                Username = registerModel.Username,
                Email = registerModel.Email,
                Password = CalculateHash(registerModel.Password),
                IsMechanic = registerModel.UserType == "Mechanic" ? true : false
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }

            return (registered, error);
        }

        public (bool exists, string error) Login(LoginViewModel loginModel)
        {
            bool isExists = true;
            string error = null;

            var user = this.repo.All<User>()
                .Where(u => u.Username == loginModel.Username &&
                u.Password == CalculateHash(loginModel.Password))
                .FirstOrDefault();
            if (user == null)
            {
                error = "Invalid Username or Password!";
            }

            return (isExists, error);
        }
        private string CalculateHash(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
