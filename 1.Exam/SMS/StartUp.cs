namespace SMS
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Data;

    public class StartUp
    {
        public static async Task Main()
        {
            SMSDbContext sMSDbContext = new SMSDbContext();
            sMSDbContext.Database.EnsureCreated();
        }
            //=> await HttpServer
            //    .WithRoutes(routes => routes
            //        .MapStaticFiles()
            //        .MapControllers())
            //    .WithServices(services => services
            //        .Add<IViewEngine, CompilationViewEngine>())
            //    .Start();
    }
}