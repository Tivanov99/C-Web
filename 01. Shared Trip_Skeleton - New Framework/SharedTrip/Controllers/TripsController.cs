namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.ApplicationModels;
    using SharedTrip.Data;
    using System.Linq;

    public class TripsController : Controller
    {
        private ApplicationDbContext dbContext;
        public TripsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public HttpResponse All()
        {
            if (this.User.IsAuthenticated)
            {
                TripsModel tripModel = new();

                tripModel.Trips = this.dbContext
                  .Trips
                  .Select(t => new TripsDtoModel()
                  {
                      StartPoint = t.StartPoint,
                      EndPoint = t.EndPoint,
                      DepartureTime = t.DepartureTime,
                      Seats = t.Seats,
                  })
                  .ToList();

                return this.View(tripModel);
            }
            return this.Unauthorized();
        }
    }
}
