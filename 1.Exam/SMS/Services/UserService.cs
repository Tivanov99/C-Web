namespace SMS.Services
{
    using SMS.Common;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly PasswordHasher passwordHasher;
        public UserService(IRepository repo, PasswordHasher passwordHasher)
        {
            this.repo = repo;
            this.passwordHasher = passwordHasher;
        }
        public void Create(UserRegisterModel userRegisterModel)
        {
            Cart cart = CreateUserCart();
           

            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = userRegisterModel.Username,
                Password = passwordHasher.Hash(userRegisterModel.Password).Substring(0, 20),
                Email = userRegisterModel.Email,
                Cart = cart,
                CartId= cart.Id
            };


            this.repo.Add<User>(user);
        }

        public string GetUserId(UserLoginModel userLoginModel)
        => this.repo
                .All<User>()
                .Where(u => u.Username == userLoginModel.Username &&
                u.Password == passwordHasher.Hash(userLoginModel.Password)
                .Substring(0, 20))
                .Select(x => x.Id)
            .FirstOrDefault();

        public (bool, ErrorViewModel) ValidateUser(UserRegisterModel userRegisterModel)
        {
            bool isValid = true;
            ErrorViewModel errors = new();

            if (string.IsNullOrWhiteSpace(userRegisterModel.Username) ||
                userRegisterModel.Username.Length < GlobalConstants.userNameMinLength ||
                 userRegisterModel.Username.Length > GlobalConstants.userNameMaxLength)
            {
                errors.Errors.Add(new ErrorMessage("Invalid Username!"));
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(userRegisterModel.Email))
            {
                errors.Errors.Add(new ErrorMessage("Invalid Email!"));
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(userRegisterModel.Password) ||
                userRegisterModel.Password.Length < GlobalConstants.userPasswordMinLength ||
                 userRegisterModel.Password.Length > GlobalConstants.userPasswordMaxLength)
            {
                errors.Errors.Add(new ErrorMessage("Invalid Password!"));
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(userRegisterModel.ConfirmPassword) ||
                userRegisterModel.ConfirmPassword.Length < GlobalConstants.userPasswordMinLength ||
                 userRegisterModel.ConfirmPassword.Length > GlobalConstants.userPasswordMaxLength)
            {
                errors.Errors.Add(new ErrorMessage("Invalid Password!"));
                isValid = false;
            }

            if (userRegisterModel.Password != userRegisterModel.ConfirmPassword)
            {
                errors.Errors.Add(new ErrorMessage("Both passwords should be same."));
                isValid = false;
            }
            return (isValid, errors);
        }
        private Cart CreateUserCart()
        => new Cart()
        {
            Id = Guid.NewGuid().ToString(),
        };
    }
}
