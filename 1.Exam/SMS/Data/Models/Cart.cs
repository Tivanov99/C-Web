namespace SMS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cart
    {
        public Cart()
        {
            this.Products = new();
        }

        [Key]
        public string Id { get; set; }

        public User User { get; set; }

        public List<Product> Products { get; set; }
    }
}