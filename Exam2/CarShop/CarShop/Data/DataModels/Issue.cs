namespace CarShop.Data.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Issue
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(300, MinimumLength = 5)]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        public string CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
    }
}
