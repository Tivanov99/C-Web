namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20), MinLength(4)]
        public string Name { get; set; }

        [Range(0.05, 1000)]
        public decimal Price { get; set; }

        public Cart Cart { get; set; }

        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }
    }
}
