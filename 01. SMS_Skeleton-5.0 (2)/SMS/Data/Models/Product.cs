using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MinLength(4)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Range(0.05, 1000)]
        [Required]
        public decimal Price { get; set; }


        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
