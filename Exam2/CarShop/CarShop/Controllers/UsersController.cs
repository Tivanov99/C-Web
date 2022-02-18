namespace CarShop.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Index");
        }
        public HttpResponse Register()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Index");
        }

    }
}
