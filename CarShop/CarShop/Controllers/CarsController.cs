namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CarsController : Controller
    {
        private ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        public HttpResponse All()
        {
            string userId = this.User.Id;

            AllCarsModel allCarsModel = new()
            {
                Cars = this.carService.GetAllCars(userId)
            };


            return this.View(allCarsModel);
        }
    }
}
