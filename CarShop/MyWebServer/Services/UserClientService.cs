namespace MyWebServer.Services
{
    using MyWebServer.DataForms;
    using System;

    public class UserClientService : IUserService
    {
        public void Create(UserRegisterDataForm registerUserDataForm)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExist(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
