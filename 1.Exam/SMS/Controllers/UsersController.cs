namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Models;
    using System.Runtime.CompilerServices;

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

        }
    }
}
