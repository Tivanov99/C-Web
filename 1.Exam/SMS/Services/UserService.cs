namespace SMS.Services
{
    using SMS.Common;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly PasswordHasher passwordHasher;
        public UserService(IRepository repo, PasswordHasher passwordHasher)
        {
            this.repo = repo;
            this.passwordHasher = passwordHasher;
        }
        public void Create(UserRegisterModel userRegisterModel)
        {
            //this.repo.Add(user);
        }

        public bool IsUserExists(UserLoginModel userLoginModel)
        => this.repo
                .All<User>()
                .Where(u => u.Username == userLoginModel.Username &&
                u.Password == passwordHasher.Hash(userLoginModel.Password))
                .Any();


    }
}
