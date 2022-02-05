namespace SharedTrip.AppServices
{
    using SharedTrip.ApplicationModels;
    using SharedTrip.Data;

    public class UserService : IUserService
    {
        private ApplicationDbContext dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(UserRegisterForm registerForm)
        {
            throw new System.NotImplementedException();
        }

        public string GetUserId(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmailAvailable(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool IsUserAvailable(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}
