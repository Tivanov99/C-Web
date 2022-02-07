using CarShop.Data;
using CarShop.Data.DbModels;
using CarShop.DataForms;
using System;
using System.Linq;

namespace CarShop.Services
{

    public abstract class UserService
    {
        private ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContex)
        {
            this.dbContext = dbContex;
        }

        public void Create(UserRegisterDataForm registerUserDataForm)
        {
            if (!IsUsernameAlreadyExists(registerUserDataForm.Username))
            {
                User newUser = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = registerUserDataForm.Email,
                    //TODO: Hash password
                    Password = registerUserDataForm.Password,
                    IsMechanic = IsUserMechanic(registerUserDataForm.UserType)
                };

                this.dbContext
                    .Users
                    .AddAsync(newUser);
            }
        }

        public bool IsUserExist(string username, string password)
        {
            throw new NotImplementedException();
        }

        private bool IsUsernameAlreadyExists(string username)
        {
            return this.dbContext
                .Users
                .Any(u => u.Username == username);
        }
        private bool IsUserMechanic(string userType)
        {
            return userType == "Mechanic";
        }
    }
}
