namespace CarShop.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CarsController : Controller
    {
        public HttpResponse All()
        {
            return this.View();
        }
    }
}
