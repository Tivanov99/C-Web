namespace SharedTrip.ApplicationModels
{
    using System;

    public interface ICreateTripForm
    {
        string StartPoint { get; set; }

        string EndPoint { get; set; }

        string DepartureTime { get; set; }

        string ImagePath { get; set; }

        int Seats { get; set; }

        string Description { get; set; }
    }
}
