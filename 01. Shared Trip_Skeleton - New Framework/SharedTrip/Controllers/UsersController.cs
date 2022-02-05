namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.ApplicationModels;
    using SharedTrip.AppServices;
    using System.Collections.Generic;

    public class UsersController : Controller
    {
        private IUserService userService;

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
            return this.Error("You can't access this page because you are logged in your account!");
        }

        [HttpPost]
        public HttpResponse Login(UserLoginForm userLoginForm)
        {
            string userId = this.userService
                .GetUserId(userLoginForm.Username, userLoginForm.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        public HttpResponse Register()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Error(new List<string>() { "You can't access this page because you are logged in your account!" });
        }

        [HttpPost]
        public HttpResponse Register(UserLoginForm userLoginForm)
        {
            if (this.userService.IsUserAvailable(userLoginForm))
            {
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
