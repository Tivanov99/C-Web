namespace SMS.Models
{
    using System.Collections.Generic;


    public class CartModelView
    {
        public CartModelView()
        {
            this.Products = new();
        }
        public List<CartProductModel> Products { get; set; }
    }
}
