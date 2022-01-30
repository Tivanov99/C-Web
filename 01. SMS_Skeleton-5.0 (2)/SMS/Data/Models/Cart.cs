namespace SMS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public List<Product> Products { get; set; }
    }
}
