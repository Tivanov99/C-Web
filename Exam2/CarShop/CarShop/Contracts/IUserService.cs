using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface IUserService
    {
        (bool registered, string error) Create(RegisterViewModel registerModel);

        (bool exists, string error) Login(LoginViewModel loginModel);

    }
}
