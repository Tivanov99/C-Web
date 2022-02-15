namespace SMS.Services
{
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Models;
    using System;
    public class ProductService : IProductService
    {
        private readonly Repository repo;
        public ProductService(Repository repo)
        {
            this.repo = repo;
        }

        public void Create(CreateProductModel createProductModel)
        {
            throw new NotImplementedException();
        }

        public bool ValidateProductData(CreateProductModel createProductModel)
        {
            throw new NotImplementedException();
        }
    }
}
