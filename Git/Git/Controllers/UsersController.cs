
namespace Git.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.DataForm;
    using MyWebServer.Http;
    using MyWebServer.Services;

    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            if (IsUserAuthenticated())
            {
                return this.Redirect("/Repositories/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginDataForm dataForm)
        {
            if (this.userService.IsUserExist(dataForm))
            {
                return this.Redirect("/Repositories/All");
            }
            return this.Login();
        }
        

        public HttpResponse Register()
        {
            if (this.IsUserAuthenticated())
            {
                return this.Redirect("/Repositories/All");
            }
            return this.View();
        }
        private bool IsUserAuthenticated()
        => this.User.IsAuthenticated;
    }
}
