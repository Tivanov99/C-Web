using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;

public static class Startup
{
    public static async Task Main()
    {
        var server = new HttpServer(routes => routes
        .MapGet<HomeController>("/", c => c.Index())
        .MapGet<HomeController>("/Redirect", c => c.Redirect())
        .MapGet<HomeController>("/HTML", c => c.Html())
        .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
        .MapGet<HomeController>("/Content", c => c.Content())
        .MapPost<HomeController>("/Content", c => c.DownloadContent())
        .MapGet<HomeController>("/Cookies", c => c.Cookies())
        .MapGet<HomeController>("/Session", c => c.Session())
        .MapGet<UsersController>("/Login", c => c.Login())
        .MapPost<UsersController>("/Login", c => c.LogInUser())
        .MapGet<UsersController>("/Logout", c => c.LogOut())
        .MapGet<UsersController>("/UserProfile", c => c.UserProfile())
        .MapGet<UsersController>("/Register", c => c.Register())
        .MapPost<UsersController>("/Registration", c => c.Registration())

        );
        await server.Start();
    }
}