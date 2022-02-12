namespace MyWebServer.Services
{
    using Git.Contracts;
    using Git.Data;
    using MyWebServer.DataForm;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        private ApplicationDbContext dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateUser(RegisterDataForm registerDataForm)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExist(LoginDataForm loginDataForm)
        => this.dbContext
            .Users
            .Where(u => u.Password == loginDataForm.Password &&
            u.Username == loginDataForm.Username)
            .Any();
    }
}
