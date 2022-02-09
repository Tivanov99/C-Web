namespace CarShop.Controllers
{
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CarsController : Controller
    {
        private IMechanicService mechanicService;
        private IUserService userService;

        public CarsController(IMechanicService mechanicService,
            IUserService userService)
        {
            this.mechanicService = mechanicService;
            this.userService = userService;
        }

        public HttpResponse All()
        {
            string userId = this.User.Id;




            return this.View();
        }
    }
}
