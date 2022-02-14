namespace SMS
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Controllers;
    using SMS.Data;
    using SMS.Data.Common;

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
                .MapGet<HomeController>("/Index", c => c.Index()))
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                .Add<IRepository, Repository>())
                .Start();
    }
}