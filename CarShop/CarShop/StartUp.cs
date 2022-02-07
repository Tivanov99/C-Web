namespace CarShop
{
    using MyWebServer;
    using CarShop.Data;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using CarShop.Controllers;
    using CarShop.Services;
    using CarShop.Validator;

    public class Startup
    {
        public static async Task Main()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    context.Database.EnsureCreated();
        //}
        => await HttpServer
            .WithRoutes(routes => routes
                .MapStaticFiles()
                .MapControllers()
            .MapGet<HomeController>("/Index", c => c.Index()))
            .WithServices(services => services
            .Add<ApplicationDbContext>()
            .Add<IViewEngine, CompilationViewEngine>()
            .Add<IUserService, UserService>()
            .Add<DataValidator,DataValidator>())
            .WithConfiguration<ApplicationDbContext>(context => context
                .Database.Migrate())
            .Start();
    }
}
