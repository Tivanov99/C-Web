using MyWebServer.DataForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Services
{
    public class UserMechanicService : IUserService
    {
        public void Create(UserRegisterDataForm registerUserDataForm)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExist(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
