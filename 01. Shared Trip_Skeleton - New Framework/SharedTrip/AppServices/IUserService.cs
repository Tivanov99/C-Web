using SharedTrip.ApplicationModels;

namespace SharedTrip.AppServices
{
    public interface IUserService
    {
        bool Create(UserRegisterForm registerForm);

        bool IsUserAvailable(string username, string password);

        string GetUserId(string username, string password);

        bool IsEmailAvailable(string email);
    }
}
