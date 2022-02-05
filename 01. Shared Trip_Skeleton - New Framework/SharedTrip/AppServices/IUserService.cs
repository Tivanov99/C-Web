using SharedTrip.ApplicationModels;

namespace SharedTrip.AppServices
{
    public interface IUserService
    {
        void Create(UserRegisterForm registerForm);

        bool IsUserAvailable(string username);

        string GetUserId(string username, string password);

        bool IsEmailAvailable(string email);
    }
}
