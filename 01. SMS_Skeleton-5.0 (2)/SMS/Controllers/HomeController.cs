namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            //TODO : check here wheter 'AuthenticatedUserId' added before that
            return this.Request.Session.Contains("AuthenticatedUserId") ?
                   this.IndexLoggedIn() :
                   this.View();
            //if (this.Request.Session.Contains("AuthenticatedUserId"))
            //{
            //    return
            //}
            //return this.View();
        }
        private HttpResponse IndexLoggedIn()
            => this.View();
    }
}