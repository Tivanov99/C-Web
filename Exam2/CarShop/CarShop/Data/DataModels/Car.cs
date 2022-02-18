namespace CarShop.Data.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        [StringLength(300)]
        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; set; }

        public List<Issue> Issues { get; set; } = new List<Issue>();
    }
}
