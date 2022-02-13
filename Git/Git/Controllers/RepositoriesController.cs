namespace Git.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class RepositoriesController : Controller
    {
        public RepositoriesController()
        {
        }
        public HttpResponse All()
        {
            return this.View();
        }
    }
}
