namespace SMS.Services
{
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeService : IHomeService
    {
        private readonly Repository repo;
        public HomeService(Repository repo)
        {
            this.repo = repo;
        }
        public List<ProductViewModel> GetAll()
        => this.repo.All<Product>()
                 .Select(p => new ProductViewModel()
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Price = p.Price,
                 })
                 .ToList();
    }
}
