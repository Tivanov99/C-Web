namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using MyWebServer.Services;
    using SMS.Data;
    using SMS.Models;
    using SMS.Validator;
    using System.Linq;

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
            string username = userFormModel.Username;
            string password = this.passwordHasher.HashPassword(userFormModel.Password);

            bool userIsExist = this.dbContext
                .Users
                .Any(u => u.Username == username && u.Password == password);

            if (userIsExist)
            {
                this.SignIn(this.Request.Session.Id);
                return this.View();
            }

            return this.Redirect("Users/Login");
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.NotFound();
            }
            return this.View();
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
