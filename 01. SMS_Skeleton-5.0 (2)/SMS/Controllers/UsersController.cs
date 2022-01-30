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
                return this.Redirect("/Index");
            }

            return this.Login();
        }
        public HttpResponse Registration()
        {
            string username = this.Request.Form["username"];
            string password = this.Request.Form["password"];
            string email = this.Request.Form["email"];
            string confirmPassword = this.Request.Form["confirmPassword"];

            if (password == confirmPassword)
            {
                //TODO: Add new user to the db
                return this.Login();
            }

            return this.Register();
        }
    }
}
