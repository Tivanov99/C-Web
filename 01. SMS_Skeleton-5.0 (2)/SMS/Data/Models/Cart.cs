namespace SMS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User User { get; set; }

        public List<Product> Products { get; set; }
    }
}
