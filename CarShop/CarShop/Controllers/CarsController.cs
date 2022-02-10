namespace CarShop.Controllers
{
    using CarShop.DataForms;
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

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCarDataForm dataForm)
        {
            this.carService.CreateCar(dataForm, this.User.Id);
            return this.All();
        }
    }
}
