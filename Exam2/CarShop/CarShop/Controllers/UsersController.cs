namespace CarShop.Controllers
{
    using CarShop.Contracts;
    using CarShop.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Index");
        }

        public HttpResponse Register()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Index");
        }

        [HttpPost]
        public HttpResponse Register(RegisterViewModel registerModel)
        {
            var (isRegistered, error) = userService
                .Create(registerModel);

            if (isRegistered)
            {
                return Redirect("/Users/Login");
            }

            return View(new { ErrorMessage = error }, "/Error");
        }

        [HttpPost]
        public HttpResponse Login(LoginViewModel loginModel)
        {
            (bool isExists, string error) = this.userService
                .Login(loginModel);
            if (!isExists)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return this.Redirect("/Cars/All");
        }
    }
}
