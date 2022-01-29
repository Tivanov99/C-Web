namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        public HttpResponse Login()
        => this.View();

        public HttpResponse Register()
            => this.View();

        public HttpResponse LoggingInUser()
        {
            bool validUsername = this.Request.Form["username"] == "user";
            bool validPassword = this.Request.Form["password"] == "user123";

            if (validUsername && validPassword)
            {
                this.SignIn(this.Request.Session.Id);
                return this.View();
            }

            return this.Login();
        }
    }
}
