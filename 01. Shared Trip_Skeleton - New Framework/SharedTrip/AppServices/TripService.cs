namespace SharedTrip.AppServices
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.ApplicationModels;
    using SharedTrip.Data;
    using SharedTrip.DTOS;
    using SharedTrip.Models;
    using SharedTrip.Validator;
    using System;
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
                  DepartureTime = t.DepartureTime.ToString(""),
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
            Trip joinedTrip = this.GetTrip(tripId);

            this.dbContext
                 .UserTrips.Add(new UserTrip()
                 {
                     TripId = tripId,
                     UserId = userId
                 });

            joinedTrip.Seats -= 1;

            this.dbContext.SaveChanges();

            return true;
        }

        public TripDetailsDto GetTripAsDto(string tripId)
        {
            TripDetailsDto trip = this.dbContext
                    .Trips
                    .AsNoTracking()
                    .Where(t => t.Id == tripId)
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
            return trip;
        }

        public bool IsUserAlreadyJoinTrip(string tripId, string userId)
       => this.dbContext
               .UserTrips
                   .Any(ut => ut.TripId == tripId &&
                       ut.UserId == userId);


        public bool IsTripHaveAvailableSeats(string tripId)
        => this.dbContext
            .Trips
            .Where(t => t.Id == tripId)
            .Any(t => t.Seats > 0);

        public Trip GetTrip(string tripId)
        => this.dbContext
            .Trips
            .Where(t => t.Id == tripId)
            .First();
    }
}
