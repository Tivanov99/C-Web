namespace SMS.Models
{
    using System.Collections.Generic;
  
    public class LoggedInUserIndexPageModel
    {
        public LoggedInUserIndexPageModel(List<Product> products)
        {
            this.Products = products;
        }
        public List<Product> Products { get; set; }
    }
}
