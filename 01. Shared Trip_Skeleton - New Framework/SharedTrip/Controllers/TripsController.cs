namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.ApplicationModels;
    using SharedTrip.AppServices;
    using SharedTrip.DTOS;
    using SharedTrip.Models;
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
                var trips = this.tripService
                    .GetAllTrips();

                return this.View(trips);
            }
            return this.Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Add(CreatedTripForm createdTripForm)
        {
            if (this.User.IsAuthenticated)
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

        public HttpResponse Details(string tripId)
        {
            if (this.User.IsAuthenticated)
            {
                TripDetailsDto trip = this.tripService
                    .GetTripAsDto(tripId);

                return this.View(trip);
            }
            return this.Redirect("/User/Login");
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (this.tripService
                    .IsUserAlreadyJoinTrip(tripId, this.User.Id))
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }
            

            if (!this.tripService.IsTripHaveAvailableSeats(tripId))
            {
                //TODO show message to this user for not enoungt seats
            }

            return this.Redirect("/Trips/All");
        }
    }
}
