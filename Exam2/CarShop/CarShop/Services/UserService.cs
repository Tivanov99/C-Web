using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.ViewModels;
using System;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public (bool registered, string error) Create(RegisterViewModel registerModel)
        {
            throw new NotImplementedException();
        }

        public (bool exists, string error) Login(LoginViewModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
