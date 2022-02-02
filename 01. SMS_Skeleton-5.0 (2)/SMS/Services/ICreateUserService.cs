using SMS.Data.Models;

namespace SMS.Services
{
    public interface ICreateUserService
    {
        User CreateUser(string username, string password, string email);
    }
}
