namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using MyWebServer.Services;
    using SMS.Models;
    using SMS.Validator;

    public class UsersController : Controller
    {
        private IPasswordHasher passwordHasher;

        public UsersController(IPasswordHasher passwordHasher)
        {
            this.passwordHasher = passwordHasher;
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
                string password = passwordHasher.HashPassword(registerForm.Password);

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
