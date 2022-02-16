namespace SMS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart
    {
        public Cart()
        {
            this.Products = new();
        }

        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }


        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public List<Product> Products { get; set; }
    }
}