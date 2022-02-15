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
                return this.View("/Error", errors);
            }

            this.userService.Create(userRegisterModel);

            return this.Login();
        }
        [HttpPost]
        public HttpResponse Login(UserLoginModel userLoginModel)
        {
            string userId = this.userService.GetUserId(userLoginModel);
            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Home");
            }

            ErrorViewModel errorViewModel = new ErrorViewModel();
            errorViewModel.Errors.Add(new ErrorMessage("Invalid username or password!"));
            return this.View("/Error", errorViewModel);
        }
    }
}