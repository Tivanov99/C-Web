namespace CarShop.Data.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        //[StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be between {2} and {1} sybols.")]
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }
    }
}
