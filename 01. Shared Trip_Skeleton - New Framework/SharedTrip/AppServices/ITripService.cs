namespace SharedTrip.AppServices
{
    using SharedTrip.ApplicationModels;
    using SharedTrip.DTOS;

    public interface ITripService
    {
        TripsModel GetAllTrips();

        bool AddTrip(CreatedTripForm createdTripForm);

        TripDetailsDto GetTrip(string tripId);

        bool AddUserToTrip(string tripId, string userId);

        bool IsUserAlreadyJoinTrip(string userId);
    }
}
