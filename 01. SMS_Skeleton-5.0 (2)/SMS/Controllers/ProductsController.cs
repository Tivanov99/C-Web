using MyWebServer.Controllers;
using MyWebServer.Http;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        public HttpResponse Create()
        =>this.View();
    }
}
