namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.ApplicationModels;
    using SharedTrip.AppServices;
    using SharedTrip.Data;
    using SharedTrip.DTOS;
    using SharedTrip.Models;
    using SharedTrip.Validator;
    using System;
    using System.Globalization;
    using System.Linq;

    public class TripsController : Controller
    {
        private TripService tripService;

        public TripsController(TripService tripService)
        {
            this.tripService = tripService;
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
                      Id = t.Id,
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
            if (this.User.IsAuthenticated && this.tripService.AddTrip(createdTripForm))
            {
                if (this.tripService.AddTrip(createdTripForm))
                {
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

        public HttpResponse Details()
        {
            if (this.User.IsAuthenticated)
            {
                string tipId = this.Request
                .Query["tripId"];

                TripDetailsDto trip = this.dbContext
                        .Trips
                        .Where(t => t.Id == tipId)
                        .Select(t => new TripDetailsDto()
                        {
                            Id = t.Id,
                            StartPoint = t.StartPoint,
                            EndPoint = t.EndPoint,
                            DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                            Seats = t.Seats,
                            ImagePath = t.ImagePath,
                            Description = t.Description,
                        })
                        .First();

                return this.View(trip);
            }
            return this.Redirect("/User/Login");
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            bool isUserAlreadyJoinTrip =
                this.dbContext
                .UserTrips
                    .Any(ut => ut.TripId == tripId &&
                        ut.UserId == this.User.Id);

            if (isUserAlreadyJoinTrip)
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            Trip joinedTrip = this.dbContext
                .Trips
                .Where(t => t.Id == tripId)
                .First();

            if (joinedTrip.Seats == 0)
            {
                //TODO show message to this user for not enoungt seats
            }

            this.dbContext
                 .UserTrips.Add(new UserTrip()
                 {
                     TripId = tripId,
                     UserId = this.User.Id
                 });

            joinedTrip.Seats -= 1;

            this.dbContext.SaveChanges();

            return this.Redirect("/Trips/All");
        }
    }
}
