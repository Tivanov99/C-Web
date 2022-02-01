using MyWebServer.Controllers;
using MyWebServer.Http;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        public HttpResponse Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }
            return this.View();
        }

        public HttpResponse CreateProduct()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }
            return this.View();
        }
    }
}
