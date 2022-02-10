using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Services
{
    public interface IUserService
    {
        bool IsUserExist(string username, string password);

        void CreateUser()
    }
}
