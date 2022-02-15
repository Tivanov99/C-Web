namespace SMS.Models
{
    using System.Collections.Generic;

    public class ProductModel
    {
        public ProductModel()
        {
            this.Products = new();
        }
        public List<ProductViewModel> Products { get; set; }
    }
}
