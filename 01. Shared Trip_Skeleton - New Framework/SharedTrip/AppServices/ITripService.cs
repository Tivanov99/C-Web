namespace SharedTrip.AppServices
{
    using SharedTrip.ApplicationModels;
    using SharedTrip.DTOS;
    using SharedTrip.Models;
    using System.Collections.Generic;
    public interface ITripService
    {
        TripsModel GetAllTrips();

        bool AddTrip(CreatedTripForm createdTripForm);

        Trip GetTrip(string id);

        bool AddUserToTrip(string tripId, string userId);
    }
}
