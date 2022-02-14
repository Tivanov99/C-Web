using SMS.Data.Models;
using SMS.Models;

namespace SMS.Contracts
{
    public interface IUserService
    {
        void Create(User user);

        bool IsUserExists(UserLoginModel userLoginModel);
    }
}
