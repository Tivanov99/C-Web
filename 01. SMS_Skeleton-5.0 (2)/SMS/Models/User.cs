using System.Collections.Generic;

namespace SMS.Models
{
    public class User
    {
        public string Username { get; set; }

        public List<Product> Products { get; set; }
    }
}
