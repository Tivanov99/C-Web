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

        public List<CartProductViewModel> AllProducts()
        => this.repo.All<Product>()
                .Select(p => new CartProductViewModel()
                {
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToList();

    }
}
