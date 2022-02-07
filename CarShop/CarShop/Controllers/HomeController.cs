namespace CarShop.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View();
            }

            return this.Redirect("/Cars/All");
        }
    }
}
