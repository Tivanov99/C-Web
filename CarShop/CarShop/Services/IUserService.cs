namespace CarShop.Services
{
    using CarShop.DataForms;

    public interface IUserService
    {

        void Create(UserRegisterDataForm registerUserDataForm);

        bool IsUserExist(LoginUserDataForm loginUserDataForm);

        bool GetUserTypeById(string id);

        bool IsUsernameAlreadyExists(string username);
    }
}
