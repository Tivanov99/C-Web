namespace BasicWebServer.Demo.Controllers
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.Cookies;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Session;

    public class UsersController : Controller
    {
        private const string Username = "user";
        private const string Password = "user123";

        public UsersController(Request request)
            : base(request)
        {
        }

        public Response Login()
            => View();

        public Response LogInUser()
        {
            this.Request.Session.Clear();

            bool usernameMatches = this.Request.Form["Username"] == Username;
            bool passwordMatches = this.Request.Form["Password"] == Password;

            if (usernameMatches && passwordMatches)
            {
                if (!this.Request.Session
                    .ContainsKey(HttpSession.SessionUserKey))
                {
                    this.Request.Session[HttpSession.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();
                    cookies.Add(HttpSession.SessionCookieName,
                        this.Request.Session.Id);

                    return Html("<h3>Logged successfully!</h3>", cookies);
                }
                return Html("<h3>You are already Logged!</h3>");
            }
            return Redirect("/Login");
        }

        public Response LogOut()
        {
            this.Request.Session.Clear();
            return Html("<h3>Logged out successfully!</h3>");
        }

        public Response Register()
        {
            return this.View();
        }

        public Response Registration()
        {
            string email = this.Request.Form["Email"];
            string pass = this.Request.Form["Psw"];
            string passRepeat = this.Request.Form["Psw-Repeat"];

            if (pass == passRepeat && !string.IsNullOrEmpty(email))
            {

            }

            return this.View();
        }

        public Response UserProfile()
        {
            if (this.Request.Session
                .ContainsKey(HttpSession.SessionUserKey))
            {
                return Html("Currently logged-in user " +
                     $"is with username '{Username}'</h3>");
            }

            return Html("<h3>You should first log in " +
               "- <a href='/Login'>Login</a></h3>");
        }
    }
}
