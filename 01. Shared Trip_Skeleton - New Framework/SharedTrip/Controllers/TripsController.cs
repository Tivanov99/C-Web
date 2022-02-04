namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.ApplicationModels;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Validator;
    using System;
    using System.Linq;

    public class TripsController : Controller
    {
        private ApplicationDbContext dbContext;
        private TripDataValidator tripDataValidator;
        public TripsController(
            ApplicationDbContext dbContext,
            TripDataValidator tripDataValidator)
        {
            this.tripDataValidator = tripDataValidator;
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
            return this.Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Add(CreatedTripForm createdTripForm)
        {
            if (this.User.IsAuthenticated)
            {
                if (this.tripDataValidator
                .IsValidProduct(createdTripForm))
                {
                    this.dbContext
                        .Trips
                        .Add(new Trip()
                        {
                            Id = Guid.NewGuid().ToString(),
                            StartPoint = createdTripForm.StartPoint,
                            EndPoint = createdTripForm.EndPoint,
                            DepartureTime = createdTripForm.DepartureTime,
                            Seats = createdTripForm.Seats,
                            Description = createdTripForm.Description,
                            ImagePath = createdTripForm.ImagePath
                        });

                    this.dbContext
                        .SaveChanges();

                    return this.All();
                }
                return this.View();
            }
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Add()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Users/Login");
        }
    }
}
