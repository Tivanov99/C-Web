namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;

    public class TripsController : Controller
    {
        private ApplicationDbContext dbContext;
        public TripsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public HttpResponse All()
        {
            var allTrips = this.dbContext
                .Trips
        }
    }
}
