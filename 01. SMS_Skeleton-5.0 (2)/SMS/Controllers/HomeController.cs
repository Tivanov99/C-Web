namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View("IndexLoggedIn");
            }
            return this.View();
        }
    }
}