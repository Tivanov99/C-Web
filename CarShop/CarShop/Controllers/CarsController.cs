namespace CarShop.Controllers
{
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CarsController : Controller
    {
        private IMechanicService mechanicService;

        public CarsController(IMechanicService mechanicService)
        {
            this.mechanicService = mechanicService;
        }

        public HttpResponse All()
        {
            string userId = this.User.Id;



            return this.View();
        }
    }
}
