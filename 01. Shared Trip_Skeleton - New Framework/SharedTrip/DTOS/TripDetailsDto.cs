using System;

namespace SharedTrip.DTOS
{
    public class TripDetailsDto
    {
        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; } //nullable
    }
}
