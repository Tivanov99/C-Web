using BasicWebServer.Server;
using BasicWebServer.Server.Contracts;
using BasicWebServer.Server.Cookies;
using BasicWebServer.Server.Responses;
using BasicWebServer.Server.Session;
using System.Text;
using System.Web;

public static class Startup
{
    private const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

    private const string DownloadForm = @"<form action='/Content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";

    private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";


    private const string FileName = "content.txt";

    private const string Username = "user";
    private const string Password = "user123";

    public static async Task Main()
    {
        await DownloadSitesAsTextFile(FileName
            , new string[] { "https://judge.softuni.org/", "https://softuni.org/" });


        var server = new HttpServer(routes => routes
                       .MapGet("/", new TextResponse("Hello from the server!"))
                       .MapGet("/Redirect", new RedirectResponse("https://www.youtube.com/watch?v=5tXyXFIIoos"))
                       .MapGet("/HTML", new HtmlResponse(HtmlForm))
                       .MapGet("/Content", new HtmlResponse(DownloadForm))
                       .MapPost("/Content", new TextFileResponse(FileName))
                       .MapPost("/HTML", new TextResponse("", AddFromDataAction))
                       .MapGet("/Cookies", new HtmlResponse("", AddCookieAction))
                       .MapGet("/Session", new TextResponse("", DisplaySessionInfoAction))
                       .MapGet("/Login", new HtmlResponse(LoginForm))
                       .MapPost("/Login", new HtmlResponse("", LoginAction))
        );
       await server.Start();
    }

    static void AddFromDataAction(IRequest request, IResponse response)
    {
        ;
        response.Body = string.Empty;
        foreach (var (name, value) in request.Form)
        {
            response.Body += $"{name} - {value}";
            response.Body += Environment.NewLine;
        }

    }

    public delegate int Comparison<in T>(string left, string right);

    private static async Task<string> DownloadWebSiteContent(string url)
    {
        var httpClient = new HttpClient();
        using (httpClient)
        {
            var response = await httpClient
                .GetAsync(url);

            var html = await response
                .Content
                .ReadAsStringAsync();

            return html.Substring(0, 2000);
        }
    }
    private static async Task DownloadSitesAsTextFile(
        string fileName, string[] urls)
    {
        var download = new List<Task<string>>();

        foreach (var url in urls)
        {
            download.Add(DownloadWebSiteContent(url));
        }

        var response = await Task
            .WhenAll(download);

        var responsesString = string.Join(
            Environment.NewLine + new string('-', 100),
            response);

        await File.WriteAllTextAsync(fileName, responsesString);
    }
    private static void AddCookieAction(IRequest request, IResponse response)
    {
        bool requestHasCookies = request.Cookies
            .Any(c => c.Name != Session.SessionCookieName);

        string bodyText = "";

        if (requestHasCookies)
        {
            StringBuilder cookieText = new StringBuilder();

            cookieText.AppendLine("<h1>Cookies</h1>");

            cookieText.Append("<table border='1'><tr><th>Name</th><ht>Value</th></tr>");

            foreach (Cookie currCookie in request.Cookies)
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
            response.Body = bodyText;
        }
        else
        {
            bodyText = "<h1>Cookies set!</h1>";
            response.Body = bodyText;
        }

        if (!requestHasCookies)
        {
            response.Cookies.Add("My-Cookie", "My-Value");
            response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
        }
    }
    private static void DisplaySessionInfoAction(IRequest request, IResponse response)
    {
        bool sessionExist = request.HttpSession
            .ContainsKey(Session.SessionCurrentDateKey);

        string bodyText = "";
        if (sessionExist)
        {
            string currentDate = request.HttpSession[Session.SessionCurrentDateKey];
            bodyText = currentDate;
        }
        else
        {
            bodyText = "Current date stored!";
        }
        response.Body = "";
        response.Body += bodyText;
    }

    private static void LoginAction(IRequest request, IResponse response)
    {
        request.HttpSession.Clear();

        var sessionBeforeLogin = request.HttpSession;
        var bodyText = "";

        bool usernameMatches = request.Form["Username"] == Username;
        bool passwordMatches = request.Form["Password"] == Password;

        if (usernameMatches && passwordMatches)
        {
            request.HttpSession[Session.SessionUserKey] = "MyUserId";
            response.Cookies
                .Add(Session.SessionCookieName,
                    request.HttpSession.Id);
            bodyText = "<h3>Logged successfully!</h3>";
            var sessionAfterLogin = request.HttpSession;
        }
        else
        {
            bodyText = LoginForm;
        }
        response.Body = String.Empty;
        response.Body += bodyText;
    }
}