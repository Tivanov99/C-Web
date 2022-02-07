namespace CarShop.Services
{
    using CarShop.DataForms;

    public interface IUserService
    {
        void Create(UserRegisterDataForm registerUserDataForm);

        bool IsUserExist(string username, string password);
    }
}
