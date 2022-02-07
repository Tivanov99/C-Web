namespace CarShop.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.DataForms;
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
        [HttpPost]
        public HttpResponse Login(LoginUserDataForm loginUserDataForm)
        {
            return this.Redirect("/Cars/All");
        }

        public HttpResponse Register()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Index");
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterDataForm registerUserDataForm)
        {
            return this.Login();
        }

    }
}
