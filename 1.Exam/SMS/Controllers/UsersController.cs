namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Contracts;
    using SMS.Models;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Home");
            }
            return this.View();
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Home");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterModel userRegisterModel)
        {
            var (isValid, errors) = this.userService
                .ValidateUser(userRegisterModel);

            if (!isValid)
            {
                return this.View(errors);
            }

            this.userService.Create(userRegisterModel);

            return this.Login();
        }
        [HttpPost]
        public HttpResponse Login(UserLoginModel userLoginModel)
        {
            if (this.userService.IsUserExists(userLoginModel))
            {
                this.SignIn(); 
                return this.Redirect("/Home");
            }
            return this.Login();
        }
    }
}