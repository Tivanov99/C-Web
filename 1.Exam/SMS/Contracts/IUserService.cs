using SMS.Data.Models;
using SMS.Models;
using System.Collections.Generic;

namespace SMS.Contracts
{
    public interface IUserService
    {
        void Create(UserRegisterModel userRegisterModel);

        bool IsUserExists(UserLoginModel userLoginModel);

        (bool, ErrorViewModel) ValidateUser(UserRegisterModel userRegisterModel);
    }
}
