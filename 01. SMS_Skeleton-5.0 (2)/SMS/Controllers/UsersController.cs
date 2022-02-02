namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using SMS.Data.Models;
    using MyWebServer.Http;
    using MyWebServer.Services;
    using SMS.Data;
    using SMS.Models;
    using SMS.Validator;

    public class UsersController : Controller
    {
        private IPasswordHasher passwordHasher;
        private SMSDbContext dbContext;

        public UsersController(IPasswordHasher passwordHasher, SMSDbContext dbContext)
        {
            this.passwordHasher = passwordHasher;
            this.dbContext = dbContext;
        }
        public HttpResponse Login()
        => this.View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel userFormModel)
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.NotFound();
            }
            return this.View();
        }

        public HttpResponse LoggingInUser()
        {
            bool validUsername = this.Request.Form["username"] == "user";
            bool validPassword = this.Request.Form["password"] == "user123";

            if (validUsername && validPassword)
            {
                this.SignIn(this.Request.Session.Id);
                return this.Redirect("/Index");
            }

            return this.Login();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel registerForm)
        {
            bool isValidRegistration = UserDataValidator.Validate(registerForm);

            if (isValidRegistration == true)
            {
                string password = passwordHasher
                    .HashPassword(registerForm.Password);

                Data.Models.User user = new Data.Models.User()
                {
                    Username = registerForm.Username,
                    Password = password,
                    Email = registerForm.Email,
                };

                this.dbContext
                    .Users
                    .Add(user);

                this.dbContext.SaveChanges();

                return this.Login();
            }

            return this.Register();
        }
        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/Index");
        }
    }
}
