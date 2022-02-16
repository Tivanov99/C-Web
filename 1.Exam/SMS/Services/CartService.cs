namespace SMS.Services
{
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

        public List<CartProductModel> AllProducts(string userId)
        {
            User user = GetUser(userId);

            if (user != null)
            {
                return this.repo
                  .All<Cart>()
                  .Where(c => c.User.Id == userId)
                  .SelectMany(c => c.Products)
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
            User user = this.repo.All<User>()
                .Where(u => u.Id == userId)
                .FirstOrDefault();
            user.Cart.Products.Clear();

            this.repo.SaveChanges();
        }

        private User GetUser(string userId)
        => this.repo
            .All<User>()
            .Where(u => u.Id == userId)
            .FirstOrDefault();
    }
}
