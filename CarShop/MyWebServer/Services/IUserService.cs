namespace MyWebServer.Services
{
    using MyWebServer.DataForms;

    public interface IUserService
    {
        void Create(UserRegisterDataForm registerUserDataForm);

        bool IsUserExist(string username, string password);
    }
}
