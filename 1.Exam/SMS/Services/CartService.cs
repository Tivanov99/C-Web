namespace SMS.Services
{
    using Microsoft.EntityFrameworkCore;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CartService : ICartService
    {
        private readonly IRepository repo;
        public CartService(IRepository repository)
        {
            this.repo = repository;
        }

        public void AddProduct(string productId, string userId)
        {
            Product product = this.repo
                .All<Product>()
                 .Where(p => p.Id == productId)
                 .FirstOrDefault();

            User user = this.GetUser(userId);

            if (product != null && user != null)
            {
                user.Cart.Products.Add(product);
                this.repo.SaveChanges();
            }
        }

        public List<CartProductModel> AllProducts(string userId)
        {
            User user = GetUser(userId);

            if (user != null)
            {
                return user
                 .Cart
                 .Products
                  .Select(p => new CartProductModel()
                  {
                      Name = p.Name,
                      Price = p.Price,
                  })
                  .ToList();
            }
            return null;
        }

        public void BuyAll(string userId)
        {
            User user = this.repo
                .All<User>()
                .Include(c => c.Cart)
                .Where(u => u.Id == userId)
                .FirstOrDefault();


            user.Cart.Products.Clear();

            var products = user.Cart.Products;
            RemoveCartFromProduct(products);

            this.repo.SaveChanges();
        }

        private User GetUser(string userId)
        => this.repo
            .All<User>()
            .Include(u => u.Cart)
            .Where(u => u.Id == userId)
            .FirstOrDefault();
        private void RemoveCartFromProduct(List<Product> products)
        {
            foreach (var item in products)
            {
                item.CartId = null;
                item.Cart = null;
            }
        }
    }
}
