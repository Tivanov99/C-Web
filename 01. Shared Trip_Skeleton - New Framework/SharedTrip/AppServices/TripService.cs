namespace SharedTrip.AppServices
{
    using SharedTrip.ApplicationModels;
    using SharedTrip.Data;
    using SharedTrip.DTOS;
    using SharedTrip.Models;
    using SharedTrip.Validator;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class TripService : ITripService
    {
        private ApplicationDbContext dbContext;
        private TripDataValidator tripDataValidator;

        public TripService(ApplicationDbContext dbContext,
            TripDataValidator tripDataValidator)
        {
            this.dbContext = dbContext;
            this.tripDataValidator = tripDataValidator;
        }

        public TripsModel GetAllTrips()
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

            return tripModel;
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

        public Trip GetTrip(string id)
        {
            throw new NotImplementedException();
        }
    }
}
