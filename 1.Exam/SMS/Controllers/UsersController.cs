namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data.Common;
    using System.Runtime.CompilerServices;

    public class UsersController : Controller
    {
        private readonly IRepository repo;

        public UsersController(IRepository repository)
        {
            this.repo = repository;
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


    }
}
