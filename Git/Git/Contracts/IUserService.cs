namespace Git.Contracts
{
    using Git.Models;
    using MyWebServer.DataForm;
    using System.Collections.Generic;

    public interface IUserService
    {
        (bool, string) IsUserExists(LoginDataForm loginDataForm);

        void CreateUser(RegisterDataForm registerDataForm);

        (bool, IEnumerable<ErrorViewModel>) ValidateUser(RegisterDataForm loginDataForm);
    }
}
