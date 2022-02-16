namespace SMS
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Common;
    using SMS.Contracts;
    using SMS.Controllers;
    using SMS.Data;
    using SMS.Data.Common;
    using SMS.Services;

    public class StartUp
    {
        public static async Task Main()
        //{
        //    SMSDbContext sMSDbContext = new SMSDbContext();
        //    sMSDbContext.Database.EnsureCreated();
        //}
        => await HttpServer
            .WithRoutes(routes => routes
                .MapStaticFiles()
                .MapControllers()
            .MapGet<HomeController>("/Index", c => c.Index())
            .MapGet<HomeController>("/IndexLoggedIn", c => c.IndexLoggedIn()))
            .WithServices(services => services
                .Add<IViewEngine, CompilationViewEngine>()
            .Add<IRepository, Repository>()
            .Add<IUserService, UserService>()
            .Add<PasswordHasher>()
            .Add<IHomeService, HomeService>()
            .Add<ICartService, CartService>())
            .Start();
    }
}