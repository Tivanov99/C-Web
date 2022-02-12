namespace Git.Contracts
{
    using MyWebServer.DataForm;

    public interface IUserService
    {
        bool IsUserExists(LoginDataForm loginDataForm);

        void CreateUser(RegisterDataForm registerDataForm);

    }
}
