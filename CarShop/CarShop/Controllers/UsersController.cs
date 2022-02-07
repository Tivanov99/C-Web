namespace CarShop.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.DataForms;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        public HttpResponse Login()
            => this.View();

        [HttpPost]
        public HttpResponse Login(LoginUserDataForm loginUserDataForm)
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
