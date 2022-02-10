
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
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Index");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginDataForm dataForm)
        {
            if (this.userService.IsUserExist(dataForm))
            {

            }
            return this.Login();
        }
    }
}
