using CarShop.Data;
using CarShop.Data.DbModels;
using CarShop.DataForms;
using CarShop.Validator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext dbContext;
        private PasswordHasher passwordHasher;
        private DataValidator dataValidator;

        public UserService(ApplicationDbContext dbContex,
            PasswordHasher passwordHasher,
            DataValidator dataValidator)
        {
            this.dbContext = dbContex;
            this.passwordHasher = passwordHasher;
            this.dataValidator = dataValidator;
        }

        public void Create(UserRegisterDataForm registerUserDataForm)
        {
            bool IsValidData = dataValidator
                .IsValidUserRegistraionData(registerUserDataForm.Username,
                registerUserDataForm.Password,
                registerUserDataForm.ConfirmPassword,

                registerUserDataForm.Email);
            if (!IsUsernameAlreadyExists(registerUserDataForm.Username) && IsValidData)
            {
                string pass = passwordHasher.Hash(registerUserDataForm.Password);
                User newUser = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = registerUserDataForm.Username,
                    Email = registerUserDataForm.Email,
                    Password = pass.Substring(0, 20),
                    IsMechanic = IsUserMechanic(registerUserDataForm.UserType)
                };

                this.dbContext
                    .Users
                    .Add(newUser);

                this.dbContext.SaveChanges();
            }
        }

        public bool IsUserExist(LoginUserDataForm loginUserDataForm)
        {
            string pass = passwordHasher
                .Hash(loginUserDataForm.Password)
                .Substring(0, 20);

            return this.dbContext
                .Users
                .AsNoTracking()
                .Any(u => u.Username == loginUserDataForm.Username &&
                    u.Password == pass);
        }

        public bool GetUserTypeById(string id)
        => this.dbContext
                  .Users
                .AsNoTracking()
                  .Where(x => x.Id == id)
                  .Select(u => u.IsMechanic)
                  .First();

        public bool IsUsernameAlreadyExists(string username)
        => this.dbContext
                .Users
                .AsNoTracking()
                .Any(u => u.Username == username);

        private bool IsUserMechanic(string userType)
        {
            return userType == "Mechanic";
        }

        public string GetUserId(string username)
        => this.dbContext
            .Users
            .Where(u=>u.Username == username)
            .Select(u => u.Id)
            .FirstOrDefault();
    }
}
