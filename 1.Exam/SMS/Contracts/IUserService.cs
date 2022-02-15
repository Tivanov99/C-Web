using SMS.Models;

namespace SMS.Contracts
{
    public interface IUserService
    {
        void Create(UserRegisterModel userRegisterModel);

        string GetUserId(UserLoginModel userLoginModel);

        (bool, ErrorViewModel) ValidateUser(UserRegisterModel userRegisterModel);
    }
}
