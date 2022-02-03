using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class Trip
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        [Range(2, 6)]
        public int Seats { get; set; }

        [MaxLength(80)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<UserTrip> UserTrips { get; set; }
    }
}
