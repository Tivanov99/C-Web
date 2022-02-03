using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        public List<UserTrip> UserTrips { get; set; }
    }
}
