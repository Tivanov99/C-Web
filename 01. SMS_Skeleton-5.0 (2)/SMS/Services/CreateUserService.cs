using SMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class CreateUserService : ICreateUserService
    {
        public User CreateUser(string username, string password, string email)
        {
            return new User()
            {
                Username = username,
                Password = password,
                Email = email
            };
        }
    }
}
