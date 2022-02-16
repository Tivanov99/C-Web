using MyWebServer.Controllers;
using MyWebServer.Http;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        public HttpResponse Details()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Users/Login");
        }
    }
}
