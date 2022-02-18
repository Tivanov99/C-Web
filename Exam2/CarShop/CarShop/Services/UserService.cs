using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.DataModels;
using CarShop.ViewModels;
using System;

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

            (bool isValid, string validationError) = this.validationService
                .Validate(registerModel);

            if (!isValid)
            {
                return (isValid, error);
            }

            User user = new User()
            {
                Username = registerModel.Username,
                Email = registerModel.Email,
                Password = registerModel.Password,
                IsMechanic = registerModel.UserType == "Mechanic" ? true : false
            };

            try
            {
                this.repo.Add<User>(user);
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
            throw new NotImplementedException();
        }
    }
}
