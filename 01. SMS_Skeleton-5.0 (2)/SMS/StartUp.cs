namespace SMS
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Controllers;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers()
                .MapGet<HomeController>("/Index", c => c.Index())
                .MapPost<UsersController>("/Users/Login", c => c.LoggingInUser())
            .MapPost<UsersController>("/Users/Register", c => c.Registration()))
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>())
                .Start();
    }
}