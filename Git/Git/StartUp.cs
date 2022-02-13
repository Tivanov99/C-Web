namespace Git
{
    using Git.Data;
    using MyWebServer;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using Git.Controllers;
    using Git.Contracts;
    using MyWebServer.Services;
    using Git.Services;

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
            .Add<IRepository, Repository.Repository>()
            .Add<IUserService, UserService>()
            .Add<IRepositoryService, RepositoryService>()
            .Add<ICommitService, CommitService>())
            .WithConfiguration<ApplicationDbContext>(context => context
                .Database.Migrate())
            .Start();
    }
}
