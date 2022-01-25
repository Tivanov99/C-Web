namespace BasicWebServer.Demo.Controllers
{
    using BasicWebServer.Demo.Models;
    using BasicWebServer.Server;
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.Cookies;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Session;
    using System.Linq;
    using System.Text;
    using System.Web;

    public class HomeController : Controller
    {
        private const string FileName = "content.txt";

        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index() => 
            this.View();

        public Response Redirect()
            => Redirect("https://www.youtube.com/watch?v=5tXyXFIIoos");

        public Response HtmlFormPost()
        {
            var name = this.Request.Form["Name"];
            var age = this.Request.Form["Age"];


            var model = new FormViewModel()
            {
                Name = name,
                Age = int.Parse(age)
            };

            return View(model);

        }

        public Response Html()
            => View();

        public Response PostTextFile()
            => File(FileName);

        public Response Content() => View();

        public Response DownloadContent()
        {
            FileContentAccess.DownloadSitesAsTextFile(FileName,
                new string[] { "https://softuni.bg/" })
                .Wait();

            return File(FileName);
        }

        public Response Cookies()
        {
            bool requestHasCookies = this.Request.Cookies
               .Any(c => c.Name != HttpSession.SessionCookieName);

            string bodyText = "";

            if (requestHasCookies)
            {
                StringBuilder cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><ht>Value</th></tr>");

                foreach (Cookie currCookie in this.Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(currCookie.Name)}</td>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(currCookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");
                bodyText = cookieText.ToString();
                return Html(bodyText);
            }

            var cookies = new CookieCollection();
            cookies.Add("My-Cookie", "My-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Value");
            return Html("<h1>Cookies set!</h1>", cookies);
        }

        public Response Session()
        {
            bool sessionExist = this.Request.Session
            .ContainsKey(HttpSession.SessionCurrentDateKey);

            if (sessionExist)
            {
                string currentDate = this.Request.Session[HttpSession.SessionCurrentDateKey];
                return Text($"Stored date: {currentDate}!");
            }

            return Html("Current date stored!");
        }
    }
}
