﻿namespace SMS
{
    using System.Threading.Tasks;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using MyWebServer.Services;
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
    /*            .MapGet<UsersController>("/Users/Register",c=>c.Register())*/)
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IPasswordHasher, PasswordHasher>())
                .Start();
        }
    }
}