namespace SharedTrip.AppServices
{
    using SharedTrip.ApplicationModels;
    using SharedTrip.Models;
    using System.Collections.Generic;
    public interface ITripService
    {
        IEnumerable<Trip> GetAllTrips();

        bool AddTrip(CreatedTripForm createdTripForm);

        Trip GetTrip(string id);

        bool AddUserToTrip(string tripId, string userId);
    }
}
