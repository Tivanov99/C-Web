namespace SMS
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Controllers;
    using SMS.Data;

    public class StartUp
    {
        public static async Task Main()
        {
            var context = new SMSDbContext();
            context.Database.EnsureCreated();

            await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers()
                .MapGet<HomeController>("/Index", c => c.Index())
                .MapPost<UsersController>("/Users/Login", c => c.LoggingInUser())
            //.MapPost<UsersController>("/Users/Register", c => c.Registration())
            .MapPost<ProductsController>("/Products/Create", c => c.CreateProduct()))
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>())
                .Start();


        }
    }
}