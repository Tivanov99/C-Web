namespace SMS.Services
{
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly IRepository repo;
        public UserService(IRepository repo)
        {
            this.repo = repo;
        }
        public void Create(User user)
        {
            this.repo.Add(user);
        }

        public bool IsUserExists(UserLoginModel userLoginModel)
        {
            return this.repo
                .All<User>()
                .Where(u => u.Username == userLoginModel.Username)
                .Any();
        }
    }
}
