namespace SharedTrip.AppServices
{
    using MyWebServer.Services;
    using SharedTrip.ApplicationModels;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Validator;

    public class UserService : IUserService
    {
        private ApplicationDbContext dbContext;
        private IPasswordHasher passwordHasher;
        private UserDataValidator userDataValidator;
        public UserService(ApplicationDbContext dbContext,
            IPasswordHasher passwordHasher,
            UserDataValidator userDataValidator)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
            this.userDataValidator = userDataValidator;
        }
        public void Create(UserRegisterForm registerForm)
        {
            if (this.userDataValidator
                .IsValidRegistraionData(registerForm.Username,
                registerForm.Email,
                registerForm.Password,
                registerForm.ConfirmPassword))
            {
                string hashedPassword = this.passwordHasher
                    .HashPassword(registerForm.Password);

                User user = new()
                {
                    Username = registerForm.Username,
                    Email = registerForm.Email,
                    Password = hashedPassword
                };

                this.dbContext.Users.Add(user);
                this.dbContext.SaveChanges();
            }
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
