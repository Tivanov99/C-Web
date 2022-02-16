namespace SMS.Services
{
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CartService
    {
        private readonly IRepository repo;
        public CartService(IRepository repository)
        {
            this.repo = repository;
        }

        public List<CartProductModel> AllProducts()
        => this.repo.All<Product>()
                .Select(p => new CartProductModel()
                {
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToList();

        public void BuyAll(string userId)
        {
            User user = this.repo.All<User>()
                .Where(u => u.Id == userId)
                .FirstOrDefault();
            user.Cart.Products.Clear();

            this.repo.SaveChanges();
        }
    }
}
