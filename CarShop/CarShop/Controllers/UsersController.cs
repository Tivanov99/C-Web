namespace CarShop.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        public HttpResponse Login()
            => this.View();

        [HttpPost]
        public HttpResponse Login()
        {
            return this.Redirect("/Cars/All");
        }

        public HttpResponse Register()
            => this.View();

        [HttpPost]
        public HttpResponse Register()
        {
            return this.Login();
        }

    }
}
