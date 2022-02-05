namespace SharedTrip.AppServices
{
    using SharedTrip.ApplicationModels;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Validator;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class TripService : ITripService
    {
        private ApplicationDbContext dbContext;
        private TripDataValidator tripDataValidator;
        public TripService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddTrip(CreatedTripForm createdTripForm)
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
                        DepartureTime = DateTime.ParseExact(createdTripForm.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                        Seats = createdTripForm.Seats,
                        Description = createdTripForm.Description,
                        ImagePath = createdTripForm.ImagePath
                    });

                this.dbContext
                    .SaveChanges();

                return true;
            }
            return false;
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            throw new NotImplementedException();
        }

        public Trip GetTrip(string id)
        {
            throw new NotImplementedException();
        }
    }
}
