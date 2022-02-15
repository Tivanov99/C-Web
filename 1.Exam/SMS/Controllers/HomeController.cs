namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }

        public HttpResponse IndexLoggedIn()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Users/Login");
        }
    }
}