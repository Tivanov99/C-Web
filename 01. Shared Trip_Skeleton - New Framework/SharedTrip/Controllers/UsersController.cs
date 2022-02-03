namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using MyWebServer.Services;
    using SharedTrip.ApplicationModels;
    using SharedTrip.Data;
    using SharedTrip.Validator;
    using System.Linq;

    public class UsersController : Controller
    {
        private ApplicationDbContext dbContext;
        private IPasswordHasher passwordHasher;
        UserDataValidator userDataValidator;
        public UsersController(ApplicationDbContext context,
            IPasswordHasher passwordHasher,
            UserDataValidator userDataValidator)
        {
            this.dbContext = context;
            this.passwordHasher = passwordHasher;
            this.userDataValidator = userDataValidator;
        }
        public HttpResponse Login()
        => this.View();

        [HttpPost]
        public HttpResponse Login(UserLoginForm userLoginForm)
        {
            string hashedPassword = this.passwordHasher
                .HashPassword(userLoginForm.Password);


            bool userIsExist = this.dbContext
                .Users
                .Where(x => x.Username == userLoginForm.Username &&
                x.Password == hashedPassword)
                .Any();

            if (userIsExist)
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        public HttpResponse Register()
            => this.View();

        [HttpPost]
        public HttpResponse Register(UserRegisterForm userRegisterForm)
        {
            if (this.userDataValidator
                .IsValidRegistraionData(userRegisterForm.Username,
                userRegisterForm.Email,
                userRegisterForm.Password,
                userRegisterForm.ConfirmPassword))
            {
                //TODO: Add the user to the db
                return this.Login();
            }
            return this.Register();
        }

    }
}
