namespace SharedTrip
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;

    using Controllers;
    using MyWebServer.Results.Views;
    using SharedTrip.Data;
    using MyWebServer.Services;

    public class Startup
    {

        public static async Task Main()
        //{
        //    ApplicationDbContext dbContext = new ApplicationDbContext();
        //    dbContext.Database.EnsureCreated();
        //}
        => await HttpServer
            .WithRoutes(routes => routes
                .MapStaticFiles()
                .MapControllers()
            .MapGet<HomeController>("/Index", c => c.Index()))
            .WithServices(services => services
                .Add<IViewEngine, CompilationViewEngine>()
            .Add<IPasswordHasher, PasswordHasher>())
            .Start();
    }
}
