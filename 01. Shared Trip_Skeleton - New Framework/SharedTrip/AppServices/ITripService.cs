namespace SharedTrip.AppServices
{
    using SharedTrip.ApplicationModels;
    using SharedTrip.DTOS;
    using SharedTrip.Models;

    public interface ITripService
    {
        TripsModel GetAllTrips();

        bool AddTrip(CreatedTripForm createdTripForm);

        TripDetailsDto GetTripAsDto(string tripId);

        Trip GetTrip(string tripId);

        bool AddUserToTrip(string tripId, string userId);

        bool IsUserAlreadyJoinTrip(string tripId, string userId);

        bool IsTripHaveAvailableSeats(string tripId);
    }
}
